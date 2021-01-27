using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTypeHolder : MonoBehaviour {

    [SerializeField]
    private BuildingTypeSO buildingType = null;

    public BuildingTypeSO GetBuildingType() {
        return buildingType;
    }
}
