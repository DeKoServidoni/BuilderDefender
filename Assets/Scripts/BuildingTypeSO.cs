using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BuildingType")]
public class BuildingTypeSO : ScriptableObject {

    [SerializeField]
    private  string nameString = "";

    [SerializeField] 
    private Transform prefab = null;

    [SerializeField]
    private Sprite sprite = null;

    [SerializeField]
    private ResourceGeneratorData resourceGeneratorData = null;

    [SerializeField]
    private float minConstructionRadius = 0.0f;

    public Transform GetPrefab() {
        return prefab;
    }

    public ResourceGeneratorData GetGeneratorData() {
        return resourceGeneratorData;
    }

    public Sprite GetSprite() {
        return sprite;
    }

    public float GetMinConstructionRadius() {
        return minConstructionRadius;
    }
}
