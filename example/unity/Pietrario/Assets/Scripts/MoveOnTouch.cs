using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveOnTouch: MonoBehaviour {
    public Touch click;
    private float controller;
    Quaternion pr;
    void Start() {
        controller = 0.3f;
        pr = transform.rotation;
    }

    //este update es llamado una vez por cuadro

    //este método controla el movimiento del pietrario antes estático, el movimiento se da con el dedo del usuario
    void Update() {

        if (Input.touchCount > 0) {
            click = Input.GetTouch(0);
            //print (click);
            if (click.phase == TouchPhase.Moved) {
                transform.Rotate(new Vector3(-click.deltaPosition.y * controller, -click.deltaPosition.x * controller, 0));
            }
        } else {
            if (transform.rotation != pr) {
                transform.rotation = Quaternion.Lerp(transform.rotation, pr, Time.time * 0.01f);
            }
        }
    }
}