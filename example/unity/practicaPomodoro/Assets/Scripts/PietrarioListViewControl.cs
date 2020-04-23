using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PietrarioListViewControl : MonoBehaviour
{
    public GameObject no_pietrario_panel;
    public Text pietrario_name;
    void Start()
    {
        int id = PlayerPrefs.GetInt("id_pietrario");
        no_pietrario_panel.SetActive(false);
         if(id!=0){

            string name= PlayerPrefs.GetString("nombre_pietrario");
            pietrario_name.text= name;
        }

        else{
          no_pietrario_panel.SetActive(true);
        }
        
    }

    
    
}
