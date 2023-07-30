using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanelsController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] GameObject[] _panels;


    public void ChangePanel(GameObject choosenPanel)
    {
        foreach (GameObject panel in _panels) panel.SetActive(false);
        choosenPanel.SetActive(true);
    }
}
