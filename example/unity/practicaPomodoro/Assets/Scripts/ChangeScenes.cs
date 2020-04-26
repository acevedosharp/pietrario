using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    
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
        SceneManager.LoadScene(3);
    }

   public void ChangeSceneAR()
       {
           SceneManager.LoadScene(4);
       }

  
}