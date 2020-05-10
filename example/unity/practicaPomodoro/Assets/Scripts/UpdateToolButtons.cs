using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateToolButtons : MonoBehaviour
{
  public GameObject tool1;
  
  public GameObject tool2;
  
  public GameObject tool3;

  public GameObject notool1;

  public GameObject notool2;

  public GameObject notool3;
  
  private bool water_available;


  public void Check()
  {
    water_available = Inventory.getCantidadByReferencedItem("AGUA") > 0;
    UpdateButtons();
  }

  void UpdateButtons()
  {
    if (water_available)
    {
      tool1.SetActive(true);
      tool2.SetActive(true);
      tool3.SetActive(true);
      notool1.SetActive(false);
      notool2.SetActive(false);
      notool3.SetActive(false);
    }
    else
    {
      notool1.SetActive(true);
      notool2.SetActive(true);
      notool3.SetActive(true);
      tool1.SetActive(false);
      tool2.SetActive(false);
      tool3.SetActive(false);
    }
    
  }
}
