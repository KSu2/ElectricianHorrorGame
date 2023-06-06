using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemActivate : MonoBehaviour, IInteractable
{
    public int hi;
    //determine the item type
    public enum Type { None = 0, health };
    public Type select;
   
    public inventoryMenu inv;

    public void Interact()
    {
        //the inventory slots should fill up sequentially, so first 1 then 2 then 3
        //first check if the inventory is full

        if (select == Type.health && inv.updateText("health"))
        {
            Debug.Log("selected health item");
            gameObject.SetActive(false);
        }
    }
}
