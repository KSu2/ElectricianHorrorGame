using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuObj;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!inventoryMenu.invOpen)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        }   
    }

    public void PauseGame()
    {
        pauseMenuObj.SetActive(true);
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        if(boxActivate.boxOn)
        {
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        pauseMenuObj.SetActive(false);   
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        if(boxActivate.boxOn)
        {
            Time.timeScale = 1f;
        }
    }
}
