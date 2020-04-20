using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMaster : MonoBehaviour {
    DateTime currentDate;
    DateTime oldDate;

    public string saveLocation;
    public static TimeMaster instance;

    void Awake () {
        instance = this;

        saveLocation = "Last";

    }
    public float[] CheckDate () {
        currentDate = System.DateTime.Now;
        string tempString = PlayerPrefs.GetString (saveLocation, "1");
        long tempLong = Convert.ToInt64 (tempString);
        print(currentDate);
        DateTime oldDate = DateTime.FromBinary (tempLong);
        print ("Old Date : " + oldDate);
        TimeSpan difference = currentDate.Subtract (oldDate);
        print ("Difference: " + difference);
        float [] samp=new float[2];
        samp[0]= (float) difference.TotalSeconds;
        samp[1]=(float) oldDate.Second;
        return samp;

    }
    public void SaveDate () {
        PlayerPrefs.SetString (saveLocation, System.DateTime.Now.ToBinary ().ToString ());
     }
}