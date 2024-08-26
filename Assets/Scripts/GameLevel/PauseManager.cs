﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }


    public void ContinueGame()
    {
        pausePanel.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
