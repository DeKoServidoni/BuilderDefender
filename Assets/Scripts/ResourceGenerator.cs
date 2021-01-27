using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour {

    private BuildingTypeSO buildingType = null;
    private float timer = 0.0f;
    private float timerMax = 0.0f;

    private void Awake() {
        buildingType = GetComponent<BuildingTypeHolder>().GetBuildingType();
        timerMax = buildingType.GetGeneratorData().GetTimerMax();
    }

    private void Update() {
        timer -= Time.deltaTime;

        if (timer <= 0f) {
            timer += timerMax;
            ResourceManager.Instance.AddResource(
                buildingType.GetGeneratorData().GetResourceType(), 1);
        }
        
    }
}
