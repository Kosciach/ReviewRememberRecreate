using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecreateCanvasController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] TextMeshProUGUI _shapeTypeName;
    [SerializeField] TextMeshProUGUI _polygonPresetName;
    [SerializeField] GameObject[] _individualControlls;


    public void UpdateShapeType(ShapeType shapeType)
    {
        _shapeTypeName.text = shapeType.ToString();

        foreach (GameObject individualControll in _individualControlls) individualControll.SetActive(false);
        _individualControlls[(int)shapeType].SetActive(true);
    }
    public void UpdatePolygonPreset(PolygonPreset polygonPreset)
    {
        _polygonPresetName.text = polygonPreset.ToString();
    }
}
