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
    [SerializeField] Text sunLabel;
    [SerializeField] GameObject princiPietrario;
    [SerializeField] Image succulentLive1;
    [SerializeField] Image succulentLive2;
    [SerializeField] Image succulentLive3;
    [SerializeField] public Image sunLevel;
    float maxLive1 = 100, maxLive2 = 100, maxLive3 = 100, maxLight=100;

    [SerializeField] public Image can1;
    [SerializeField] public Image can2;
    [SerializeField] public Image can3;
    
    private Pietrario pietrario;
    private GameObject succ1, succ2, succ3;


    void Start()
    {
        pietrario = (Pietrario)PietrarioRepository.LoadPietrarios()[0];
        renderSucculent();
    }

    private void Update()
    {
        if (pietrario!=null)
        {
            if (pietrario.s1 != null)
            {
                updateS1wl();
            }
            if (pietrario.s2 != null)
            {
                updateS2wl();
            }
            if (pietrario.s3 != null)
            {
                updateS3wl();

            }
            updateSunLight();
            
        }
        

        


    }

    public void updateSunLight()
    {
        long timeDelta = DateTime.Now.Ticks - pietrario.dtL;
        TimeSpan timePassed = new TimeSpan(timeDelta);
        //Debug.Log(pietrario.decaySunLightLevel);
        if (Math.Floor(timePassed.TotalSeconds) > 0 && pietrario.sunLightLevel > 0)
        {
            pietrario.sunLightLevel -= pietrario.decaySunLightLevel * Convert.ToSingle(Math.Floor(timePassed.TotalSeconds));
            sunLevel.fillAmount = pietrario.sunLightLevel / maxLight;
            sunLabel.text = pietrario.sunLightLevel.ToString();
            pietrario.dtL = DateTime.Now.Ticks;
            



        }
        else
        {
            if (pietrario.sunLightLevel<=0)
            {
                pietrario.sunLightLevel = 0;
                pietrario.Save();  
            }
            
        }
    }
    public void updateS1wl()
    {
        long timeDelta = DateTime.Now.Ticks - pietrario.dtS1;
        TimeSpan timePassed = new TimeSpan(timeDelta);

        if (Math.Floor(timePassed.TotalSeconds) > 0 && pietrario.s1wl > 0)
        {
            pietrario.s1wl -= pietrario.s1.waterDecayIndex * Convert.ToSingle(Math.Floor(timePassed.TotalSeconds));
            succulentLive1.fillAmount = pietrario.s1wl / maxLive1;
            suc1.text = pietrario.s1wl.ToString();
            pietrario.dtS1 = DateTime.Now.Ticks;

        }

        if (pietrario.s1wl <= 0)
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

        if (Math.Floor(timePassed.TotalSeconds) > 0 && pietrario.s2wl > 0)
        {
           
                pietrario.s2wl -= pietrario.s2.waterDecayIndex * Convert.ToSingle(Math.Floor(timePassed.TotalSeconds));
            
            
            succulentLive2.fillAmount = pietrario.s2wl / maxLive2;
            suc2.text = pietrario.s2wl.ToString();

            pietrario.dtS2 = DateTime.Now.Ticks;
        }
        if (pietrario.s2wl <= 0)
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

        if (Math.Floor(timePassed.TotalSeconds) > 0 && pietrario.s3wl > 0)
        {
            pietrario.s3wl -= pietrario.s3.waterDecayIndex * Convert.ToSingle(Math.Floor(timePassed.TotalSeconds));
            succulentLive3.fillAmount = pietrario.s3wl / maxLive3;
            suc3.text = pietrario.s3wl.ToString();
            pietrario.dtS3 = DateTime.Now.Ticks;
        }
        if (pietrario.s3wl <= 0)
        {
            
            pietrario.s3 = null;

            pietrario.Save();
            this.renderSucculent();
        }
    }

    public void renderSucculent()
    {
       
        buttonSucculent1.SetActive(true);
        buttonSucculentCopy1.SetActive(true);
        live1.enabled = false;
        mask1.enabled = false;
        suc1.enabled = false;
        succulentLive1.enabled = false;

        buttonSucculent2.SetActive(true);
        buttonSucculentCopy2.SetActive(true);
        live2.enabled = false;
        mask2.enabled = false;
        suc2.enabled = false;   
        succulentLive2.enabled = false;

        buttonSucculent3.SetActive(true);
        buttonSucculentCopy3.SetActive(true);
        live3.enabled = false;
        mask3.enabled = false;
        suc3.enabled = false;
        succulentLive3.enabled = false;
        can1.enabled = false;
        can2.enabled = false;
        can3.enabled=false;


        if (pietrario.s1 != null)
        {
            if (pietrario.s1.persistentId=="SUC1" && succ1==null)
            {
                succ1 = Instantiate(succulent1, new Vector3(15, 597, 285), succulent1.transform.rotation);
                succ1.transform.parent = princiPietrario.transform;
                succ1.transform.localScale = new Vector3(5, 5, 5);
            }
            if (pietrario.s1.persistentId == "SUC2" && succ1 == null)
            {
                succ1 = Instantiate(succulent2, new Vector3(15, 597, 285), succulent2.transform.rotation);
                succ1.transform.parent = princiPietrario.transform;
                succ1.transform.localScale = new Vector3(80, 80, 80);
            }
            if (pietrario.s1.persistentId == "SUC3" && succ1 == null)
            {
                succ1 = Instantiate(succulent3, new Vector3(15, 597, 285), succulent3.transform.rotation);
                succ1.transform.parent = princiPietrario.transform;
                succ1.transform.localScale = new Vector3(20, 20, 20);
            }
            buttonSucculent1.SetActive(false);
            buttonSucculentCopy1.SetActive(false);
            live1.enabled = true;
            mask1.enabled = true;
            suc1.enabled = true;
            succulentLive1.enabled = true;
            can1.enabled=true;
        }
        else
        {
            Destroy(succ1);
        }
        if (pietrario.s2 != null)
        {
            if (pietrario.s2.persistentId=="SUC1" && succ2==null)
            {
                succ2 = Instantiate(succulent1, new Vector3(297, 658.5f, 419.5f), succulent1.transform.rotation);
                succ2.transform.parent = princiPietrario.transform;
                succ2.transform.localScale = new Vector3(5, 5, 5);
            }
            if (pietrario.s2.persistentId == "SUC2" && succ2 == null)
            {
                succ2 = Instantiate(succulent2, new Vector3(297, 658.5f, 419.5f), succulent2.transform.rotation);
                succ2.transform.parent = princiPietrario.transform;
                succ2.transform.localScale = new Vector3(80, 80, 80);
            }
            if (pietrario.s2.persistentId == "SUC3" && succ2 == null)
            {
                succ2 = Instantiate(succulent3, new Vector3(297, 658.5f, 419.5f), succulent3.transform.rotation);
                succ2.transform.parent = princiPietrario.transform;
                succ2.transform.localScale = new Vector3(20, 20, 20);
            }
            buttonSucculent2.SetActive(false);
            buttonSucculentCopy2.SetActive(false);
            live2.enabled = true;
            mask2.enabled = true;
            suc2.enabled = true;
            succulentLive2.enabled = true;
            can2.enabled=true;
        }
        else
        {
            Destroy(succ2);
        }

        if (pietrario.s3 != null)
        {
            if (pietrario.s3.persistentId=="SUC1" && succ3==null)
            {
                succ3 = Instantiate(succulent1, new Vector3(565.5f, 594.5f, 189.5f), succulent1.transform.rotation);
                succ3.transform.parent = princiPietrario.transform;
                succ3.transform.localScale = new Vector3(5, 5, 5);
            }
            if(pietrario.s3.persistentId == "SUC2" && succ3 == null)
            {
                succ3 = Instantiate(succulent2, new Vector3(565.5f, 594.5f, 189.5f), succulent2.transform.rotation);
                succ3.transform.parent = princiPietrario.transform;
                succ3.transform.localScale = new Vector3(80, 80, 80);
            }
            if(pietrario.s3.persistentId == "SUC3" && succ3 == null)
            {
                succ3 = Instantiate(succulent3, new Vector3(565.5f, 594.5f, 189.5f), succulent3.transform.rotation);
                succ3.transform.parent = princiPietrario.transform;
                succ3.transform.localScale = new Vector3(20, 20, 20);
            }
            buttonSucculent3.SetActive(false);
            buttonSucculentCopy3.SetActive(false);
            live3.enabled = true;
            mask3.enabled = true;
            suc3.enabled = true;
            succulentLive3.enabled = true;
            can3.enabled=true;
        }
        else
        {
            Destroy(succ3);
        }
    }

    public void enableSucculent1(int i)
    {
        if (i == 0)
        {
            pietrario.s1 = SucculentRepository.find("SUC1");
            pietrario.s1wl = 100;

            succ1 = Instantiate(succulent1, new Vector3(15, 597, 285), succulent1.transform.rotation);
            succ1.transform.parent = princiPietrario.transform;
            succ1.transform.localScale = new Vector3(5, 5, 5);

        }

        if (i == 1)
        {
            pietrario.s1 = SucculentRepository.find("SUC2");
            pietrario.s1wl = 100;
            succ1 = Instantiate(succulent2, new Vector3(15, 597, 285), succulent2.transform.rotation);
            succ1.transform.parent = princiPietrario.transform;
            succ1.transform.localScale = new Vector3(80, 80, 80);
        }
        if (i == 2)
        {
            pietrario.s1 = SucculentRepository.find("SUC3");
            pietrario.s1wl = 100;
            succ1 = Instantiate(succulent3, new Vector3(15, 597, 285), succulent3.transform.rotation);
            succ1.transform.parent = princiPietrario.transform;
            succ1.transform.localScale = new Vector3(20, 20, 20);
        }
        pietrario.dtS1 = DateTime.Now.Ticks;
        pietrario.Save();
        this.renderSucculent();
        
    }
    public void enableSucculent2(int i)
    {

        if (i == 0)
        {
            pietrario.s2 = SucculentRepository.find("SUC1");
            pietrario.s2wl = 100;
            succ2 = Instantiate(succulent1, new Vector3(297, 658.5f, 419.5f), succulent1.transform.rotation);
            succ2.transform.parent = princiPietrario.transform;
            succ2.transform.localScale = new Vector3(5, 5, 5);
            
            
            
        }

        if (i == 1)
        {
            pietrario.s2 = SucculentRepository.find("SUC2");
            pietrario.s2wl = 100;
            succ2 = Instantiate(succulent2, new Vector3(297, 658.5f, 419.5f), succulent2.transform.rotation);
            succ2.transform.parent = princiPietrario.transform;
            succ2.transform.localScale = new Vector3(80, 80, 80);

        }
        if (i == 2)
        {
            pietrario.s2 = SucculentRepository.find("SUC3");
            pietrario.s2wl = 100;
            succ2 = Instantiate(succulent3, new Vector3(297, 658.5f, 419.5f), succulent3.transform.rotation);
            succ2.transform.parent = princiPietrario.transform;
            succ2.transform.localScale = new Vector3(20, 20, 20);

        }
        pietrario.dtS2= DateTime.Now.Ticks; 
        pietrario.Save();
        this.renderSucculent();
    }
    public void enableSucculent3(int i)
    {
        if (i == 0)
        {
            pietrario.s3 = SucculentRepository.find("SUC1");
            pietrario.s3wl = 100;
            succ3 = Instantiate(succulent1, new Vector3(565.5f, 594.5f, 189.5f), succulent1.transform.rotation);
            succ3.transform.parent = princiPietrario.transform;
            succ3.transform.localScale = new Vector3(5, 5, 5);
        }

        if (i == 1)
        {
            pietrario.s3 = SucculentRepository.find("SUC2");
            pietrario.s3wl = 100;
            succ3 = Instantiate(succulent2, new Vector3(565.5f, 594.5f, 189.5f), succulent2.transform.rotation);
            succ3.transform.parent = princiPietrario.transform;
            succ3.transform.localScale = new Vector3(80, 80, 80);
        }
        if (i == 2)
        {
            pietrario.s3 = SucculentRepository.find("SUC3");
            pietrario.s3wl = 100;
            succ3 = Instantiate(succulent3, new Vector3(565.5f, 594.5f, 189.5f), succulent3.transform.rotation);
            succ3.transform.parent = princiPietrario.transform;
            succ3.transform.localScale = new Vector3(20, 20, 20);
        }
        pietrario.dtS3 = DateTime.Now.Ticks;
        pietrario.Save();
        this.renderSucculent();
    }
    public void updateWaterLevel(String suctype)
    {
      
        if (suctype == "SUC1")
        {
            pietrario.s1wl = 100f;
            renderSucculent();
            pietrario.Save();
        }
        else if (suctype == "SUC2")
        {
            pietrario.s2wl = 100f;
            renderSucculent();
            pietrario.Save();
        }else if (suctype == "SUC3")
        {
            pietrario.s3wl = 100f;
            renderSucculent();
            pietrario.Save();
        }
    }

}
