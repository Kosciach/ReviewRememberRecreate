using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecreateShapeController : MonoBehaviour
{
    [Header("====Header====")]
    [SerializeField] RecreateCanvasController _canvasController;
    private static Shape _shape; public static Shape Shape { get { return _shape; } }



    private void Awake()
    {
        _shape = transform.GetChild(0).GetComponent<Shape>();
    }



    public void ChangeShapeType(bool increment)
    {
        int currentShapeTypeInt = (int)_shape.settings.shapeType;
        currentShapeTypeInt += (increment ? 1 : -1);

        if (currentShapeTypeInt < 0) currentShapeTypeInt = 3;
        else if (currentShapeTypeInt > 3) currentShapeTypeInt = 0;

        _shape.settings.shapeType = (ShapeType)currentShapeTypeInt;

        _canvasController.UpdateShapeTypeName(_shape.settings.shapeType);
    }
}
