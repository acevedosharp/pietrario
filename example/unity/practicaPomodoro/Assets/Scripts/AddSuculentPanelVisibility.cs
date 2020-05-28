using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSuculentPanelVisibility: MonoBehaviour {
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    private bool visible1 = true;
    private bool visible2 = true;
    private bool visible3 = true;
    private bool visible4 = true;
    void Start() {
        Panel1();
        Panel2();
        Panel3();
        Panel4();
        Panel4();
    }

    //Controla el panel de la aplicación
    //Una vez se reconoce que suculentas deberian estar activas y cuales no, realiza llamados referenciales a cada método de visibilidad
    public void Panel1() {
        visible1 = !visible1;
        panel1.SetActive(visible1);
        if (visible2) {
            Panel2();
        }

        if (visible3) {
            Panel3();
        }
        if (visible4) {
            Panel4();
        }
    }

    public void Panel2() {
        visible2 = !visible2;
        panel2.SetActive(visible2);

        if (visible1) {
            Panel1();
        }

        if (visible3) {
            Panel3();
        }
        if (visible4) {
            Panel4();
        }
        Debug.Log("Toggled from P1");

    }

    public void Panel3() {
        visible3 = !visible3;
        panel3.SetActive(visible3);
        if (visible1) {
            Panel1();
        }

        if (visible2) {
            Panel2();
        }

        if (visible4) {
            Panel4();
        }
        Debug.Log("Toggled from P3");
    }
    public void Panel4() {
        visible4 = !visible4;
        panel4.SetActive(visible4);
        if (visible1) {
            Panel1();
        }

        if (visible2) {
            Panel2();
        }

        if (visible3) {
            Panel3();
        }
        Debug.Log("Toggled guardianes from P4");
    }


    public void CloseAll() {
        visible1 = true;
        visible2 = true;
        visible3 = true;
        visible4 = true;
        Start();
    }


}