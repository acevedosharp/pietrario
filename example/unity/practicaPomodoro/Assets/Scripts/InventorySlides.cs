using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlides : MonoBehaviour
{
    public GameObject slide1;

    public GameObject slide2;

   
    public Button left1;

    public Button right1;

    public Button left2;

    public Button right2;
    // Start is called before the first frame update
 
    // Update is called once per frame

    private void Start()
    {
        left1.enabled = false;
        right2.enabled = false;
        slide1.SetActive(true);
        slide2.SetActive(false);
    }

    public void Right()
    {
        slide1.SetActive(false);
        slide2.SetActive(true);
    
       
    }

    public void Left()
    {
        slide1.SetActive(true);
        slide2.SetActive(false);
    }
}
