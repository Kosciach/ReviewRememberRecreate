using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecreateShapeController : MonoBehaviour
{
    [Header("====Header====")]
    [SerializeField] RecreateCanvasController _canvasController;
    private static Shape _shape; public static Shape Shape { get { return _shape; } }
    private static float _shapeScale; public static float ShapeScale { get { return _shapeScale; } }



    private void Awake()
    {
        _shape = transform.GetChild(0).GetComponent<Shape>();
        _shapeScale = 3;
    }



    public void ChangeShapeType(bool increment)
    {
        int currentShapeTypeInt = (int)_shape.settings.shapeType;
        currentShapeTypeInt += (increment ? 1 : -1);

        if (currentShapeTypeInt < 0) currentShapeTypeInt = 3;
        else if (currentShapeTypeInt > 3) currentShapeTypeInt = 0;

        _shape.settings.shapeType = (ShapeType)currentShapeTypeInt;

        _canvasController.UpdateShapeType(_shape.settings.shapeType);
    }

    public void ChangeScale(Slider slider)
    {
        _shape.transform.localScale = Vector3.one * slider.value;
        _shapeScale = _shape.transform.localScale.x;
    }

    public void ChangeFillColorRed(Slider slider)
    {
        _shape.settings.fillColor = new Color(slider.value, _shape.settings.fillColor.g, _shape.settings.fillColor.b, 1);
    }
    public void ChangeFillColorGreen(Slider slider)
    {
        _shape.settings.fillColor = new Color(_shape.settings.fillColor.r, slider.value, _shape.settings.fillColor.b, 1);
    }
    public void ChangeFillColorBlue(Slider slider)
    {
        _shape.settings.fillColor = new Color(_shape.settings.fillColor.r, _shape.settings.fillColor.g, slider.value, 1);
    }

    public void ChangeOutlineColorRed(Slider slider)
    {
        _shape.settings.outlineColor = new Color(slider.value, _shape.settings.outlineColor.g, _shape.settings.outlineColor.b, 1);
    }
    public void ChangeOutlineColorGreen(Slider slider)
    {
        _shape.settings.outlineColor = new Color(_shape.settings.outlineColor.r, slider.value, _shape.settings.outlineColor.b, 1);
    }
    public void ChangeOutlineColorBlue(Slider slider)
    {
        _shape.settings.outlineColor = new Color(_shape.settings.outlineColor.r, _shape.settings.outlineColor.g, slider.value, 1);
    }



    public void ChangeEllipseOutline(Slider slider)
    {
        float outlineSize = slider.value;
        outlineSize /= 100;
        _shape.settings.outlineSize = outlineSize * _shape.transform.localScale.x;

        if (_shape.settings.innerCutout.x > 0) _shape.settings.outlineSize /= 2;
    }
    public void ChangeEllipseAngle(Slider slider)
    {
        _shape.settings.startAngle = slider.value;
        _shape.settings.endAngle = 0;
    }
    public void ChangeEllipseInnerCutout(Slider slider)
    {
        _shape.settings.innerCutout = Vector2.one * slider.value;
    }



    public void ChangePolygonOutline(Slider slider)
    {
        float outlineSize = slider.value;
        outlineSize /= 100;
        _shape.settings.outlineSize = outlineSize * _shape.transform.localScale.x;
    }
    public void ChangePolygonPreset(bool increment)
    {
        int currentPolygonPresetInt = (int)_shape.settings.polygonPreset;
        currentPolygonPresetInt += (increment ? 1 : -1);

        if (currentPolygonPresetInt < 2) currentPolygonPresetInt = 10;
        else if (currentPolygonPresetInt > 10) currentPolygonPresetInt = 2;

        _shape.settings.polygonPreset = (PolygonPreset)currentPolygonPresetInt;

        _canvasController.UpdatePolygonPreset(_shape.settings.polygonPreset);
    }



    public void ChangeRectangleOutline(Slider slider)
    {
        float outlineSize = slider.value;
        outlineSize /= 100;
        _shape.settings.outlineSize = outlineSize * _shape.transform.localScale.x;
    }
    public void ChangeRectangleRoundnessTL(Slider slider)
    {
        _shape.settings.roundnessTopLeft = slider.value;
    }
    public void ChangeRectangleRoundnessTR(Slider slider)
    {
        _shape.settings.roundnessTopRight = slider.value;
    }
    public void ChangeRectangleRoundnessBL(Slider slider)
    {
        _shape.settings.roundnessBottomLeft = slider.value;
    }
    public void ChangeRectangleRoundnessBR(Slider slider)
    {
        _shape.settings.roundnessBottomRight = slider.value;
    }



    public void ChangeTriangleOutline(Slider slider)
    {
        _shape.settings.outlineSize = slider.value * _shape.transform.localScale.x;
    }
    public void ChangeTriangleOffset(Slider slider)
    {
        _shape.settings.triangleOffset = slider.value;
    }
}
