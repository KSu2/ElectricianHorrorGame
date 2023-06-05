using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inventoryMenu : MonoBehaviour
{
    public GameObject invMenuObj;
    [SerializeField] public GameObject slot1;
    [SerializeField] public GameObject slot2;
    [SerializeField] public GameObject slot3;

    //index representing the next inventory position
    public int invCount = 0;

    public static bool invOpen;

    // Start is called before the first frame update
    void Start()
    {
        invMenuObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu.isPaused)
        {

        }
        if (Input.GetButtonDown("Inv"))
        {
            if (invOpen)
            {
                CloseInv();
            }
            else
            {
                OpenInv();
            }
        }
    }

    public void OpenInv()
    {
        invMenuObj.SetActive(true);
        invOpen = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseInv()
    {
        invMenuObj.SetActive(false);
        invOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void updateText(string text)
    {
        if(invCount > 2)
        {
            //eventually change this to a message that pops on screen
            Debug.Log("Inventory Full");
        }
        else if (invCount == 0)
        {
            Debug.Log("text: " + slot1.GetComponent<TextMeshProUGUI>().text);
            slot1.GetComponent<TextMeshProUGUI>().text = text;
            invCount++;
        }
        else if (invCount == 1)
        {
            slot2.GetComponent<TextMeshProUGUI>().text = text;
            invCount++;
        }
        else if (invCount == 2)
        {
            slot3.GetComponent<TextMeshProUGUI>().text = text;
            invCount++;
        }
        else
        {
            Debug.Log("ERROR: trying to access an inv slot number that doesn't exist");
        }

    }
}
