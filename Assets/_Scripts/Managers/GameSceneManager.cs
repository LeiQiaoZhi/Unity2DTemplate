using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void ReloadScene()
    {
        LoggerX.Log(Category.Scene,"reload scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int index)
    {
        LoggerX.Log(Category.Scene,$"Loading scene {SceneManager.GetSceneByBuildIndex(index).name}");
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
