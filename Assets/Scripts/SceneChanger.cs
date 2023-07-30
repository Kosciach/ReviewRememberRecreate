using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance { get; private set; }

    public enum SceneNames
    { 
        MainMenu, Remember, Recreate, Results
    }



    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }


    public void ChangeScene(SceneNames sceneName)
    {
        string sceneNameString = sceneName.ToString() + "Scene";
        SceneManager.LoadScene(sceneNameString);
    }
}