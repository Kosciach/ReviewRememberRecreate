using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RememeberShape
{
    public class RememberShapeController : MonoBehaviour
    {
        private static Shape _shape; public static Shape Shape { get { return _shape; } }
        private static float _shapeScale; public static float ShapeScale { get { return _shapeScale; } }
        private bool _areColorsSimilar;


        private void Awake()
        {
            _shape = transform.GetChild(0).GetComponent<Shape>();
            System.Action[] individualSetups = new System.Action[4];
            individualSetups[(int)ShapeType.Ellipse] = EllipseSetup;
            individualSetups[(int)ShapeType.Polygon] = PolygonSetup;
            individualSetups[(int)ShapeType.Rectangle] = RectangleSetup;
            individualSetups[(int)ShapeType.Triangle] = TriangleSetup;

            SetBasicValues();
            CheckColorSimilarity();

            individualSetups[(int)_shape.settings.shapeType]();


            if (!_areColorsSimilar) return;

            _shape.settings.outlineSize = 0;
        }


        private void SetBasicValues()
        {
            //_shape.settings.shapeType = (ShapeType)Random.Range(0, System.Enum.GetValues(typeof(ShapeType)).Length - 1);
            _shape.settings.shapeType = ShapeType.Ellipse;


            float red = Random.Range(0f, 1f);
            float green = Random.Range(0f, 1f);
            float blue = Random.Range(0f, 1f);
            _shape.settings.fillColor = new Color(red, green, blue);

            red = Random.Range(0f, 1f);
            green = Random.Range(0f, 1f);
            blue = Random.Range(0f, 1f);
            _shape.settings.outlineColor = new Color(red, green, blue);


            float scale = Random.Range(1f, 6f);
            _shape.transform.localScale = Vector3.one * scale;
            _shapeScale = _shape.transform.localScale.x;
        }
        private void CheckColorSimilarity()
        {
            float redDiff = _shape.settings.fillColor.r - _shape.settings.outlineColor.r;
            redDiff = Mathf.Abs(redDiff);

            float greenDiff = _shape.settings.fillColor.g - _shape.settings.outlineColor.g;
            greenDiff = Mathf.Abs(greenDiff);

            float blueDiff = _shape.settings.fillColor.b - _shape.settings.outlineColor.b;
            blueDiff = Mathf.Abs(blueDiff);

            float diff = new Vector3(redDiff, greenDiff, blueDiff).magnitude;
            _areColorsSimilar = diff <= 0.2f;
        }



        private void EllipseSetup()
        {
            _shape.settings.startAngle = Random.Range(180, 360);
            _shape.settings.endAngle = 0;

            _shape.settings.innerCutout = Vector2.one * Random.Range(0, 5) / 10;


            float outlineSize = Random.Range(0, 24);
            outlineSize /= 100;
            _shape.settings.outlineSize = outlineSize * _shape.transform.localScale.x;

            if (_shape.settings.innerCutout.x > 0) _shape.settings.outlineSize /= 2;
        }
        private void PolygonSetup()
        {
            _shape.settings.polygonPreset = (PolygonPreset)(Random.Range(2, 11));


            float outlineSize = Random.Range(5, 30);
            outlineSize /= 100;
            _shape.settings.outlineSize = outlineSize * _shape.transform.localScale.x;
        }
        private void RectangleSetup()
        {
            _shape.settings.roundnessPerCorner = true;

            _shape.settings.roundnessTopLeft = Random.Range(0f, 0.8f);
            _shape.settings.roundnessTopLeft = Mathf.Round(_shape.settings.roundnessTopLeft * Mathf.Pow(10, 2)) / Mathf.Pow(10, 2);

            _shape.settings.roundnessTopRight = Random.Range(0f, 0.8f);
            _shape.settings.roundnessTopRight = Mathf.Round(_shape.settings.roundnessTopRight * Mathf.Pow(10, 2)) / Mathf.Pow(10, 2);

            _shape.settings.roundnessBottomLeft = Random.Range(0f, 0.8f);
            _shape.settings.roundnessBottomLeft = Mathf.Round(_shape.settings.roundnessBottomLeft * Mathf.Pow(10, 2)) / Mathf.Pow(10, 2);

            _shape.settings.roundnessBottomRight = Random.Range(0f, 0.8f);
            _shape.settings.roundnessBottomRight = Mathf.Round(_shape.settings.roundnessBottomRight * Mathf.Pow(10, 2)) / Mathf.Pow(10, 2);


            float outlineSize = Random.Range(5, 45);
            outlineSize /= 100;
            _shape.settings.outlineSize = outlineSize * _shape.transform.localScale.x;
        }
        private void TriangleSetup()
        {
            _shape.settings.triangleOffset = Random.Range(0f, 1f);
            _shape.settings.triangleOffset = Mathf.Round(_shape.settings.triangleOffset * Mathf.Pow(10, 2)) / Mathf.Pow(10, 2);

            float outlineSize = Random.Range(0, 30);
            outlineSize /= 100;
            _shape.settings.outlineSize = outlineSize * _shape.transform.localScale.x;
        }
    }
}