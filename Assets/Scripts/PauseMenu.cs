using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    //Scripts that you want to stop while game is running go here and under Resume and Pause
    public ArmRotation armStuff;
    public GunStuff gunStuff;


    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        gunStuff.enabled = true;
        armStuff.enabled = true;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        gunStuff.enabled = false;
        armStuff.enabled = false;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
