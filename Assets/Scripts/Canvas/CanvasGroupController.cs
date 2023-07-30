using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupController : MonoBehaviour
{
    private CanvasGroup _canvasGroup;


    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }


    public void ToggleAlpha(bool enable)
    {
        int weight = enable ? 1 : 0;
        LeanTween.alphaCanvas(_canvasGroup, weight, 1f);
    }
    public void ToggleAlpha(bool enable, float time)
    {
        int weight = enable ? 1 : 0;
        LeanTween.alphaCanvas(_canvasGroup, weight, time);
    }

    public void ToggleBlocksRaycasts(bool enable)
    {
        _canvasGroup.blocksRaycasts = enable;
    }
    public void ToggleInteractable(bool enable)
    {
        _canvasGroup.interactable = enable;
    }
}
