using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TutorialManager: MonoBehaviour {
    [SerializeField] public GameObject pomodoroF1;

    [SerializeField] public GameObject pomodoroF2;

    [SerializeField] public GameObject pomodoroF3;

    private
    const string ownPropertyName = "pomodoroTutorialHasBeenCalled";
    // Update is called once per frame

    /*
     *    Prefiero no usar un toggle para show/hide porque
     *    el tutorial se mostraría 1 o pocas veces (si el usuario lo desea).
     *    llamar explícitamente show y hide da claridad respecto a qué se quiere hacer con la interfáz.
     */

    public void showPomodoroF1() {
        if (!hasBeenCalled(false, ownPropertyName)) {
            pomodoroF1.SetActive(true);
        }
    }
    public void hidePomodoroF1() {
        pomodoroF1.SetActive(false);
    }


    public void showPomodoroF2() {
        if (!hasBeenCalled(false, ownPropertyName)) {
            pomodoroF2.SetActive(true);
        }
    }
    public void hidePomodoroF2() {
        pomodoroF2.SetActive(false);
    }


    public void showPomodoroF3() {
        if (!hasBeenCalled(true, ownPropertyName)) {
            pomodoroF3.SetActive(true);
        }
    }
    public void hidePomodoroF3() {
        pomodoroF3.SetActive(false);
    }

    private bool hasBeenCalled(bool shouldInitializeTutorial, string propertyName) {
        bool resSnapshot = bool.Parse(PlayerPrefs.GetString(propertyName));
        Debug.Log(resSnapshot);

        if (shouldInitializeTutorial) {
            PlayerPrefs.SetString(propertyName, "true");
        }

        return resSnapshot;
    }
}