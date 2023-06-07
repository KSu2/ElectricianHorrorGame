using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemActivate : MonoBehaviour, IInteractable
{
    //determine the item type
    public enum Type { None = 0, Medkit, Lantern, Type3, Type4 };
    public Type select;

    public GameObject player;
    public inventoryMenu inv;

    public void Start()
    {
        player = GameObject.Find("firstPersonPlayer");
        inv = player.GetComponent<inventoryMenu>();
    }

    public void Interact()
    {
        //the inventory slots should fill up sequentially, so first 1 then 2 then 3
        //first check if the inventory is full

        if (select == Type.Medkit && inv.updateText("Medkit"))
        {
            Debug.Log("selected health item");
            gameObject.SetActive(false);
        }
        else if (select == Type.Lantern && inv.updateText("Lantern"))
        {
            Debug.Log("selected Type 2");
            gameObject.SetActive(false);
        } 
        else if (select == Type.Type3 && inv.updateText("Type3"))
        {
            Debug.Log("selected Type 3");
            gameObject.SetActive(false);
        }
    }
}
