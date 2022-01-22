using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        LoadScene();
    }



    private void LoadScene()
    {
        int lastScene = PlayerPrefs.GetInt("Level");

        if (PlayerPrefs.HasKey("Level"))
        {
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            SceneManager.LoadScene(1);
        }

    }



}
