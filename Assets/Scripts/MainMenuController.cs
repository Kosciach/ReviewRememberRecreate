using SimpleMan.CoroutineExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] CanvasFadeController _fadeController;

    public void StartGame()
    {
        float fadeDuration = 0.5f;
        _fadeController.Toggle(true, fadeDuration);
        this.Delay(fadeDuration, () =>
        {
            SceneChanger.Instance.ChangeScene(SceneChanger.SceneNames.Main);
        });
    }
    public void ExitGame()
    {
        float fadeDuration = 0.5f;
        _fadeController.Toggle(true, fadeDuration);
        this.Delay(fadeDuration, () =>
        {
            Application.Quit();
        });
    }
}
