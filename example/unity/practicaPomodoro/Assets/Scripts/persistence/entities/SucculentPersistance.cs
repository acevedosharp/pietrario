using System;
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

    private void Update()
    {
        if (pietrario.s1!=null)
        {
            updateS1wl();
        }
        if (pietrario.s2!=null)
        {
            updateS2wl();
        }
        if (pietrario.s3!=null)
        {
            updateS3wl();
        }
        
        
    }

    public void updateS1wl()
    {
        long timeDelta = DateTime.Now.Ticks - pietrario.dtS1;
        TimeSpan timePassed = new TimeSpan(timeDelta);

        if (Math.Floor(timePassed.TotalSeconds)>0 && pietrario.s1wl>0)
        {
            pietrario.s1wl -= pietrario.s1.waterDecayIndex * Convert.ToSingle(Math.Floor(timePassed.TotalSeconds));
            print(pietrario.s1wl);
            pietrario.dtS1 = DateTime.Now.Ticks;
        }

        if (pietrario.s1wl<=0)
        {
            pietrario.s1 = null;
            
            pietrario.Save();
            this.renderSucculent();
        }
    }
    public void updateS2wl()
    {
        long timeDelta = DateTime.Now.Ticks - pietrario.dtS2;
        TimeSpan timePassed = new TimeSpan(timeDelta);

        if (Math.Floor(timePassed.TotalSeconds)>0 && pietrario.s2wl>0)
        {
            pietrario.s2wl -= pietrario.s2.waterDecayIndex * Convert.ToSingle(Math.Floor(timePassed.TotalSeconds));
           // print(pietrario.s2wl);
            pietrario.dtS2 = DateTime.Now.Ticks;
        }
        if (pietrario.s2wl<=0)
        {
            pietrario.s2 = null;
            
            pietrario.Save();
            this.renderSucculent();
        }
    }
    public void updateS3wl()
    {
        long timeDelta = DateTime.Now.Ticks - pietrario.dtS3;
        TimeSpan timePassed = new TimeSpan(timeDelta);

        if (Math.Floor(timePassed.TotalSeconds)>0 && pietrario.s3wl>0)
        {
            pietrario.s3wl -= pietrario.s3.waterDecayIndex * Convert.ToSingle(Math.Floor(timePassed.TotalSeconds));
           // print(pietrario.s3wl);
            pietrario.dtS3 = DateTime.Now.Ticks;
        }
        if (pietrario.s3wl<=0)
        {
            pietrario.s3 = null;
            
            pietrario.Save();
            this.renderSucculent();
        }
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
        pietrario.s1=SucculentRepository.find("SUC1");
        pietrario.s1wl = 100;
        pietrario.Save();
        this.renderSucculent();
    }
    public void enableSucculent2()
    {
        pietrario.s2=SucculentRepository.find("SUC2") ;
        pietrario.s2wl = 100;
        pietrario.Save();
        this.renderSucculent();
         
    }
    public void enableSucculent3()
    {
        pietrario.s3=SucculentRepository.find("SUC3") ;
        pietrario.s3wl = 100;
        pietrario.Save();
        this.renderSucculent();
    }
        
    
}
