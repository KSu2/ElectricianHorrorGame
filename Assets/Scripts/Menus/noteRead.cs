using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteRead : MonoBehaviour, IInteractable
{
    public GameObject note;
    public GameObject noteWriting;
    public GameObject noteList;
    public GameObject player;
    public static bool noteOpen;
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
        if(distance > maxDis || Input.GetKeyDown(KeyCode.Escape))
        {
            CloseNote();
        }
    }

    public void Interact() 
    {
        if(!noteOpen)
        {
            for(int i = 0; i< noteList.transform.childCount; i++)
            {
                var child = noteList.transform.GetChild(i).gameObject;
                if (child != null)
                {
                    child.SetActive(false);
                }
            }
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
    }

    public void CloseNote()
    {
        noteWriting.SetActive(false);
        noteOpen = false;
    }
}
