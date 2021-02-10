using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour {

    public static BuildingManager Instance { get; private set; }

    // 0 - left mouse button / 1 - right mouse button
    private readonly int LEFT_MOUSE_BUTTON = 0;

    private BuildingTypeListSO buildingTypeList = null;
    private BuildingTypeSO buildingType = null;

    public event EventHandler<BuildingTypeArgs> OnActiveBuildingTypeChange;

    public class BuildingTypeArgs : EventArgs {
        public BuildingTypeSO activeBuildingType;
    }

    private void Awake() {
        Instance = this;

        buildingTypeList = Resources
            .Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
    }

    private void Update() {
        if (buildingType != null
            && Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON)
            && !EventSystem.current.IsPointerOverGameObject()) {

            if (CanSpawnBuilding(buildingType, Utils.GetMouseWorldPosition())) {
                Instantiate(buildingType.GetPrefab(),
                    Utils.GetMouseWorldPosition(),
                    Quaternion.identity);
            }
        }
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingType) {
        this.buildingType = buildingType;

        var args = new BuildingTypeArgs {
            activeBuildingType = buildingType
        };

        OnActiveBuildingTypeChange?.Invoke(this, args);
    }

    public BuildingTypeSO GetActiveBuildingType() {
        return buildingType;
    }

    public bool CanSpawnBuilding(BuildingTypeSO buildingType, Vector3 position) {
        BoxCollider2D boxCollider = buildingType.GetPrefab().GetComponent<BoxCollider2D>();

        Collider2D[] colliders = Physics2D.OverlapBoxAll(position + (Vector3) boxCollider.offset, boxCollider.size, 0);
        if (colliders.Length > 0)
            return false;

        if (!CanSpawnBuildingWithMinRadius(position, buildingType.GetMinConstructionRadius()))
            return false;

        return CanSpawnBuildingWithMaxRadius(position);
    }

    private bool CanSpawnBuildingWithMinRadius(Vector3 position, float minRadius) {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, minRadius);

        foreach (var item in colliders) {
            BuildingTypeHolder holder = item.GetComponent<BuildingTypeHolder>();
            if (holder != null && holder.GetBuildingType() == buildingType)
                return false;
        }

        return true;
    }

    private bool CanSpawnBuildingWithMaxRadius(Vector3 position) {
        float maxConstructionRadius = 25f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, maxConstructionRadius);

        foreach (var item in colliders) {
            BuildingTypeHolder holder = item.GetComponent<BuildingTypeHolder>();
            if (holder != null)
                return true;
        }

        return false;
    }
}
