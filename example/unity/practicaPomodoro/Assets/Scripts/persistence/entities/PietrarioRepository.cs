using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PietrarioRepository : MonoBehaviour
{
    public ArrayList Pietrarios = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        AddPietrario(new Pietrario(1,"Pietrario 1", 1, 2, 3));
        LoadPietrarios();
        
    }

    public void LoadPietrarios()
    {
        Pietrarios = new ArrayList();
        
        int idCounter = 1;
        while (PlayerPrefs.GetInt("id_pietrario_"+idCounter) != 0)
        {
            // Create and add existing Pietrarios to memory.
            Pietrario p = new Pietrario(
                PlayerPrefs.GetInt("id_pietrario_" + idCounter),
                PlayerPrefs.GetString("nombre_pietrario_" + idCounter),
                PlayerPrefs.GetInt("id_suc_1_piet" + idCounter),
                PlayerPrefs.GetInt("id_suc_2_piet" + idCounter),
                PlayerPrefs.GetInt("id_suc_3_piet" + idCounter)
            );
            
            AddPietrario(p);
            
            print("Found Pietrario of Name: "+p.Name);
            
            idCounter++;
            // TODO: Add lazy Suculenta loading.
        } 

    
    }

    public void AddPietrario(Pietrario pietrario)
    {
        pietrario.id = Pietrarios.Count + 1;
        Pietrarios.Add(pietrario);
        Persist();
        LoadPietrarios();
    }

    // Unideal implementation, saves every Pietrario every time, even if it wasn't modified.
    public void Persist()
    {
        foreach (Pietrario pietrario in Pietrarios)
        {
            pietrario.Save();
            Debug.Log("Saved to Prefs Pietrario: " + pietrario.Name);
        }
    }
}
