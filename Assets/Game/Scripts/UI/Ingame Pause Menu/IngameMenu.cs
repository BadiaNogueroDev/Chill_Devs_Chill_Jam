﻿using FMODUnity;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class IngameMenu : MonoBehaviour
{
    public CanvasFade BlackScreen;
    protected CanvasGroup canvasGroup;
    [SerializeField] private StudioEventEmitter menuSound;

    protected void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void ShowMenu()
    {
        GetComponent<CanvasFade>().FadeIn();
        Time.timeScale = 0f;
        menuSound?.Play();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        BlackScreen.FadeIn(() => SceneManager.LoadScene("MainMenu"));
    }

    public void QuitGame()
    {
        BlackScreen.FadeIn(() => Application.Quit());
    }
}
