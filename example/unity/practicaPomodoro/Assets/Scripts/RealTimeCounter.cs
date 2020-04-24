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
    public static RealTimeCounter instance;
    [SerializeField] Text timerLabel;
    [SerializeField] Text textTimer;
    void Start () {
        timer = TimeMaster.instance.CheckDate () [1];
        timerSetUpMin = 0;
        timerTemp = 0;
        timer -= TimeMaster.instance.CheckDate () [0];
        tempseg = 0;
        instance = this;
        //this.enabled = false;
        print (timer);
        print (TimeMaster.instance.CheckDate () [0]);
        print (TimeMaster.instance.CheckDate () [1]);
    }
    void Update () {
        if (timer > 0) {
            timer -= Time.deltaTime;
            timerLabel.text = Formatting();
        }
        else
            timerLabel.text="00:00:00";

    }

    public void ResetClock () {
        TimeMaster.instance.SaveDate ();
        timer = timerSetUpMin * 60;
        TimeMaster.instance.SaveFF (timer.ToString());
        timerTemp = timer;
        timer -= TimeMaster.instance.CheckDate () [0];
    }
    public void Reinitialize () {

        //this.enabled = true;

        this.ResetClock ();
    }
    /*public string Formatting () {
        if (!timer.ToString ("0").Equals (timerTemp.ToString ("0"))) {
            timerTemp = timer;
            tempseg -= 1;
            if (tempseg < 0) {
                timerSetUpMin -= 1;
                tempseg = 59;
            }

            return timerSetUpMin.ToString ("0") + ':' + tempseg.ToString ("0");
        } else
            return timerSetUpMin.ToString ("0") + ':' + tempseg.ToString ("0");

    }*/
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