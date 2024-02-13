using FMODUnity;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameOverMenu : IngameMenu
{
    private DepthOfField depthOfField;
    [SerializeField] private VolumeProfile volumeProfile;
    public StudioEventEmitter HoverSoundRef;
    public StudioEventEmitter ClickSoundRef;
    
    public void RestartScene()
    {
        BlackScreen.FadeIn(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }
    
    private void OnEnable()
    {
        DepthOfField tmp;
        
        if (volumeProfile.TryGet<DepthOfField>(out tmp))
        {
            depthOfField = tmp;
        }

        depthOfField.active = false;
    }

    private void OnDisable()
    {
        depthOfField.active = false;
    }

    public override void ShowMenu()
    {
        base.ShowMenu();

        var playerInput = FindObjectOfType<PlayerInput>();
        Destroy(playerInput.GetComponent<PauseMenuInputs>());

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        playerInput.actions.FindActionMap("Player").Disable();
        playerInput.actions.FindActionMap("UI").Enable();
    }

    public void PlayHoverSound()
    {
        HoverSoundRef.Play();
    }

    public void PlayClickSound()
    {
        ClickSoundRef.Play();
    }
}