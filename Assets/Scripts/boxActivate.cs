using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxActivate : MonoBehaviour, IInteractable
{
    [SerializeField] private Material myMat;

    public static bool boxOn;
    bool delay;
    public GameObject mainLight;
    public Material skyMat1;
    public Material skyMat2;

    private void Start()
    {
        boxOn = true;
        myMat.color = Color.green;
    }

    public void Interact() 
    {
        //Box is on
        if(boxOn == false && delay == false)
        {
            delay = true;
            myMat.color = Color.green;
            boxOn = true;
            mainLight.SetActive(true);
            RenderSettings.ambientIntensity = 1f;
            RenderSettings.fog = false;
            RenderSettings.skybox = skyMat1;
            RenderSettings.reflectionIntensity = 1f;
            StartCoroutine(DelayFunc());
        }

        //Box is off
        else if(boxOn == true && delay == false)
        {
            delay = true;
            myMat.color = Color.red;
            boxOn = false;
            mainLight.SetActive(false);
            RenderSettings.ambientIntensity = 0f;
            RenderSettings.fog = true;
            RenderSettings.skybox = skyMat2;
            RenderSettings.reflectionIntensity = 0.2f;
            StartCoroutine(DelayFunc());
        }
    }
    IEnumerator DelayFunc()
        {
            yield return new WaitForSeconds(0.5f);
            delay = false;
        }
}
