using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSuculentPanelVisibility : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    private bool visible1 = true;
    private bool visible2 = true;
    private bool visible3 = true;

    void Start()
    {
        Panel1();
        Panel2();
        Panel3();
    }

    public void Panel1()
    {
        visible1 = !visible1;
        panel1.SetActive(visible1);
        if (visible2)
        {
            Panel2();
        }

        if (visible3)
        {
            Panel3();
        }
    }

    public void Panel2()
    {
        visible2 = !visible2;
        panel2.SetActive(visible2);

        if (visible1)
        {
            Panel1();
        }

        if (visible3)
        {
            Panel3();
        }
    }

    public void Panel3()
    {
        visible3 = !visible3;
        panel3.SetActive(visible3);
        if (visible1)
        {
            Panel1();
        }

        if (visible2)
        {
            Panel2();
        }
    }

    public void CloseAll()
    {
        visible1 = true;
        visible2 = true;
        visible3 = true;
        Start();
    }


}
