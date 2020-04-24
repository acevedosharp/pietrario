using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void ChangeScenePietrarioList()
    {
        SceneManager.LoadScene(4);
    }

    public void ChangeScenePomodoro()
    {
        SceneManager.LoadScene(2);
    }

    public void ChangeSceneNewPietrario()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeSceneStart()
    {
        SceneManager.LoadScene(0);
    }
}