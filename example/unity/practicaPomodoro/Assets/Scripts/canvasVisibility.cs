using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasVisibility: MonoBehaviour {
    public GameObject menu;
    public GameObject inventory;
    public GameObject rewardPanel;

    private bool isShowing = true;
    private bool inventoryIsShowing = true;
    private bool isShowingReward = true;

    public GameObject canvasTutorial;
    private TutorialManager _tutorialManager;
    private int currentTutorialPhase = 1;

    void Start() {
        func();
        inventoryfunc();
        RewardPanel();

        // Aqui extraemos el tutoriaManager del canvas.
        _tutorialManager = canvasTutorial.GetComponent < TutorialManager > ();

        showPomodoroTutorialF1();
    }


    //Establece cómo activas las cosas que esten en estado show
    public void func() {
        isShowing = !isShowing;
        menu.SetActive(isShowing);
    }

    public void inventoryfunc() {
        inventoryIsShowing = !inventoryIsShowing;
        inventory.SetActive(inventoryIsShowing);
    }
    //Oculta el panel de recompensa una vez llamado
    public void RewardPanel() {
        rewardPanel.SetActive(false);
    }
    //Muestra el tutorial
    public void showPomodoroTutorialF1() {
        _tutorialManager.showPomodoroF1();
    }
    //Oculta el tutorial
    public void closePomodoroTutorialF1() {
        if (currentTutorialPhase == 1) {
            _tutorialManager.hidePomodoroF1();
            showPomodoroTutorialF2();

            currentTutorialPhase++;
        }
    }

    //Muestra el segundo tutorial
    public void showPomodoroTutorialF2() {
        _tutorialManager.showPomodoroF2();
    }
    //Oculta el segundo tutorial
    public void closePomodoroTutorialF2() {
        if (currentTutorialPhase == 2) {
            _tutorialManager.hidePomodoroF2();
            showPomodoroTutorialF3();

            currentTutorialPhase++;
        }
    }
    //Muestra el tercer tutorial

    public void showPomodoroTutorialF3() {
        _tutorialManager.showPomodoroF3();
    }
    //oculta el tercer tutorial
    public void closePomodoroTutorialF3() {
        if (currentTutorialPhase == 3) {
            _tutorialManager.hidePomodoroF3();
            currentTutorialPhase = 0;
        }
    }
}