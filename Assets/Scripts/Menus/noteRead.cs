using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteRead : MonoBehaviour, IInteractable
{
    public GameObject note;
    public GameObject noteWriting;
    public GameObject noteList;
    public GameObject player;
    public bool noteOpen;
    private float distance;
    public float maxDis = 8f;

    // Start is called before the first frame update
    void Start()
    {
        noteWriting.SetActive(false);
    }

    void Update()
    {
        //add an area trigger so this isn't firing all the time
        distance = Vector3.Distance(note.transform.position, player.transform.position);
        if(distance > maxDis)
        {
            CloseNote();
        }
    }

    public void Interact() 
    {
        if(!noteOpen)
        {
            OpenNote(); 
        }
        else
        {
            CloseNote();
        }
    }

    public void OpenNote()
    {
        noteWriting.SetActive(true);
        noteOpen = true;
        menuCheck.inMenu = true;
    }

    public void CloseNote()
    {
        noteWriting.SetActive(false);
        noteOpen = false;
        menuCheck.inMenu = false;
    }
}
