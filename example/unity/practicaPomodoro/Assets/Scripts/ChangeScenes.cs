﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public Animator transition;

    public void ChangeSceneStart()
    {
        SceneManager.LoadScene(0);
    }


    public void ChangeSceneNewPietrario()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeScenePietrarioList()
    {
        SceneManager.LoadScene(2);
    }

    public void ChangeScenePomodoro()
    {
        ChangeSceneWithTransition(3);
    }

    public void ChangeSceneAR()
    {
        ChangeSceneWithTransition(4);
    }

    private void ChangeSceneWithTransition(int sceneIndex)
    {
        StartCoroutine(LoadNewSceneCoroutine(sceneIndex));
    }

    IEnumerator LoadNewSceneCoroutine(int sceneIndex)
    {
        transition.SetTrigger("OnChangeSceneRequested");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneIndex);
    }
}