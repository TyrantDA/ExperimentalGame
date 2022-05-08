using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuBackerIU;
    public GameObject ControlBackerIU;
    public GameObject MapBackerIU;

    public static bool isPaused = false;
    public static bool controlOn = false;
    public static bool mapOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ResumeGame()
    {
        PauseMenuBackerIU.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        ControlBackerIU.SetActive(false);
        controlOn = false;
    }

    void PauseGAme()
    {
        PauseMenuBackerIU.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void QuitGameToDesktop()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Controls()
    {
        if(!controlOn)
        {
            ControlBackerIU.SetActive(true);
            controlOn = true;
        }
        else
        {
            ControlBackerIU.SetActive(false);
            controlOn = false;
        }

        
    }

    public void Map()
    {
        if (!mapOn)
        {
            MapBackerIU.SetActive(true);
            mapOn = true;
        }
        else
        {
            MapBackerIU.SetActive(false);
            mapOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGAme();
            }
        }
    }
}
