using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{

    public float mouseSens;

    public Transform playerBody;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mouseSens = 500f;
        Cursor.lockState = CursorLockMode.Locked;
        References.theCamera = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!inventoryMenu.invOpen && !pauseMenu.isPaused)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }    
    }
}
