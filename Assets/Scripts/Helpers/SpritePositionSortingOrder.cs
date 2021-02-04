using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePositionSortingOrder : MonoBehaviour {

    [SerializeField]
    private bool runOnce = false;

    [SerializeField]
    private float positionOffsetY = 0.0f;

    private SpriteRenderer spriteRenderer = null;
    private float sortingMultiplier = 5f;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate() {
        spriteRenderer.sortingOrder = (int)(- (transform.position.y + positionOffsetY) * sortingMultiplier);

        if(runOnce)
            Destroy(this);
    }

}
