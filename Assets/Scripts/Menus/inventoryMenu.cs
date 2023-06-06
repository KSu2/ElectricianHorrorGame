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
    public bool[] isOpen;
    public GameObject[] slots;

    public static bool invOpen;

    public GameObject holdable;


    // Start is called before the first frame update
    void Start()
    {
        invMenuObj.SetActive(false);
        holdable.SetActive(false);
        isOpen = new bool[] { true, true, true };
        slots = new GameObject[] { slot1, slot2, slot3 };
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu.isPaused)
        {
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

    public bool updateText(string text)
    {
        int next = nextAvail();
        if(invCount > 2)
        {
            //eventually change this to a message that pops on screen
            Debug.Log("Inventory Full");
            return false;
        }
        else
        {
            slots[next].GetComponent<TextMeshProUGUI>().text = text;
            isOpen[next] = false;
            invCount++;
            return true;
        }
    }

    //helper function to get the index of the next available inventory slot
    public int nextAvail()
    {
        for(int x = 0; x < 3; x++)
        {
            if (isOpen[x])
            {
                return x;
            }
        }
        return -1;
    }

    //remove item at the specified slot #
    //decrement the invCount
    //change player model
    public void equipItem(int slot)
    {
        Debug.Log("slot: " + slot);
        if (!isOpen[slot])
        {
            holdable.SetActive(true);
            invCount--;
        }
        isOpen[slot] = true;
        //set the text of the corresponding slot to "Empty"
        slots[slot].GetComponent<TextMeshProUGUI>().text = "Empty";


        //show item on player model
        //Don't know how to do this
        //maybe spawn item at position which is visible to player hands
        //need to add the object instace to the player model
        
    }
}
