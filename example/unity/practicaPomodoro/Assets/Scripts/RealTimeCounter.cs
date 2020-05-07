using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class RealTimeCounter : MonoBehaviour {
    public float timer;
    public float timerSetUpMin;
    public int tempseg;
    public float timerTemp;
    public int compWarn;
    public static RealTimeCounter instance;
    [SerializeField] Text timerLabel;
    [SerializeField] Text textTimer;
     [SerializeField] GameObject suc1;
    [SerializeField] GameObject suc2;
    [SerializeField] GameObject suc3;
    [SerializeField] GameObject rewardPanel;
    InventoryController inv = new InventoryController();
    void Start () {
        if (PlayerPrefs.GetInt("compWarn",2)==2)
        {
            PlayerPrefs.SetInt("compWarn",0);    
        }
        compWarn = PlayerPrefs.GetInt("compWarn",2);
        
        timer = TimeMaster.instance.CheckDate () [1];
        timerSetUpMin = 0;
        timerTemp = 0;
        timer -= TimeMaster.instance.CheckDate () [0];
        tempseg = 0;
        instance = this;
    }
    void Update () {
        if (timer > 0) {
            timer -= Time.deltaTime;
            timerLabel.text = Formatting();
            PlayerPrefs.SetInt("compWarn",1);
        }
        else
        {
            timerLabel.text = "00:00:00";
            if (PlayerPrefs.GetInt("compWarn",2)==1)
            {
                Reward();
                PlayerPrefs.SetInt("compWarn",0);
            }
        }
            

    }
    void Reward()
    {
        int rd= UnityEngine.Random.Range(1, 3);
        rewardPanel.SetActive(true);
        if (rd==1)
        {
            suc1.SetActive(true);
            suc2.SetActive(false);
            suc3.SetActive(false);
            inv.increaseItem("SUC"+rd+".1");
        }
        if (rd == 2)
        {
            suc1.SetActive(false);
            suc2.SetActive(true);
            suc3.SetActive(false);
            inv.increaseItem("SUC" + rd + ".1");
        }
        if (rd == 3)
        {
            suc1.SetActive(false);
            suc2.SetActive(false);
            suc3.SetActive(true);
            inv.increaseItem("SUC" + rd + ".1");
        }
    }
    public void ResetClock () {
        TimeMaster.instance.SaveDate ();
        timer = timerSetUpMin * 60;
        TimeMaster.instance.SaveFF (timer.ToString());
        timerTemp = timer;
        timer -= TimeMaster.instance.CheckDate () [0];
    }
    public void Reinitialize () {

       // Debug.Log(PlayerPrefs.GetString("compWarn","Hola que hace"));

        this.ResetClock ();
    }
    public void AumentCounter () {
        timerSetUpMin += 1;
        textTimer.text = timerSetUpMin.ToString ("0");

    }
    public void DecreaseCounter () {
        if (timerSetUpMin != 0) {
            timerSetUpMin -= 1;
            textTimer.text = timerSetUpMin.ToString ("0");
        }

    }
    public void ChangeScene () {
        SceneManager.LoadScene (0);
    }
    public string Formatting(){
        float h,m,s;
        h=timer/3600;
        m=(timer%3600)/60;
        s=(timer%3600)%60;
        return Math.Floor(h).ToString()+":"+Math.Floor(m).ToString()+":"+Math.Floor(s).ToString("0");
    }

}