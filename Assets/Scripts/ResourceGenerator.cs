using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour {

    private ResourceGeneratorData generatorData = null;
    private float timer = 0.0f;
    private float timerMax = 0.0f;

    private void Awake() {
        generatorData = GetComponent<BuildingTypeHolder>().GetBuildingType().GetGeneratorData();
        timerMax = generatorData.GetTimerMax();
    }

    private void Start() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, generatorData.GetDetectionRadius());

        int nearByAmount = 0;
        foreach (Collider2D item in colliders) {
            ResourceNode resourceNode = item.GetComponent<ResourceNode>();

            if (resourceNode != null && resourceNode.GetResourceType() == generatorData.GetResourceType())
                nearByAmount++;
        }

        nearByAmount = Mathf.Clamp(nearByAmount, 0, generatorData.GetMaxResourceAmount());

        if (nearByAmount == 0) enabled = false;
        else {
            timerMax = (generatorData.GetTimerMax() / 2f)
                + generatorData.GetTimerMax()
                * (1 - nearByAmount / generatorData.GetMaxResourceAmount());
        }

    }

    private void Update() {
        timer -= Time.deltaTime;

        if (timer <= 0f) {
            timer += timerMax;
            ResourceManager.Instance.AddResource(
                generatorData.GetResourceType(), 1);
        }
        
    }
}
