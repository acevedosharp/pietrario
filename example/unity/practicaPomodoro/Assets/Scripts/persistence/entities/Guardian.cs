using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Clase guardianes
public class Guardian {
    public string id;
    public string name;
    public string mensaje;

    public Guardian(string id, string name, string mensaje) {
        this.id = id;
        this.name = name;
        this.mensaje = mensaje;
    }
}