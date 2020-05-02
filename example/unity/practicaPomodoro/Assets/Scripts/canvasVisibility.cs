using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasVisibility : MonoBehaviour
{
    public GameObject menu;
    public GameObject inventory;
    
   private bool isShowing=true;
   private bool inventoryIsShowing = true;
    void Start()
    {
        func();
        inventoryfunc();
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
}
