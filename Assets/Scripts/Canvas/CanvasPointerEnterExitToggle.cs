using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasPointerEnterExitToggle : MonoBehaviour
{
    public void Enable(RectTransform transformToScale)
    {
        transformToScale.LeanScale(Vector3.one * 1.3f, 0.1f);
    }
    public void Disable(RectTransform transformToScale)
    {
        transformToScale.LeanScale(Vector3.one, 0.1f);
    }
}
