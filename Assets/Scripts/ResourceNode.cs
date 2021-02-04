﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour {

    [SerializeField]
    private ResourceTypeSO resourceType = null;

    public ResourceTypeSO GetResourceType() {
        return resourceType;
    }
}
