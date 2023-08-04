using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasPointerEnterExitControll : MonoBehaviour
{
    public void EnterScale(PointerEnterExitScaleParameters parameters)
    {
        parameters.Transform.LeanScale(Vector3.one * parameters.EnterScale, 0.1f);
    }
    public void ExitScale(PointerEnterExitScaleParameters parameters)
    {
        parameters.Transform.LeanScale(Vector3.one * parameters.ExitScale, 0.1f);
    }


    public void EnterPosY(RectTransform transform)
    {
        LeanTween.value(transform.localPosition.y, -20, 0.1f).setOnUpdate((float val) =>
        {
            transform.localPosition = new Vector3(0, val, 0);
        });
    }
    public void ExitPosY(RectTransform transform)
    {
        LeanTween.value(transform.localPosition.y, 0, 0.1f).setOnUpdate((float val) =>
        {
            transform.localPosition = new Vector3(0, val, 0);
        });
    }
}
