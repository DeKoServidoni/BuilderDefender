using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ResourceType")]
public class ResourceTypeSO : ScriptableObject {

    [SerializeField]
    private string nameString = null;

    [SerializeField]
    private Sprite sprite = null;

    public Sprite GetSprite() {
        return sprite;
    }

}
