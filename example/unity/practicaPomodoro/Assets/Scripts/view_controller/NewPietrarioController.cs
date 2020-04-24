using System;
using UnityEngine;
using UnityEngine.UI;

public class NewPietrarioController : MonoBehaviour
{
    public InputField nameInput;
    public GameObject success_panel;
    // Start is called before the first frame update
    void Start()
    {
        success_panel.SetActive(false);
    }

    public void saveNewPietrario()
    {
        Pietrario pietrario = new Pietrario(
            0, 
            nameInput.text, 
            DateTime.Now.Ticks, 
            50, 
            SucculentRepository.find("SUC1"), 
            null, null, 0,0,0, 0, 0, 0); // Ignored.
        
        PietrarioRepository.AddPietrario(pietrario);
        success_panel.SetActive(true);
    }
}
