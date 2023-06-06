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
    public GameObject holdable;

    // Update is called once per frame
    void Update()
    {
        //There's gotta be a better way to do this
        //check if the inventory menu and the pause menu is not open
        if(!inventoryMenu.invOpen && !pauseMenu.isPaused)
        {
            //check if HoldableItem is active 
            //GameObject.activeInHierarchy
            if (holdable.activeInHierarchy)
            {
                //left click use item
                if (Input.GetButtonDown("Fire1"))
                {
                    //the holdableItem
                    Debug.Log("left click!");
                    useItem();
                    holdable.SetActive(false);
                } 
                //right click drop item
                else if (Input.GetButtonDown("Fire2"))
                {
                    Debug.Log("right click!");
                    dropItem();
                    holdable.SetActive(false);
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
            }
        } 
    }

    public void useItem()
    {
        //check what type of item is currently equipped
        if(holdable.GetComponent<ItemActivate>().select == ItemActivate.Type.health)
        {
            Debug.Log("we have used a health item");
        }
    }

    public void dropItem()
    {
        //create an instance of the item on the ground with the same material as the holdable item
        

        //change this to simply moving the item to the position and setting it to active
        //this will make it so we don't have to duplicate item GameObjects in the scene which may slow down the performance
        Vector3 pos = new Vector3(gameObject.transform.position.x + 5, 0, gameObject.transform.position.z);
        GameObject clone = Instantiate(holdable, pos, Quaternion.identity);
    }

}
