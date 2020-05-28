using System;
using UnityEngine;

//Clase de pietrario única
public class Pietrario {

    public int id;
    public string name;
    public int S1, S2, S3;
    public long creationDate;
    public long lastTimestamp;
    public float humidityLevel;
    public Succulent s1, s2, s3;
    public float s1wl, s2wl, s3wl; // Water level
    public long dtS1, dtS2, dtS3; //last Change in each Succulent
    public float sunLightLevel; // Sunlight level
    public float decaySunLightLevel;
    public long dtL; //Last change in sunLight
    public Guardian guardian;

    public Pietrario(int id, string name, long creationDate, float humidityLevel, Succulent s1, Succulent s2, Succulent s3, float s1Wl, float s2Wl, float s3Wl, long dtS1, long dtS2, long dtS3, long dtL, float sunLightLevel, float decaySunLightLevel, Guardian guardian) {
        this.id = id;
        this.name = name;
        this.creationDate = creationDate;
        this.humidityLevel = humidityLevel;
        this.s1 = s1;
        this.s2 = s2;
        this.s3 = s3;
        s1wl = s1Wl;
        s2wl = s2Wl;
        s3wl = s3Wl;
        this.dtS1 = dtS1;
        this.dtS2 = dtS2;
        this.dtS3 = dtS3;
        this.sunLightLevel = sunLightLevel;
        this.dtL = dtL;
        this.decaySunLightLevel = decaySunLightLevel;
        this.guardian = guardian;


        if (s1 != null) {
            s1.waterLevel = s1Wl;
            s1.lastTimeChanged = dtS1;
        }
        if (s2 != null) {
            s2.waterLevel = s2Wl;
            s2.lastTimeChanged = dtS2;
        }
        if (s3 != null) {
            s3.waterLevel = s3Wl;
            s3.lastTimeChanged = dtS3;
        }

        lastTimestamp = creationDate;
    }

    // This class needs a save method for persistence

    //Permite el guardado
    public void Save() {
        PlayerPrefs.SetInt("id_pietrario_" + id, id);
        PlayerPrefs.SetString("nombre_pietrario_" + id, name);
        PlayerPrefs.SetString("fecha_creacion_piet_" + id, creationDate.ToString()); // long value stored as string!!
        PlayerPrefs.SetString("last_timestamp_piet_" + id, lastTimestamp.ToString()); // long value stored as string!!
        PlayerPrefs.SetFloat("humidity_level_piet_" + id, humidityLevel);
        PlayerPrefs.SetFloat("sunLightLevel " + id, sunLightLevel);
        PlayerPrefs.SetFloat("decaySunLightLevel " + id, decaySunLightLevel);
        PlayerPrefs.SetString("dtL" + id, dtL.ToString());

        if (s1 == null) {
            PlayerPrefs.SetString("id_suc_1_piet_" + id, "null");
            PlayerPrefs.SetFloat("s1wl_piet_" + id, 0);
            PlayerPrefs.SetString("dtS1 " + id, "0");
        } else {
            this.dtS1 = DateTime.Now.Ticks;
            PlayerPrefs.SetString("id_suc_1_piet_" + id, s1.persistentId);
            PlayerPrefs.SetFloat("s1wl_piet_" + id, s1wl);
            PlayerPrefs.SetString("dtS1 " + id, dtS1.ToString());
        }

        if (s2 == null) {
            PlayerPrefs.SetString("id_suc_2_piet_" + id, "null");
            PlayerPrefs.SetFloat("s2wl_piet_" + id, 0);
            PlayerPrefs.SetString("dtS2 " + id, "0");
        } else {
            PlayerPrefs.SetString("id_suc_2_piet_" + id, s2.persistentId);
            PlayerPrefs.SetFloat("s2wl_piet_" + id, s2wl);
            PlayerPrefs.SetString("dtS2 " + id, dtS2.ToString());
        }

        if (s3 == null) {
            PlayerPrefs.SetString("id_suc_3_piet_" + id, "null");
            PlayerPrefs.SetFloat("s3wl_piet_" + id, 0);
            PlayerPrefs.SetString("dtS3 " + id, "0");
        } else {
            PlayerPrefs.SetString("id_suc_3_piet_" + id, s3.persistentId);
            PlayerPrefs.SetFloat("s3wl_piet_" + id, s3wl);
            PlayerPrefs.SetString("dtS3 " + id, dtS3.ToString());
        }

        if (guardian == null) {
            PlayerPrefs.SetString("idGuardian " + id, "null");
        } else {
            PlayerPrefs.SetString("idGuardian " + id, guardian.id);
        }
    }

    //Determina la cantidad de luz
    public void setLightLevel(float newValue) {
        newValue = Math.Min(100, newValue);
        sunLightLevel = newValue;
        PlayerPrefs.SetFloat("sunLightLevel " + id, newValue);

        dtL = DateTime.Now.Ticks;
        PlayerPrefs.SetString("dtL" + id, dtL.ToString());
    }


    //Obtiene la cantidad de luz real
    public float getRealLightLevel() {
        return (float) Math.Round(PlayerPrefs.GetFloat("sunLightLevel " + id), 1);
    }

    public override string ToString() {
        return id + ", " + name + ", " + creationDate + ", " + humidityLevel + ", " + s1wl + ", " + s2wl + ", " + s3wl + ", " + sunLightLevel + ", " + dtS1 + ", " + dtS2 + ", " + dtS3;
    }
}