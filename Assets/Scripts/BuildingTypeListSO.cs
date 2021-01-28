using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BuildingTypeList")]
public class BuildingTypeListSO : ScriptableObject {

    [SerializeField]
    private List<BuildingTypeSO> buildingTypeList = null;

    public BuildingTypeSO GetBuildingType(int position) {
        return buildingTypeList[position];
    }

    public List<BuildingTypeSO> GetList() {
        return buildingTypeList;
    }
}
