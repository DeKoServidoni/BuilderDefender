using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour {

    [SerializeField]
    private CinemachineVirtualCamera cinemachineVirtualCamera = null;

    [SerializeField]
    private float moveSpeed = 30.0f;

    [SerializeField]
    private float zoomSpeed = 5.0f;

    [SerializeField]
    private float minOrthographicSize = 10.0f;

    [SerializeField]
    private float maxOrthographicSize = 30.0f;

    float orthographicSize = 0.0f;
    float targetOrthographicSize = 0.0f;

    private readonly float zoomAmount = 2.0f;

    private void Start() {
        orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        targetOrthographicSize = orthographicSize;
    }

    private void Update() {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement() {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")).normalized;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void HandleZoom() {
        targetOrthographicSize += Input.mouseScrollDelta.y * zoomAmount;

        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize,
            minOrthographicSize, maxOrthographicSize);

        orthographicSize = Mathf.Lerp(orthographicSize,
            targetOrthographicSize, Time.deltaTime * zoomSpeed);

        cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;
    }
}
