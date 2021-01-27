using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    // 0 - left mouse button / 1 - right mouse button
    private readonly int LEFT_MOUSE_BUTTON = 0;

    private BuildingTypeListSO buildingTypeList = null;
    private BuildingTypeSO buildingType = null;
    
    private Camera mainCamera = null;

    private void Awake() {
        buildingTypeList = Resources
            .Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);

        buildingType = buildingTypeList.GetBuildingType(0);
    }

    private void Start() {
        mainCamera = Camera.main;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON)) {
            Instantiate(buildingType.GetPrefab(),
                GetMouseWorldPosition(),
                Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            buildingType = buildingTypeList.GetBuildingType(0);
        }

        if (Input.GetKeyDown(KeyCode.Y)) {
            buildingType = buildingTypeList.GetBuildingType(1);
        }
    }

    private Vector3 GetMouseWorldPosition() {
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0.0f;
        return worldPosition;
    }
}
