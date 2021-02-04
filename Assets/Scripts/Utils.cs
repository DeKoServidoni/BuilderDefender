using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

    private static Camera mainCamera = null;

    public static Vector3 GetMouseWorldPosition() {

        if (!mainCamera)
            mainCamera = Camera.main;

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0.0f;
        return worldPosition;
    }
}
