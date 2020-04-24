﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PietrarioListViewControl : MonoBehaviour
{
    public GameObject no_pietrario_panel;
    public Text pietrario_name;
    void Start()
    {
        no_pietrario_panel.SetActive(false);

        if(PietrarioRepository.existsAnyPietrario())
        {
            // TODO: Update to handle multiple Pietrarios.
            Pietrario pietrario = (Pietrario)PietrarioRepository.LoadPietrarios()[0];
            pietrario_name.text= pietrario.name;
        }

        else{
          no_pietrario_panel.SetActive(true);
        }
        
    }

    
    
}