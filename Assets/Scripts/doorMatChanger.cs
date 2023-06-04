/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorMatChanger : MonoBehaviour
{
    public Material doorMatOff;
    public MeshRenderer doorMatOn = GetComponent<MeshRenderer>();
    Color col = doorMatOn.material.color;
    public GameObject door;
    public GameObject player;
    private float distance;
    public float opaDis = 20;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(door.transform.position, player.transform.position);
        col.a = distance/(opaDis-5);
        doorMatOn.material.color = col;
    }
}*/