using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RealTimeCounter : MonoBehaviour {
    public float timer;
    public float timerSetUpMin;
    public int tempseg;
    public float timerTemp;
    public static RealTimeCounter instance;
    [SerializeField] Text timerLabel;
    [SerializeField] Text textTimer;
    void Start () {
        timer = TimeMaster.instance.CheckDate ()[1];
        timerSetUpMin = 0;
        timerTemp = 0;
        timer -= TimeMaster.instance.CheckDate ()[0];
        tempseg = 0;
        instance = this;
        //this.enabled = false;
    }
    void Update () {
        if (timer > 0) {
            timerLabel.text = this.Formatting ();
            timer -= Time.deltaTime;
            //timer-= TimeMaster.instance.CheckDate ();
            
        } else {
            timerLabel.text = "00:00";
        }
        print (timer);

    }

    public void ResetClock () {
        TimeMaster.instance.SaveDate ();
        timer = timerSetUpMin * 60;
        timerTemp = timer;
        timer -= TimeMaster.instance.CheckDate ()[0];
    }
    public void Reinitialize () {

        //this.enabled = true;
        this.ResetClock ();
    }
    public string Formatting () {
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
    public void ShangeScene () {
        SceneManager.LoadScene (1);
    }

}