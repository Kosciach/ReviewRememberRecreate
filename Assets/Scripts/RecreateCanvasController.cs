using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecreateCanvasController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] TextMeshProUGUI _shapeTypeName;


    public void UpdateShapeTypeName(ShapeType shapeType)
    {
        _shapeTypeName.text = shapeType.ToString();
    }
}
