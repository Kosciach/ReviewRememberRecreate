using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BackgroundShape
{
    public class BackgroundShapeController : MonoBehaviour
    {
        private Shape _shape;
        private BaseBackgroundShapeSetupController[] _shapeSetups;
        private ShapeType _shapeType;
        private float _moveSpeed;
        private float _rotationSpeed;



        private void Awake()
        {
            _shape = GetComponent<Shape>();

            _shapeSetups = new BaseBackgroundShapeSetupController[4];
            _shapeSetups[(int)ShapeType.Ellipse] = new BackgroundShapeSetup_Ellipse(_shape);
            _shapeSetups[(int)ShapeType.Polygon] = new BackgroundShapeSetup_Polygon(_shape);
            _shapeSetups[(int)ShapeType.Rectangle] = new BackgroundShapeSetup_Rectangle(_shape);
            _shapeSetups[(int)ShapeType.Triangle] = new BackgroundShapeSetup_Triangle(_shape);



            SetShapeType();
            SetColors();
            SpecializedSetup();

            SetScale();

            SetSpeeds();
            Destroy(gameObject, 10);
        }
        private void Update()
        {
            Move();
            Rotate();
        }






        private void SetShapeType()
        {
            int randomShapeInt = Random.Range(0, System.Enum.GetValues(typeof(ShapeType)).Length - 1);
            _shape.settings.shapeType = (ShapeType)randomShapeInt;
            _shapeType = _shape.settings.shapeType;
        }
        private void SetColors()
        {
            float red = Random.Range(0f, 1f);
            float green = Random.Range(0f, 1f);
            float blue = Random.Range(0f, 1f);
            _shape.settings.fillColor = new Color(red, green, blue);

            red = Random.Range(0f, 1f);
            green = Random.Range(0f, 1f);
            blue = Random.Range(0f, 1f);
            _shape.settings.outlineColor = new Color(red, green, blue);
        }
        private void SpecializedSetup()
        {
            _shapeSetups[(int)_shapeType].Setup();
        }

        private void SetScale()
        {
            float scale = Random.Range(0.1f, 1);

            transform.localScale = Vector3.one * scale;
        }


        private void SetSpeeds()
        {
            _moveSpeed = Random.Range(5, 10);
            _rotationSpeed = Random.Range(40, 100);
        }
        private void Move()
        {
            transform.position += Vector3.left * _moveSpeed * Time.deltaTime;
        }
        private void Rotate()
        {
            transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
        }
    }




    public abstract class BaseBackgroundShapeSetupController
    {
        protected Shape _shape;

        public BaseBackgroundShapeSetupController(Shape shape)
        {
            _shape = shape;
        }


        public abstract void Setup();
    }


    public class BackgroundShapeSetup_Ellipse : BaseBackgroundShapeSetupController
    {
        public BackgroundShapeSetup_Ellipse(Shape shape) : base(shape) { }


        public override void Setup()
        {
            _shape.settings.startAngle = Random.Range(0, 360);
            _shape.settings.endAngle = 0;

            _shape.settings.innerCutout = Vector2.one * Random.Range(0f, 1f);

            _shape.settings.outlineSize = Random.Range(0f, 0.5f / 2) * _shape.transform.localScale.x * (_shape.settings.innerCutout.x / 6);
        }
    }
    public class BackgroundShapeSetup_Polygon : BaseBackgroundShapeSetupController
    {
        public BackgroundShapeSetup_Polygon(Shape shape) : base(shape) { }


        public override void Setup()
        {
            _shape.settings.polygonPreset = (PolygonPreset)(Random.Range(0, 10) + 2);

            _shape.settings.outlineSize = Random.Range(0f, 0.5f / 2) * _shape.transform.localScale.x;
        }
    }
    public class BackgroundShapeSetup_Rectangle : BaseBackgroundShapeSetupController
    {
        public BackgroundShapeSetup_Rectangle(Shape shape) : base(shape) { }


        public override void Setup()
        {
            _shape.settings.roundness = Random.Range(0f, 0.8f);

            _shape.settings.outlineSize = Random.Range(0f, 0.5f / 2) * _shape.transform.localScale.x;
        }
    }
    public class BackgroundShapeSetup_Triangle : BaseBackgroundShapeSetupController
    {
        public BackgroundShapeSetup_Triangle(Shape shape) : base(shape) { }


        public override void Setup()
        {
            _shape.settings.triangleOffset = Random.Range(0f, 1f);

            _shape.settings.outlineSize = Random.Range(0f, 0.31f / 2) * _shape.transform.localScale.x;
        }
    }
}