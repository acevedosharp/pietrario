using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Hace posible la rotación del pietrario y a su vez la configura
public class Rotator: MonoBehaviour {
    public float speed = 50 f;

    // Update is called once per frame
    void Update() {
        transform.Rotate(0 f, speed * Time.deltaTime, 0 f);
    }
}