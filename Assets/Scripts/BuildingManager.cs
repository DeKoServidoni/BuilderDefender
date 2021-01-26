using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    // 0 - left mouse button / 1 - right mouse button
    private readonly int LEFT_MOUSE_BUTTON = 0;

    [SerializeField]
    private GameObject pfWoodHarvester = null;
    
    private Camera mainCamera = null;

    private void Start() {
        mainCamera = Camera.main;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON)) {
            Instantiate(pfWoodHarvester, GetMouseWorldPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetMouseWorldPosition() {
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0.0f;
        return worldPosition;
    }
}
