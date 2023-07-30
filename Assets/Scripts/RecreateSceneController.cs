using RememeberShape;
using SimpleMan.CoroutineExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecreateSceneController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] CanvasFadeController _fadeController;

    private void Awake()
    {
        _fadeController.Toggle(false, 0.5f);
    }
}
