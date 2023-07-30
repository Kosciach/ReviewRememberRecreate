using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasFadeController : MonoBehaviour
{
    private CanvasGroup _canvasGroup;


    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        Toggle(false, 0.5f);
    }

    public void Toggle(bool enable, float time)
    {
        int weight = enable ? 1 : 0;

        LeanTween.alphaCanvas(_canvasGroup, weight, time).setEaseInOutCubic().setOnComplete(() =>
        {
            _canvasGroup.interactable = enable;
            _canvasGroup.blocksRaycasts = enable;
        });
    }
}
