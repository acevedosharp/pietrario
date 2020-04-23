using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidePomodoro : MonoBehaviour
{
    public GameObject menu;
   private bool isShowing=true;
    void Start()
    {
        func();
    }

    public void func()
    {
        isShowing = !isShowing;
             menu.SetActive(isShowing);
    }
}
