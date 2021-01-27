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
    private ResourceGeneratorData resourceGeneratorData = null;

    public Transform GetPrefab() {
        return prefab;
    }

    public ResourceGeneratorData GetGeneratorData() {
        return resourceGeneratorData;
    }
}
