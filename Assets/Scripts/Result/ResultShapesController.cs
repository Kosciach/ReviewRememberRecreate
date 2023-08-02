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
        float outlineSizeAccuracy = OutlineSizeAccuracy();

        float individualAccuracy = individualMethods[(int)_rememberShape.settings.shapeType]();

        float accuracy = (scaleAccuracy + fillColorAccuracy + outlineColorAccuracy + shapeTypeAccuracy + outlineSizeAccuracy + individualAccuracy) / 6;
        string accuracyText = "Accuracy: " + accuracy.ToString("F0") + " %";
        _accuracy.text = accuracyText;
    }


    private float ScaleAccuracy()
    {
        return CalculateTwoValuesSimilarity(_recreateShape.transform.localScale.x, _rememberShape.transform.localScale.x);
    }
    private float FillColorAccuracy()
    {
        float deltaE = ColorUtility.CalculateCIEDE2000(_recreateShape.settings.fillColor, _rememberShape.settings.fillColor);
        return (100f - (deltaE / 1.698788f) * 100f);
    }
    private float OutlineColorAccuracy()
    {
        float deltaE = ColorUtility.CalculateCIEDE2000(_recreateShape.settings.outlineColor, _rememberShape.settings.outlineColor);
        return (100f - (deltaE / 1.698788f) * 100f);
    }
    private float ShapeTypeAccuracy()
    {
        return _recreateShape.settings.shapeType == _rememberShape.settings.shapeType ? 100 : 0;
    }
    private float OutlineSizeAccuracy()
    {
        int[] maxOutlineSizesPerScaleOne = { 20, 30, 40, 25 };
        int outlineShapeTypeDiff = Mathf.Abs(maxOutlineSizesPerScaleOne[(int)_rememberShape.settings.shapeType] - maxOutlineSizesPerScaleOne[(int)_recreateShape.settings.shapeType]);

        float rememberOutlineSize = _rememberShape.settings.outlineSize;
        float recreateOutlineSize = _recreateShape.settings.outlineSize;

        if (rememberOutlineSize < recreateOutlineSize) rememberOutlineSize += (outlineShapeTypeDiff / 100);
        else if (recreateOutlineSize < rememberOutlineSize) recreateOutlineSize += (outlineShapeTypeDiff / 100);

        return CalculateTwoValuesSimilarity(rememberOutlineSize, recreateOutlineSize);
    }

    private float EllipseAccuracy()
    {
        float angleAccuracy = CalculateTwoValuesSimilarity(_rememberShape.settings.startAngle, _recreateShape.settings.startAngle);
        float innerCutoutAccuracy = CalculateTwoValuesSimilarity(_rememberShape.settings.innerCutout.x, _recreateShape.settings.innerCutout.x);

        return (angleAccuracy + innerCutoutAccuracy) / 2;
    }
    private float PolygonAccuracy()
    {
        float polygonPresetAccuracy = _recreateShape.settings.polygonPreset == _rememberShape.settings.polygonPreset ? 100 : 0;


        return polygonPresetAccuracy;
    }
    private float RectangleAccuracy()
    {
        float roundnessTLAccuracy = CalculateTwoValuesSimilarity(_rememberShape.settings.roundnessTopLeft, _recreateShape.settings.roundnessTopLeft);
        float roundnessTRAccuracy = CalculateTwoValuesSimilarity(_rememberShape.settings.roundnessTopRight, _recreateShape.settings.roundnessTopRight);
        float roundnessBLAccuracy = CalculateTwoValuesSimilarity(_rememberShape.settings.roundnessBottomLeft, _recreateShape.settings.roundnessBottomLeft);
        float roundnessBRAccuracy = CalculateTwoValuesSimilarity(_rememberShape.settings.roundnessBottomRight, _recreateShape.settings.roundnessBottomRight);

        return (roundnessTLAccuracy + roundnessTRAccuracy + roundnessBLAccuracy + roundnessBRAccuracy) / 4;
    }
    private float TriangleAccuracy()
    {
        float offsetAccuracy = CalculateTwoValuesSimilarity(_rememberShape.settings.triangleOffset, _recreateShape.settings.triangleOffset);

        return offsetAccuracy;
    }



    private float CalculateTwoValuesSimilarity(float topValue, float bottomValue)
    {
        if (topValue == bottomValue) return 100;
        if (topValue > bottomValue)
        {
            float tempSwap = topValue;
            topValue = bottomValue;
            bottomValue = tempSwap;
        }

        return (topValue / bottomValue) * 100;
    }
}