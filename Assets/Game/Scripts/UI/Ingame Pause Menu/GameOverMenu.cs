using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameOverMenu : IngameMenu
{
    public void RestartScene()
    {
        BlackScreen.FadeIn(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }
}
