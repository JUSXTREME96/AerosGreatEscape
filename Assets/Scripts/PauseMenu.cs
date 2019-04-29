using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    

   // Input_Manager player;

    private void Start()
    {
        
       
      
    }
    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown("joystick button 7"))
        {
            if (isPaused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
	}
   public void Continue()
    {
        pauseMenuUI.SetActive(false);
      
        Time.timeScale = 1;
       
        isPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
       
        Time.timeScale = 0;
        
        isPaused = true;
      
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {

        Application.Quit();
        Debug.Log("I have quit");
    }
}
