using RememeberShape;
using Shapes2D;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultShapesController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] Shape _rememberShape;
    [SerializeField] Shape _recreateShape;
    [SerializeField] TextMeshProUGUI _accuracy;


    private void Awake()
    {
        CopySettings();
        CalculateAccuracy();
    }


    private void CopySettings()
    {
        _rememberShape.settings = RememberShapeController.Shape.settings;
        _rememberShape.transform.localScale = Vector3.one * RememberShapeController.ShapeScale;

        _recreateShape.settings = RecreateShapeController.Shape.settings;
        _recreateShape.transform.localScale = Vector3.one * RecreateShapeController.ShapeScale;
    }

    private void CalculateAccuracy()
    {
        Func<float>[] individualMethods = new Func<float>[4];
        individualMethods[(int)ShapeType.Ellipse] = EllipseAccuracy;
        individualMethods[(int)ShapeType.Polygon] = PolygonAccuracy;
        individualMethods[(int)ShapeType.Rectangle] = RectangleAccuracy;
        individualMethods[(int)ShapeType.Triangle] = TriangleAccuracy;


        float scaleAccuracy = ScaleAccuracy();
        float fillColorAccuracy = FillColorAccuracy();
        float outlineColorAccuracy = OutlineColorAccuracy();
        float shapeTypeAccuracy = ShapeTypeAccuracy();

        float individualAccuracy = individualMethods[(int)_rememberShape.settings.shapeType]();

        float accuracy = (scaleAccuracy + fillColorAccuracy + outlineColorAccuracy + shapeTypeAccuracy + individualAccuracy) / 5;
        string accuracyText = "Accuracy: " + accuracy.ToString("F0") + " %";
        _accuracy.text = accuracyText;
    }


    private float ScaleAccuracy()
    {
        float a = Mathf.Abs(_rememberShape.transform.localScale.x - _recreateShape.transform.localScale.x);
        return Mathf.Abs(100 - ((a / _rememberShape.transform.localScale.x) * 100));
    }
    private float FillColorAccuracy()
    {
        return Mathf.Abs(ColorUtility.CalculateColorDifference(_recreateShape.settings.fillColor, _rememberShape.settings.fillColor) * 100);
    }
    private float OutlineColorAccuracy()
    {
        return Mathf.Abs(ColorUtility.CalculateColorDifference(_recreateShape.settings.outlineColor, _rememberShape.settings.outlineColor) * 100);
    }
    private float ShapeTypeAccuracy()
    {
        return _recreateShape.settings.shapeType == _rememberShape.settings.shapeType ? 100 : 0;
    }


    private float EllipseAccuracy()
    {
        float a = Mathf.Abs(_rememberShape.settings.outlineSize - _recreateShape.settings.outlineSize);
        float outlineAccuracy = Mathf.Abs(100 - ((a / _rememberShape.settings.outlineSize) * 100));

        a = Mathf.Abs(_rememberShape.settings.startAngle - _recreateShape.settings.startAngle);
        float angleAccuracy = Mathf.Abs(100 - ((a / _rememberShape.settings.startAngle) * 100));

        a = Mathf.Abs(_rememberShape.settings.innerCutout.x - _recreateShape.settings.innerCutout.x);
        float innerCutoutAccuracy = Mathf.Abs(100 - ((a / _rememberShape.settings.innerCutout.x) * 100));


        return (outlineAccuracy + angleAccuracy + innerCutoutAccuracy) / 3;
    }
    private float PolygonAccuracy()
    {
        float a = Mathf.Abs(_rememberShape.settings.outlineSize - _recreateShape.settings.outlineSize);
        float outlineAccuracy = Mathf.Abs(100 - ((a / _rememberShape.settings.outlineSize) * 100));


        float polygonPresetAccuracy = _recreateShape.settings.polygonPreset == _rememberShape.settings.polygonPreset ? 100 : 0;


        return (outlineAccuracy + polygonPresetAccuracy) / 2;
    }
    private float RectangleAccuracy()
    {
        float a = Mathf.Abs(_rememberShape.settings.outlineSize - _recreateShape.settings.outlineSize);
        float outlineAccuracy = Mathf.Abs(100 - ((a / _rememberShape.settings.outlineSize) * 100));

        a = Mathf.Abs(_rememberShape.settings.roundnessTopLeft - _recreateShape.settings.roundnessTopLeft);
        float roundnessTLAccuracy = Mathf.Abs(100 - ((a / _rememberShape.settings.roundnessTopLeft) * 100));

        a = Mathf.Abs(_rememberShape.settings.roundnessTopRight - _recreateShape.settings.roundnessTopRight);
        float roundnessTRAccuracy = Mathf.Abs(100 - ((a / _rememberShape.settings.roundnessTopRight) * 100));

        a = Mathf.Abs(_rememberShape.settings.roundnessBottomLeft - _recreateShape.settings.roundnessBottomLeft);
        float roundnessBLAccuracy = Mathf.Abs(100 - ((a / _rememberShape.settings.roundnessBottomLeft) * 100));

        a = Mathf.Abs(_rememberShape.settings.roundnessBottomRight - _recreateShape.settings.roundnessBottomRight);
        float roundnessBRAccuracy = Mathf.Abs(100 - ((a / _rememberShape.settings.roundnessBottomRight) * 100));


        return (outlineAccuracy + roundnessTLAccuracy + roundnessTRAccuracy + roundnessBLAccuracy + roundnessBRAccuracy) / 5;
    }
    private float TriangleAccuracy()
    {
        float a = Mathf.Abs(_rememberShape.settings.outlineSize - _recreateShape.settings.outlineSize);
        float outlineAccuracy = Mathf.Abs(100 - ((a / _rememberShape.settings.outlineSize) * 100));

        a = Mathf.Abs(_rememberShape.settings.triangleOffset - _recreateShape.settings.triangleOffset);
        float offsetAccuracy = Mathf.Abs(100 - ((a / _rememberShape.settings.triangleOffset) * 100));


        return (outlineAccuracy + offsetAccuracy) / 2;
    }
}
