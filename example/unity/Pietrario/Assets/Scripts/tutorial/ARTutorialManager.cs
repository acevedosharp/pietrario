using UnityEngine;

public class ARTutorialManager: MonoBehaviour {
    [SerializeField] public GameObject ARF1;

    [SerializeField] public GameObject ARF2;

//Da un tutorial acerca del manejo del pietrario en realidad aumentada

    private
    const string ownPropertyName = "ARTutorialHasBeenCalled";
    private
    const string predecesorPropertyName = "luzTutorialHasBeenCalled";

    private void Start() {
        // Not sure what happened here but it works, let's keep it that way!
        hasBeenCalled(true, ownPropertyName);
        bool c = !hasBeenCalled(true, ownPropertyName) && hasBeenCalled(false, predecesorPropertyName);
        if (c) {
            Debug.Log("Executed ARTutorial: " + c);
            showARF1();
        }
    }

    public void showARF1() {
        ARF1.SetActive(true);
    }
    public void hideARF1() {
        ARF1.SetActive(false);
    }

    public void stepF1to2() {
        hideARF1();
        showARF2();
    }

    public void showARF2() {
        ARF2.SetActive(true);
    }
    public void hideARF2() {
        ARF2.SetActive(false);
    }


    public void endTutorial() {
        hideARF2();
    }

    private bool hasBeenCalled(bool shouldInitializeTutorial, string propertyName) {
        bool resSnapshot = bool.Parse(PlayerPrefs.GetString(propertyName));

        if (shouldInitializeTutorial) {
            PlayerPrefs.SetString(propertyName, "true");
        }

        return resSnapshot;
    }
}