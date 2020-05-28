using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PlacementIndicator: MonoBehaviour {

    private ARRaycastManager raycastManager;
    private GameObject placementIndicator;

    void Start() {
        //encuentro el objeto de ARRaycastManager
        raycastManager = FindObjectOfType < ARRaycastManager > ();
        //encuentro el objeto hijo de mi gameobject
        placementIndicator = transform.GetChild(0).gameObject;
        //coloco por defecto el indicador invisible
        placementIndicator.SetActive(false);
    }

    private void Update() {

        List < ARRaycastHit > hits = new List < ARRaycastHit > ();
        //creo mi raycast con una posicion, mis dimensiones fisicas y el tipo de superficies en las que se va a activar
        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0) {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!placementIndicator.activeInHierarchy) {
                placementIndicator.SetActive(true);
            }
        }

    }
}