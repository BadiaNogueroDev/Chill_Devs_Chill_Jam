using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuInputs : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private SettingsPauseMenu pauseMenu;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        playerInput.actions.FindActionMap("Player").Enable();
        playerInput.actions.FindActionMap("UI").Disable();
    }

    void OnIngameMenu()
    {
        if(pauseMenu.IsPaused)
            pauseMenu.Continue();
        else
            pauseMenu.PauseGame();
    }
    
    void OnDismiss()
    {
        pauseMenu.Continue();
    }
}