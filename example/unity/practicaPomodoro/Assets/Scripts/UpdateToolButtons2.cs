using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateToolButtons2 : MonoBehaviour
{
    public GameObject tool2;
    public GameObject tool1;
    public GameObject tool3;
    public GameObject notool1;
    public GameObject notool3;
    public GameObject notool2;

    private bool water_available;


    public void Start()
    {
        tool2.SetActive(false);
        notool2.SetActive(false);
    }

    public void ShowButton()
    {
        water_available = Inventory.getCantidadByReferencedItem("AGUA") > 0;
        if (water_available)
        {
            tool2.SetActive(true);
        }
        else
        {
            notool2.SetActive(true);
        }
    }

    public void UpdateButton()
    {
        water_available = Inventory.getCantidadByReferencedItem("AGUA") > 0;
    
        if (water_available)
        {
            tool2.SetActive(true);
            notool2.SetActive(false);
     
        }
        else
        {
            notool2.SetActive(true);
            notool1.SetActive(true);
            notool3.SetActive(true);
            tool2.SetActive(false);
            tool1.SetActive(false);
            tool3.SetActive(false);
        }
    
    }
}
