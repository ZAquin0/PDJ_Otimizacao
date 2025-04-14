using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    [Header("Menu Settings")]
    [SerializeField] private RectTransform pauseHUD;
    [Header("Scene Transition Settings")]
    [SerializeField] private Color transitionColor;
    [Header("Dependency")]
    [SerializeField] private LoadingScreen loadingScreen;
    private bool isPaused = false;
    private void Awake() => isPaused = false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                pauseHUD.gameObject.SetActive(true);
                isPaused = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                pauseHUD.gameObject.SetActive(false);
                isPaused = false;
            }
        }
    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        pauseHUD.gameObject.SetActive(true);
        isPaused = true;
    }
    public void Play()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        pauseHUD.gameObject.SetActive(false);
        isPaused = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(loadingScreen.LoadLevel("MainMenu", transitionColor));
    }
}
