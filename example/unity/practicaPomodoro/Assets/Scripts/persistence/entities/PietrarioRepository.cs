using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PietrarioRepository : MonoBehaviour
{

public InputField nameInput;
public GameObject success_panel;


    public void Start(){

        success_panel.SetActive(false);
    }
  
    public void AddPietrario() {
      Pietrario pietrario = new Pietrario(1,nameInput.text,1,0,0);
      SavePietrario(pietrario);
      success_panel.SetActive(true);
    }


    public void SavePietrario(Pietrario pietrario) {

        PlayerPrefs.SetInt("id_pietrario", pietrario.id);
        PlayerPrefs.SetString("nombre_pietrario", pietrario.name);
        PlayerPrefs.SetInt("id_suc_1", pietrario.S1);
        PlayerPrefs.SetInt("id_suc_2", pietrario.S2);
        PlayerPrefs.SetInt("id_suc_3", pietrario.S3);
        
        print ("Creado");
     }

    public void Reset(){
        PlayerPrefs.DeleteAll();
    }
   
    
}
