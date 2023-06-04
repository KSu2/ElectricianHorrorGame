using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public bool isOn = false;
    public GameObject lightSource;
    public bool failSafe = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("fKey"))
        {
            if (isOn == false && failSafe == false)
            {
                failSafe = true;
                lightSource.SetActive(true);
                isOn = true;
                StartCoroutine(FailSafe());
            }

            else if (isOn == true && failSafe == false)
            {
                failSafe = true;
                lightSource.SetActive(false);
                isOn = false;
                StartCoroutine(FailSafe());
            }
        }
    }
    IEnumerator FailSafe()
        {
            yield return new WaitForSeconds(0.25f);
            failSafe = false;
        }
}

