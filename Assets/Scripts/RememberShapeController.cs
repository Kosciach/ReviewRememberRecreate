using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RememeberShape
{
    public class RememberShapeController : MonoBehaviour
    {
        private static Shape _shape; public static Shape Shape { get { return _shape; } }
        private BaseRememberShapeSetupController[] _shapeSetups;
        private bool _areColorsSimilar;


        private void Awake()
        {
            _shape = transform.GetChild(0).GetComponent<Shape>();
            _shapeSetups = new BaseRememberShapeSetupController[4];
            _shapeSetups[(int)ShapeType.Ellipse] = new RememberShapeSetup_Ellipse(_shape);
            _shapeSetups[(int)ShapeType.Polygon] = new RememberShapeSetup_Ellipse(_shape);
            _shapeSetups[(int)ShapeType.Rectangle] = new RememberShapeSetup_Ellipse(_shape);
            _shapeSetups[(int)ShapeType.Triangle] = new RememberShapeSetup_Ellipse(_shape);

            SetBasicValues();
            CheckColorSimilarity();

            _shapeSetups[(int)_shape.settings.shapeType].Setup();


            if (!_areColorsSimilar) return;

            _shape.settings.outlineSize = 0;
        }


        private void SetBasicValues()
        {
            _shape.settings.shapeType = (ShapeType)Random.Range(0, System.Enum.GetValues(typeof(ShapeType)).Length - 1);

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
    }




    public abstract class BaseRememberShapeSetupController
    {
        protected Shape _shape;

        public BaseRememberShapeSetupController(Shape shape)
        {
            _shape = shape;
        }


        public abstract void Setup();
    }


    public class RememberShapeSetup_Ellipse : BaseRememberShapeSetupController
    {
        public RememberShapeSetup_Ellipse(Shape shape) : base(shape) { }


        public override void Setup()
        {
            _shape.settings.startAngle = Random.Range(180, 360);
            _shape.settings.endAngle = 0;

            _shape.settings.innerCutout = Vector2.one * Random.Range(0f, 0.5f);

            _shape.settings.outlineSize = Random.Range(0.05f, 0.5f / 2) * _shape.transform.localScale.x * (_shape.settings.innerCutout.x);
        }
    }
    public class RememberShapeSetup_Polygon : BaseRememberShapeSetupController
    {
        public RememberShapeSetup_Polygon(Shape shape) : base(shape) { }


        public override void Setup()
        {
            _shape.settings.polygonPreset = (PolygonPreset)(Random.Range(0, 10) + 2);

            _shape.settings.outlineSize = Random.Range(0.05f, 0.5f / 2) * _shape.transform.localScale.x;
        }
    }
    public class RememberShapeSetup_Rectangle : BaseRememberShapeSetupController
    {
        public RememberShapeSetup_Rectangle(Shape shape) : base(shape) { }


        public override void Setup()
        {
            _shape.settings.roundness = Random.Range(0f, 0.8f);

            _shape.settings.outlineSize = Random.Range(0.05f, 0.5f / 2) * _shape.transform.localScale.x;
        }
    }
    public class RememberShapeSetup_Triangle : BaseRememberShapeSetupController
    {
        public RememberShapeSetup_Triangle(Shape shape) : base(shape) { }


        public override void Setup()
        {
            _shape.settings.triangleOffset = Random.Range(0f, 1f);

            _shape.settings.outlineSize = Random.Range(0.05f, 0.31f / 2) * _shape.transform.localScale.x;
        }
    }
}