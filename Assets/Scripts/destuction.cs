using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destuction : MonoBehaviour, IInteractable
{
    public GameObject currentlyHeld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Interact()
    {
        if(currentlyHeld.GetComponent<ItemActivate>().select == ItemActivate.Type.Axe)
        {
            gameObject.SetActive(false);
        }
    }
}
