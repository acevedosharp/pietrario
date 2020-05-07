using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasVisibility : MonoBehaviour
{
    public GameObject menu;
    public GameObject inventory;
    public GameObject rewardPanel;
    
   private bool isShowing=true;
   private bool inventoryIsShowing = true;
    private bool isShowingReward = true;
    void Start()
    {
        func();
        inventoryfunc();
        RewardPanel();
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
}
