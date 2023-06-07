using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{

    public float mouseSens = 100f;

    public Transform playerBody;

    bool camDelay;
    public float camDelayTime = 1f;
    public float camDelayTimePerc = .9f;

    float xRotation = 0f;
    float damRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camDelay = false;
        damRotation = 0f;
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

            transform.localRotation = Quaternion.Euler(xRotation, 0f, damRotation);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        
        if(playerHealth.delayOn && !camDelay)
        {
            camDelay = true;
            StartCoroutine(CamRotFunc());
        }
        
    }

    IEnumerator CamRotFunc()
        { 
            if (Random.value < .5)
            {
                Debug.Log("50+");
                damRotation += 10f;
                while(damRotation > 0f)
                {
                    damRotation -= Time.timeScale*.1f;
                }
            }
            else
            {
                Debug.Log("50-");
                damRotation -= 10f;
                while(damRotation < 0f)
                {
                    damRotation += Time.timeScale*.1f;
                }
            }
            yield return new WaitForSeconds(camDelayTime*(1-camDelayTimePerc));
            damRotation = 0f;
            yield return new WaitForSeconds(camDelayTime*camDelayTimePerc);
            camDelay = false;
        }
}
