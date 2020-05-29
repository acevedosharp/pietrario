using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController: MonoBehaviour {
    // El motivo por el que existe un método (este) que sólo llama a otro es para evitar instanciar la clase PietrarioRepository.
    public void ResetPlayerPrefs() {
        PietrarioRepository.Reset();
    }
}