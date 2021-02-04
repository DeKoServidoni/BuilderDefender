using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGhost : MonoBehaviour {

    private SpriteRenderer spriteRenderer = null;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Hide();
    }

    private void Start() {
        BuildingManager.Instance.OnActiveBuildingTypeChange += BuildingManager_OnActiveBuildingTypeChange;
    }

    private void BuildingManager_OnActiveBuildingTypeChange(object sender, BuildingManager.BuildingTypeArgs e) {
        if (e.activeBuildingType == null) Hide();
        else Show(e.activeBuildingType.GetSprite());
    }

    private void Update() {
        transform.position = Utils.GetMouseWorldPosition();  
    }

    private void Show(Sprite ghostSprite) {
        spriteRenderer.sprite = ghostSprite;
    }

    private void Hide() {
        spriteRenderer.sprite = null;
    }
}
