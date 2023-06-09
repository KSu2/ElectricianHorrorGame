using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable{
    public void Interact();
}

public class interactor : MonoBehaviour
{
    public Transform intSource;
    public float intRange;
    public Transform holdable;
    public GameObject player;
    public inventoryMenu inv;
    public Material brightMat;
    public Material darkMat;
    public GameObject lanternItem;
    public Transform droppedItems;
    public LayerMask destMask;

    void Start()
    {
        player = GameObject.Find("firstPersonPlayer");
        inv = player.GetComponent<inventoryMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if the inventory menu and the pause menu is not open
        if(!inventoryMenu.invOpen && !pauseMenu.isPaused)
        {
            //check if HoldableItem is active 
            //GameObject.activeInHierarchy
            if (holdable.childCount > 0)
            {
                //left click use item
                if (Input.GetButtonDown("Fire1"))
                {
                    //the holdableItem
                    Debug.Log("left click!");
                    useItem();
                } 
                //right click drop item
                else if (Input.GetButtonDown("Fire2"))
                {
                    Debug.Log("right click!");
                    dropItem();
                    //holdable.SetActive(false);
                    Destroy(holdable.transform.GetChild(0).gameObject);
                }
                //middle click re-equip the item
                else if (Input.GetButtonDown("Fire3"))
                {
                    Debug.Log("middle click!");
                    inv.unequipItem();
                }
            }
            //if left click is pushed but we are not holding an item
            else if (Input.GetButtonDown("Fire1"))
            {
                Ray r = new Ray(intSource.position, intSource.forward);
                if (Physics.Raycast(r, out RaycastHit hitInfo, intRange))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                    {
                        interactObj.Interact();
                    }
                }
                for(int i = 0; i< droppedItems.transform.childCount; i++)
                {
                    var child = droppedItems.transform.GetChild(i).gameObject;
                    if(!child.activeSelf)
                    {
                        Destroy(child);
                    }
                }
            }
        } 
    }

    public void useItem()
    {
        //check what type of item is currently equipped
        if(holdable.GetComponent<ItemActivate>().select == ItemActivate.Type.Medkit)
        {
            Debug.Log("we have used a health item");
            //Health item functionality
            float currentHealth = player.GetComponent<playerHealth>().health;
            float maxHP = player.GetComponent<playerHealth>().maxHealth;
            if(currentHealth < maxHP)
            {
                player.GetComponent<playerHealth>().health = player.GetComponent<playerHealth>().health + 3f;
                //holdable.SetActive(false);
                Destroy(holdable.transform.GetChild(0).gameObject);
                holdable.GetComponent<ItemActivate>().select= ItemActivate.Type.None;
            }   
        }
        else if(holdable.GetComponent<ItemActivate>().select == ItemActivate.Type.Lantern)
        {
            Debug.Log("we have used a Lantern item");
        }
        else if(holdable.GetComponent<ItemActivate>().select == ItemActivate.Type.Axe)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Ray r = new Ray(intSource.position, intSource.forward);
                if (Physics.Raycast(r, out RaycastHit hitInfo, intRange, destMask))
                {
                    Debug.Log("we have used a Type3 item");
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                    {
                        interactObj.Interact();
                        Destroy(holdable.transform.GetChild(0).gameObject);
                        holdable.GetComponent<ItemActivate>().select= ItemActivate.Type.None;
                    }
                }
            }
        }
    }

    public void dropItem()
    {
        //create an instance of the item on the ground with the same material as the holdable item
        
        //change this to simply moving the item to the position and setting it to active
        //this will make it so we don't have to duplicate item GameObjects in the scene which may slow down the performance
        //Vector3 pos = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z + 5);
        
        GameObject clone = Instantiate(holdable.transform.GetChild(0).gameObject, gameObject.transform.position + gameObject.transform.forward * 5, Quaternion.identity);
        clone.transform.SetParent(droppedItems);
        holdable.GetComponent<ItemActivate>().select= ItemActivate.Type.None;

    }

}
