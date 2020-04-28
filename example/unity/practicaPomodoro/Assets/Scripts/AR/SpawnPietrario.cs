using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPietrario : MonoBehaviour
{

    public GameObject pietrario;

    private PlacementIndicator placementIndicator;
    
    // Start is called before the first frame update
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject gameObject = Instantiate(pietrario, placementIndicator.transform.position,
                placementIndicator.transform.rotation);
        }
    }
}
