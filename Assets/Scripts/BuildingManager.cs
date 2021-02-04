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

            Instantiate(buildingType.GetPrefab(),
                Utils.GetMouseWorldPosition(),
                Quaternion.identity);
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
}
