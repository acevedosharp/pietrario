using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PietrarioListViewControl: MonoBehaviour {

    //Hace refencia a el control de las vistas de los pietrarios existentes, está configurado de forma que permite el control de varios pietrarios al mismo tiempo con sus respectivas características
    public GameObject no_pietrario_panel;
    public Text pietrario_name;
    void Start() {
        no_pietrario_panel.SetActive(false);

        if (PietrarioRepository.existsAnyPietrario()) {
            // TODO: Update to handle multiple Pietrarios.
            Pietrario pietrario = (Pietrario) PietrarioRepository.LoadPietrarios()[0];
            pietrario_name.text = pietrario.name;
        } else {
            no_pietrario_panel.SetActive(true);
        }

    }



}