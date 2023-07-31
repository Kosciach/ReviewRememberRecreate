using RememeberShape;
using SimpleMan.CoroutineExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecreateSceneController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] CanvasFadeController _fadeController;


    public void Continue()
    {
        _fadeController.ToggleBlocksRaycasts(true);
        _fadeController.ToggleInteractable(true);
        _fadeController.Toggle(true, 0.5f);
        this.Delay(0.5f, () =>
        {
            SceneChanger.Instance.ChangeScene(SceneChanger.SceneNames.Results);
        });
    }
}
