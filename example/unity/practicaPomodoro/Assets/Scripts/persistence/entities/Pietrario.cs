using UnityEngine;


public class Pietrario
{
    public int id;
    public string name;
    public long creationDate;
    public long lastTimestamp;
    public float humidityLevel;
    public Succulent s1, s2, s3;
    public float s1wl, s2wl, s3wl; // Water level
    public float s1sl, s2sl, s3sl; // Sunlight level

    public Pietrario(int id, string name, long creationDate, float humidityLevel, Succulent s1, Succulent s2, Succulent s3, float s1Wl, float s2Wl, float s3Wl, float s1Sl, float s2Sl, float s3Sl)
    {
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
        s1sl = s1Sl;
        s2sl = s2Sl;
        s3sl = s3Sl;

        if (s1 != null)
        {
            s1.waterLevel = s1Wl;
            s1.sunlightLevel = s1Sl;
        }
        if (s2 != null)
        {
            s2.waterLevel = s2Wl;
            s2.sunlightLevel = s2Sl;
        }
        if (s3 != null)
        {
            s3.waterLevel = s3Wl;
            s3.sunlightLevel = s3Sl;
        }
        
        lastTimestamp = creationDate;
    }

    public void updateWithGivenTimeMilis(long timeToEvaluate)
    {
        long delta = timeToEvaluate - lastTimestamp;
        
        s1.update(delta);
        s2.update(delta);
        s3.update(delta);

        lastTimestamp = timeToEvaluate;
    }

    // This class needs a save method for persistence
    public void Save()
    {
        PlayerPrefs.SetInt("id_pietrario_" + id, id);
        PlayerPrefs.SetString("nombre_pietrario_" + id, name);
        PlayerPrefs.SetString("fecha_creacion_piet_" + id, creationDate.ToString()); // long value stored as string!!
        PlayerPrefs.SetString("last_timestamp_piet_" + id, lastTimestamp.ToString()); // long value stored as string!!
        PlayerPrefs.SetFloat("humidity_level_piet_" + id, humidityLevel);
        PlayerPrefs.SetString("id_suc_1_piet_" + id, s1.persistentId);
        PlayerPrefs.SetString("id_suc_2_piet_" + id, s2.persistentId);
        PlayerPrefs.SetString("id_suc_3_piet_" + id, s3.persistentId);
        
        PlayerPrefs.SetFloat("s1wl_piet_" + id, s1wl);
        PlayerPrefs.SetFloat("s2wl_piet_" + id, s2wl);
        PlayerPrefs.SetFloat("s3wl_piet_" + id, s3wl);
        
        PlayerPrefs.SetFloat("s1sl_piet_" + id, s1sl);
        PlayerPrefs.SetFloat("s2sl_piet_" + id, s2sl);
        PlayerPrefs.SetFloat("s3sl_piet_" + id, s3sl);
    }

    public override string ToString()
    {
        return s1 +" | "+ s2 + " | "+ s3;
    }
}
