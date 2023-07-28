using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShapeController : MonoBehaviour
{
    private Shape _shape;
    private float _moveSpeed;
    private float _rotationSpeed;



    private void Awake()
    {
        _shape = GetComponent<Shape>();

        SetShapeType();
        SetColors();

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
        int randomShapeInt = Random.Range(0, System.Enum.GetValues(typeof(ShapeType)).Length-1);
        _shape.settings.shapeType = (ShapeType)randomShapeInt;
        if (_shape.settings.shapeType == ShapeType.Path) Debug.Log("Path");
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
