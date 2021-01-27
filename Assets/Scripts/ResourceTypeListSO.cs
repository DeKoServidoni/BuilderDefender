using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ResourceTypeList")]
public class ResourceTypeListSO : ScriptableObject {

    [SerializeField]
    private List<ResourceTypeSO> resourceTypes = null;

    public ResourceTypeSO GetResourceType(int position) {
        return resourceTypes[position];
    }

    public List<ResourceTypeSO> GetList() {
        return resourceTypes;
    }
}
