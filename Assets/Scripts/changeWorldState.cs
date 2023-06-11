using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeWorldState : MonoBehaviour
{
    public GameObject mainLight;
    public Material skyMat1;
    public Material skyMat2;
    
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogDensity = 0.05f;
        RenderSettings.fogColor = Color.black;
        RenderSettings.ambientSkyColor = Color.black;
        RenderSettings.ambientGroundColor = Color.black;
        RenderSettings.ambientEquatorColor = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if(boxActivate.boxOn)
        {
            mainLight.SetActive(true);
            RenderSettings.ambientIntensity = 1f;
            RenderSettings.fog = false;
            RenderSettings.skybox = skyMat1;
            RenderSettings.reflectionIntensity = 1f;
        }
        else
        {
            mainLight.SetActive(false);
            RenderSettings.ambientIntensity = 0f;
            RenderSettings.fog = true;
            RenderSettings.skybox = skyMat2;
            RenderSettings.reflectionIntensity = 0.02f;
        } 
    }
}
