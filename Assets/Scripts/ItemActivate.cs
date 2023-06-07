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
        inv.updateText(select);
        gameObject.SetActive(false);
    }
}
