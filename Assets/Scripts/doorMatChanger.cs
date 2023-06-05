using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorMatChanger : MonoBehaviour
{
    public Material doorMatOff;
    public Material doorMatOn;
    public Renderer rend;
    public GameObject door;
    public GameObject player;
    public GameObject doorLight;
    private float distance;
    public float opaDis = 20f;
    


    // Start is called before the first frame update
    void Start()
    {
        door.GetComponent<Renderer>().material = doorMatOff;
        rend = GetComponent<Renderer>();
        doorLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(door.transform.position, player.transform.position);
        // Debug.Log("Distance: " + distance);
        Color color = doorMatOn.color;
        color.a = ((distance + 4f)/ opaDis);

        doorMatOn.color = color;

        if (!boxActivate.boxOn)
        {
            door.GetComponent<Renderer>().material = doorMatOn;
            doorLight.SetActive(true);
        }
        else
        {
            door.GetComponent<Renderer>().material = doorMatOff;
            doorLight.SetActive(false);
        }
    }
}