using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PietrarioRepository
{
    public ArrayList Pietrarios = new ArrayList();
    
    public void LoadPietrarios()
    {
        Debug.Log("Executed LoadPietrarios()");
        
        Pietrarios = new ArrayList();

        int idCounter = 1;
        while (PlayerPrefs.GetInt("id_pietrario_" + idCounter) != 0)
        {
            // Create and add existing Pietrarios to memory.
            Pietrario p = new Pietrario(
                PlayerPrefs.GetInt("id_pietrario_" + idCounter),
                PlayerPrefs.GetString("nombre_pietrario_" + idCounter),
                long.Parse(PlayerPrefs.GetString("last_timestamp_piet_" + idCounter)),
                PlayerPrefs.GetFloat("humidity_level_piet_" + idCounter),
                SucculentRepository.find(PlayerPrefs.GetString("id_suc_1_piet_" + idCounter)),
                SucculentRepository.find(PlayerPrefs.GetString("id_suc_2_piet_" + idCounter)),
                SucculentRepository.find(PlayerPrefs.GetString("id_suc_3_piet_" + idCounter)),
                PlayerPrefs.GetFloat("s1wl_piet_" + idCounter),
                PlayerPrefs.GetFloat("s2wl_piet_" + idCounter),
                PlayerPrefs.GetFloat("s3wl_piet_" + idCounter),
                PlayerPrefs.GetFloat("s1sl_piet_" + idCounter),
                PlayerPrefs.GetFloat("s2sl_piet_" + idCounter),
                PlayerPrefs.GetFloat("s3sl_piet_" + idCounter)
            );

            AddPietrario(p);

            // Debug.Log("Found Pietrario of Name: " + p.name);

            idCounter++;
            // TODO: Add lazy Suculenta loading.
        }
    }

    public void AddPietrario(Pietrario pietrario)
    {
        Debug.Log("Executed AddPietrario()");
        
        pietrario.id = Pietrarios.Count + 1;
        Pietrarios.Add(pietrario);
        Persist();
        LoadPietrarios();
    }

    // Unideal implementation, saves every Pietrario every time, even if it wasn't modified.
    public void Persist()
    {
        Debug.Log("Executed Persist()");
        
        foreach (Pietrario pietrario in Pietrarios)
        {
            pietrario.Save();
            // Debug.Log("Saved to Prefs Pietrario: " + pietrario.name);
        }
    }
}