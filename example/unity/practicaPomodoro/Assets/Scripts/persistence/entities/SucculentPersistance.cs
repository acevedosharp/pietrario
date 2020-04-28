using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SucculentPersistance : MonoBehaviour
{
    [SerializeField] GameObject succulent1;
    [SerializeField] GameObject succulent2;
    [SerializeField] GameObject succulent3;
    [SerializeField] GameObject buttonSucculent1;
    [SerializeField] GameObject buttonSucculent2;
    [SerializeField] GameObject buttonSucculent3;
    private Pietrario pietrario;
    

    void Start()
    {
        pietrario = (Pietrario)PietrarioRepository.LoadPietrarios()[0];
        renderSucculent();

    }

    public void renderSucculent()
    {
        if (pietrario.s1==null)
        {
            succulent1.SetActive(false);
            buttonSucculent1.SetActive(true);
        }
        else
        {
            succulent1.SetActive(true);
            buttonSucculent1.SetActive(false);
        }
        if (pietrario.s2==null)
        {
            succulent2.SetActive(false);
            buttonSucculent2.SetActive(true);
        }
        else
        {
            succulent2.SetActive(true);
            buttonSucculent2.SetActive(false);
        }
        if (pietrario.s3==null)
        {
            succulent3.SetActive(false);
            buttonSucculent3.SetActive(true);
        }
        else
        {
            succulent3.SetActive(true);
            buttonSucculent3.SetActive(false);
        }
    }

    public void enableSucculent1()
    {
        pietrario.s1=SucculentRepository.find("SUC1") ;
        this.renderSucculent();
    }
    public void enableSucculent2()
    {
        pietrario.s2=SucculentRepository.find("SUC2") ;
        this.renderSucculent();
        
    }
    public void enableSucculent3()
    {
        pietrario.s3=SucculentRepository.find("SUC3") ;
        this.renderSucculent();
    }
        
    
}
