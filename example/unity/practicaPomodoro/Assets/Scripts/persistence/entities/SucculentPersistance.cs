﻿using System;
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
    [SerializeField] GameObject buttonSucculentCopy1;
    [SerializeField] GameObject buttonSucculentCopy2;
    [SerializeField] GameObject buttonSucculentCopy3;
    [SerializeField] Image live1;
    [SerializeField] Image live2;
    [SerializeField] Image live3;
    [SerializeField] Image mask1;
    [SerializeField] Image mask2;
    [SerializeField] Image mask3;
    [SerializeField] Text suc1;
    [SerializeField] Text suc2;
    [SerializeField] Text suc3;

    [SerializeField] Image succulentLive1;
    [SerializeField] Image succulentLive2;
    [SerializeField] Image succulentLive3;
    float maxLive1=100, maxLive2=100, maxLive3=100;
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
            succulentLive1.fillAmount = pietrario.s1wl / maxLive1;
            suc1.text =pietrario.s1wl.ToString();
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
            succulentLive2.fillAmount = pietrario.s2wl / maxLive2;
            suc2.text = pietrario.s2wl.ToString();
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
            succulentLive3.fillAmount = pietrario.s3wl / maxLive3;
            suc3.text = pietrario.s3wl.ToString();
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
            buttonSucculentCopy1.SetActive(true);
            live1.enabled=false;
            mask1.enabled = false;
            suc1.enabled = false;
            succulentLive1.enabled = false;


        }
        else
        {
            succulent1.SetActive(true);
            buttonSucculent1.SetActive(false);
            buttonSucculentCopy1.SetActive(false);
            live1.enabled = true;
            mask1.enabled = true;
            suc1.enabled = true;
            succulentLive1.enabled = true;
        }
        if (pietrario.s2==null)
        {
            succulent2.SetActive(false);
            buttonSucculent2.SetActive(true);
            buttonSucculentCopy2.SetActive(true);
            live2.enabled = false;
            mask2.enabled = false;
            suc2.enabled = false;
            succulentLive2.enabled = false;
        }
        else
        {
            succulent2.SetActive(true);
            buttonSucculent2.SetActive(false);
            buttonSucculentCopy2.SetActive(false);
            live2.enabled = true;
            mask2.enabled = true;
            suc2.enabled = true;
            succulentLive2.enabled = true;
        }
        if (pietrario.s3==null)
        {
            succulent3.SetActive(false);
            buttonSucculent3.SetActive(true);
            buttonSucculentCopy3.SetActive(true);
            live3.enabled = false;
            mask3.enabled = false;
            suc3.enabled = false;
            succulentLive3.enabled = false;
        }
        else
        {
            succulent3.SetActive(true);
            buttonSucculent3.SetActive(false);
            buttonSucculentCopy3.SetActive(false);
            live3.enabled = true;
            mask3.enabled = true;
            suc3.enabled = true;
            succulentLive3.enabled = true;
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
