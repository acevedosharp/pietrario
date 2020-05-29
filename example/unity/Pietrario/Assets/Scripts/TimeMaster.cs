using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Se encarga del control general sobre el pomodoro, da impresiones de los eventos en consola, y permite llevar el control de algoritmo
public class TimeMaster: MonoBehaviour {
    DateTime currentDate;
    DateTime oldDate;

    public string saveLocation, saveFirstTime;
    public static TimeMaster instance;

    void Awake() {
        instance = this;

        saveLocation = "Last";
        saveFirstTime = "FyFF";
    }
    public float[] CheckDate() {
        currentDate = System.DateTime.Now;
        string tempString = PlayerPrefs.GetString(saveLocation, "1");
        string tempOrig = PlayerPrefs.GetString(saveFirstTime, "2");
        long tempLong = Convert.ToInt64(tempString);
        long tempLong1 = Convert.ToInt64(tempOrig);
        print(currentDate);
        DateTime oldDate = DateTime.FromBinary(tempLong);
        int origTt = Convert.ToInt32(tempLong1);
        print("Old Date : " + oldDate);
        print("First Date : " + origTt);
        TimeSpan difference = currentDate.Subtract(oldDate);
        print("Difference: " + difference);
        float[] samp = new float[2];
        samp[0] = (float) difference.TotalSeconds;
        samp[1] = (float) origTt;
        return samp;

    }
    public void SaveDate() {
        PlayerPrefs.SetString(saveLocation, System.DateTime.Now.ToBinary().ToString());
    }
    public void SaveFF(string timeSeg) {
        PlayerPrefs.SetString(saveFirstTime, timeSeg);
    }

}