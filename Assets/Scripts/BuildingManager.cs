using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour {

    public static BuildingManager Instance { get; private set; }

    // 0 - left mouse button / 1 - right mouse button
    private readonly int LEFT_MOUSE_BUTTON = 0;

    private BuildingTypeListSO buildingTypeList = null;
    private BuildingTypeSO buildingType = null;
    
    private Camera mainCamera = null;

    private void Awake() {
        Instance = this;

        buildingTypeList = Resources
            .Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
    }

    private void Start() {
        mainCamera = Camera.main;
    }

    private void Update() {
        if (buildingType != null
            && Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON)
            && !EventSystem.current.IsPointerOverGameObject()) {

            Instantiate(buildingType.GetPrefab(),
                GetMouseWorldPosition(),
                Quaternion.identity);
        }
    }

    private Vector3 GetMouseWorldPosition() {
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0.0f;
        return worldPosition;
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingType) {
        this.buildingType = buildingType;
    }

    public BuildingTypeSO GetActiveBuildingType() {
        return buildingType;
    }
}
