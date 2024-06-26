using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool gameIsPaused = false;

    [Header("Windows")]
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject settingsWindow;
    private bool WindowOpen = false;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject ngButton, settingsButton;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            CloseSettingsButton();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (WindowOpen == true)
            {
                settingsWindow.SetActive(false);
                eventSystem.SetSelectedGameObject(ngButton);
                WindowOpen = false;
            }
            else
            {
                if (gameIsPaused)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Resume();
                }
                else
                {
                    Paused();
                }
            }
        }
    }
    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        eventSystem.SetSelectedGameObject(ngButton);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void Restart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
        WindowOpen = true;
        eventSystem.SetSelectedGameObject(settingsButton);
    }

    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
        WindowOpen = false;
        eventSystem.SetSelectedGameObject(ngButton);
    }

    public void LoadMenu()
    {
        Resume();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
