using System;
using UnityEngine;
using UnityEngine.UI;

public class NewPietrarioController: MonoBehaviour {
    public InputField nameInput;
    public GameObject success_panel;
    // Start is called before the first frame update
    void Start() {
        success_panel.SetActive(false);
    }
    //Realiza un guardado del primer pietrario, una vez creado, deja todo listo para su uso.
    public void saveNewPietrario() {
        Pietrario pietrario = new Pietrario(
            0,
            nameInput.text,
            DateTime.Now.Ticks,
            50,
            null,
            null, null, 0, 0, 0, DateTime.Now.Ticks, DateTime.Now.Ticks, DateTime.Now.Ticks, DateTime.Now.Ticks, 100, 0.2f, null); // Ignored.
        PietrarioRepository.AddPietrario(pietrario);
        success_panel.SetActive(true);

        PlayerPrefs.SetString("luzTutorialHasBeenCalled", "false");
        PlayerPrefs.SetString("ARTutorialHasBeenCalled", "false");
        PlayerPrefs.SetString("pomodoroTutorialHasBeenCalled", "false");
    }
}