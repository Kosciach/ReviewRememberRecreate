using SimpleMan.CoroutineExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsSceneController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] CanvasFadeController _fadeController;
    [SerializeField] Image _timerImage;


    private void Awake()
    {
        this.Delay(0.5f, () =>
        {
            this.Delay(3.9f, () => { _timerImage.rectTransform.LeanScaleY(0.58f, 0.05f); });

            _timerImage.rectTransform.LeanScaleX(0, 4).setOnComplete(() =>
            {
                _fadeController.Toggle(true, 0.5f);
                this.Delay(0.5f, () => { SceneChanger.Instance.ChangeScene(SceneChanger.SceneNames.MainMenu); });
            });
        });
    }
}
