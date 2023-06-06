using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxActivate : MonoBehaviour, IInteractable
{
    [SerializeField] private Material myMat;

    public static bool boxOn;
    bool delay;

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
            StartCoroutine(DelayFunc());
        }

        //Box is off
        else if(boxOn == true && delay == false)
        {
            delay = true;
            myMat.color = Color.red;
            boxOn = false;
            StartCoroutine(DelayFunc());
        }
    }
    
    IEnumerator DelayFunc()
        {
            yield return new WaitForSeconds(0.5f);
            delay = false;
        }
}
