using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour{
    [SerializeField]
    private float sensetivityY = 4f;
    [SerializeField]
    private float inverse = -1f;

    private float mouseY = 0f;

    private void Rotation() {

        mouseY = mouseY + Input.GetAxis("Mouse Y") * sensetivityY * inverse;

        mouseY = Mathf.Clamp(mouseY,-70f,70f);

        transform.localRotation = Quaternion.Euler(mouseY, 0f, 0f);

    }
    void Start() {

        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update() {

        Rotation();

    }

}
