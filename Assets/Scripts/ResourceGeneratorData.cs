using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceGeneratorData {

    [SerializeField]
    private float timerMax = 0.0f;

    [SerializeField]
    private ResourceTypeSO resourceType = null;

    [SerializeField]
    private float resourceDetectionRadius = 0.0f;

    [SerializeField]
    private int maxResourceAmount = 0;

    public float GetTimerMax() {
        return timerMax;
    }

    public ResourceTypeSO GetResourceType() {
        return resourceType;
    }

    public float GetDetectionRadius() {
        return resourceDetectionRadius;
    }

    public int GetMaxResourceAmount() {
        return maxResourceAmount;
    }
}
