using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryMenu : MonoBehaviour
{
    public GameObject invMenuObj;
    public static bool invOpen;

    // Start is called before the first frame update
    void Start()
    {
        invMenuObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!pauseMenu.isPaused)
        {
            if(Input.GetButtonDown("Inv") || Input.GetKeyDown(KeyCode.Escape))
            {
                if(invOpen)
                {
                    CloseInv();
                }
            }
            if(Input.GetButtonDown("Inv"))
            {
                if(!invOpen)
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
}
