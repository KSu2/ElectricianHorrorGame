using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporterEnemy : MonoBehaviour
{
    private GameObject teleObject;
    private Transform teleTrans;
    private GameObject playerObject;
    private Transform playerTrans;
    private bool triggerOn;

    void Start()
    {
        teleObject = gameObject;
        teleTrans = transform;
        playerObject = References.thePlayer;
        playerTrans = playerObject.transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggerOn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggerOn = false;
        }
    }

    void Update()
    {
        if(triggerOn)
        {
            int index = Random.Range(0, teleTrans.childCount);
            Transform destination = teleTrans.transform.GetChild(index).transform;
            
            Debug.Log("PlayerPos: " + playerTrans.position);
            Debug.Log("DesPos " + index + ": " + destination.position);
            playerTrans.position = destination.position;
        }  
    }
}
