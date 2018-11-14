using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject pausePanel;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(2);
    }


    public void Quit()
    {
        Debug.Log("Ends the game application");
        Application.Quit();
    }

    public void Pause()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 0)
        {
            return;
        }


        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
