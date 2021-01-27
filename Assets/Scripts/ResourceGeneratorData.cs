using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceGeneratorData {

    [SerializeField]
    private float timerMax;

    [SerializeField]
    private ResourceTypeSO resourceType;

    public float GetTimerMax() {
        return timerMax;
    }

    public ResourceTypeSO GetResourceType() {
        return resourceType;
    }
}
