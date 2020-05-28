using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
//pomodoro

public class RealTimeCounter: MonoBehaviour {
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
    //Inicializa, instacia, y realiza una vez
    void Start() {
        if (PlayerPrefs.GetInt("compWarn", 2) == 2) {
            PlayerPrefs.SetInt("compWarn", 0);
        }
        compWarn = PlayerPrefs.GetInt("compWarn", 2);

        timer = TimeMaster.instance.CheckDate()[1];
        timerSetUpMin = 0;
        timerTemp = 0;
        timer -= TimeMaster.instance.CheckDate()[0];
        tempseg = 0;
        instance = this;
    }
    //Actualiza cada vez que se llegue al 0 o el usuario lo force
    void Update() {
        if (timer > 0) {
            timer -= Time.deltaTime;
            timerLabel.text = Formatting();
            PlayerPrefs.SetInt("compWarn", 1);
        } else {
            timerLabel.text = "00:00:00";
            if (PlayerPrefs.GetInt("compWarn", 2) == 1) {
                Reward();
                PlayerPrefs.SetInt("compWarn", 0);
            }
        }


    }

    //Realiza un control de forma que una vez se termine el contador regresivo, da un mensaje con una recompensa al usuario
    void Reward() {
        int rd = UnityEngine.Random.Range(1, 3);
        rewardPanel.SetActive(true);
        if (rd == 1) {
            suc1.SetActive(true);
            suc2.SetActive(false);
            suc3.SetActive(false);
            inv.increaseItem("SUC" + rd + ".1");
        }
        if (rd == 2) {
            suc1.SetActive(false);
            suc2.SetActive(true);
            suc3.SetActive(false);
            inv.increaseItem("SUC" + rd + ".1");
        }
        if (rd == 3) {
            suc1.SetActive(false);
            suc2.SetActive(false);
            suc3.SetActive(true);
            inv.increaseItem("SUC" + rd + ".1");
        }
    }

    //Reinicia el reloj cuando es requerido
    public void ResetClock() {
        TimeMaster.instance.SaveDate();
        timer = timerSetUpMin * 60;
        TimeMaster.instance.SaveFF(timer.ToString());
        timerTemp = timer;
        timer -= TimeMaster.instance.CheckDate()[0];
    }
    public void Reinitialize() {

        // Debug.Log(PlayerPrefs.GetString("compWarn","Hola que hace"));

        this.ResetClock();
    }
    //Realiza control sobre el botón de aumentar el contador (por minutos)
    public void AumentCounter() {
        timerSetUpMin += 1;
        textTimer.text = timerSetUpMin.ToString("0");

    }
    //Realiza control sobre el botón de disminuir el contador (por minutos)

    public void DecreaseCounter() {
        if (timerSetUpMin != 0) {
            timerSetUpMin -= 1;
            textTimer.text = timerSetUpMin.ToString("0");
        }

    }
    //Carga nueva escena cuando es requerido
    public void ChangeScene() {
        SceneManager.LoadScene(0);
    }

    //Realiza un formato al tiempo de modo que sea de entendimientos para el usuario
    public string Formatting() {
        float h, m, s;
        h = timer / 3600;
        m = (timer % 3600) / 60;
        s = (timer % 3600) % 60;
        return Math.Floor(h).ToString() + ":" + Math.Floor(m).ToString() + ":" + Math.Floor(s).ToString("0");
    }

}