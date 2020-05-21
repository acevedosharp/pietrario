using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    
    public void ChangeSceneWithTransition(int sceneIndex)
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
