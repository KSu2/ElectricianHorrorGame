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

    // Update is called once per frame
    void Update()
    {
        //There's gotta be a better way to do this
        if(!pauseMenu.isPaused)
        {
            if(!inventoryMenu.invOpen)
            {
            if (Input.GetButtonDown("Fire1"))
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
    }
}
