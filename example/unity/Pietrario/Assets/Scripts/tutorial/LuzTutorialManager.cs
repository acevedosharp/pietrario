using UnityEngine;
//Da un tutorial acerca del manejo de la luz

public class LuzTutorialManager: MonoBehaviour {
    [SerializeField] public GameObject luzF1;

    [SerializeField] public GameObject luzF2;

    [SerializeField] public GameObject luzF3;

    [SerializeField] public GameObject canvasTutorial;


    private
    const string ownPropertyName = "luzTutorialHasBeenCalled";

    private void Start() {
        if (!hasBeenCalled(true, ownPropertyName)) {
            showLuzF1();
        }
    }

    public void showLuzF1() {
        luzF1.SetActive(true);
    }
    public void hideLuzF1() {
        luzF1.SetActive(false);
    }

    public void stepF1to2() {
        hideLuzF1();
        showLuzF2();
    }

    public void showLuzF2() {
        luzF2.SetActive(true);
    }
    public void hideLuzF2() {
        luzF2.SetActive(false);
    }

    public void stepF2to3() {
        hideLuzF2();
        showLuzF3();
    }


    public void showLuzF3() {
        luzF3.SetActive(true);
    }
    public void hideLuzF3() {
        luzF3.SetActive(false);
    }

    public void endTutorial() {
        hideLuzF3();

        Debug.Log("shown AR from Luz");
        canvasTutorial.GetComponent < ARTutorialManager > ().showARF1();
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