using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
//Realiza toda la carga de escenas dentro de unity
public class LevelLoader: MonoBehaviour {
    public Animator transition;

    public void ChangeSceneWithTransition(int sceneIndex) {
        StartCoroutine(LoadNewSceneCoroutine(sceneIndex));
    }

    IEnumerator LoadNewSceneCoroutine(int sceneIndex) {
        transition.SetTrigger("OnChangeSceneRequested");

        yield
        return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneIndex);
    }
}