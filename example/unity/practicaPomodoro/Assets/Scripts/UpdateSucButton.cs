using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSucButton: MonoBehaviour {
    public GameObject suc1_but;
    public GameObject suc2_but;
    public GameObject suc3_but;
    public GameObject nosuc1_but;
    public GameObject nosuc2_but;
    public GameObject nosuc3_but;

    private bool suc1_available = false;

    private bool suc2_available = false;

    private bool suc3_available = false;
    // Start is called before the first frame update

    //Revisa que la suculenta elegida esté disponible
    public void CheckSucculentAvailability() {

        suc1_available = Inventory.getCantidadByReferencedItem("SUC1") > 0;
        suc2_available = Inventory.getCantidadByReferencedItem("SUC2") > 0;
        suc3_available = Inventory.getCantidadByReferencedItem("SUC3") > 0;
        UpdateButtons();
    }
    //Realiza una actualización de los botones según corresponda cuando las suculentas están o no activas
    private void UpdateButtons() {
        if (suc1_available) {
            suc1_but.SetActive(true);
            nosuc1_but.SetActive(false);
        } else {
            suc1_but.SetActive(false);
            nosuc1_but.SetActive(true);
        }

        if (suc2_available) {
            suc2_but.SetActive(true);
            nosuc2_but.SetActive(false);
        } else {
            suc2_but.SetActive(false);
            nosuc2_but.SetActive(true);
        }
        if (suc3_available) {
            suc3_but.SetActive(true);
            nosuc3_but.SetActive(false);
        } else {
            suc3_but.SetActive(false);
            nosuc3_but.SetActive(true);
        }
    }



}