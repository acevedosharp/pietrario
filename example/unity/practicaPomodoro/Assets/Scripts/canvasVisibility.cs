using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasVisibility : MonoBehaviour
{
    public GameObject menu;
    public GameObject inventory;
    public GameObject rewardPanel;

    private bool isShowing = true;
    private bool inventoryIsShowing = true;
    private bool isShowingReward = true;

    public GameObject canvasTutorial;
    private TutorialManager _tutorialManager;
    private int currentTutorialPhase = 1;

    void Start()
    {
        func();
        inventoryfunc();
        RewardPanel();

        // Here we extract the TutorialManager component from our canvasTutorial.
        _tutorialManager = canvasTutorial.GetComponent<TutorialManager>();
        
        showPomodoroTutorialF1();
    }

    public void func()
    {
        isShowing = !isShowing;
            menu.SetActive(isShowing);
    }

    public void inventoryfunc()
    {
        inventoryIsShowing = !inventoryIsShowing;
        inventory.SetActive(inventoryIsShowing);
    }

    public void RewardPanel()
    {
        rewardPanel.SetActive(false);
    }

    public void showPomodoroTutorialF1()
    {
        _tutorialManager.showPomodoroF1();
    }
    public void closePomodoroTutorialF1()
    {
        if (currentTutorialPhase == 1)
        {
            _tutorialManager.hidePomodoroF1();
            showPomodoroTutorialF2();
            
            currentTutorialPhase++;
        }
    }
    
    public void showPomodoroTutorialF2()
    {
        _tutorialManager.showPomodoroF2();
    }
    public void closePomodoroTutorialF2()
    {
        if (currentTutorialPhase == 2)
        {
            _tutorialManager.hidePomodoroF2();
            showPomodoroTutorialF3();

            currentTutorialPhase++;
        }
    }
    
    public void showPomodoroTutorialF3()
    {
        _tutorialManager.showPomodoroF3();
    }
    public void closePomodoroTutorialF3()
    {
        if (currentTutorialPhase == 3)
        {
            _tutorialManager.hidePomodoroF3();
            currentTutorialPhase = 0;
        }
    }
}