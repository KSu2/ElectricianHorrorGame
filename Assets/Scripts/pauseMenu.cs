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
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        pauseMenuObj.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
