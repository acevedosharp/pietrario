using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPietrario : MonoBehaviour
{

    public GameObject pietrario;

    private PlacementIndicator placementIndicator;

    private int no_pietrario = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && no_pietrario<1)
        {
            GameObject gameObject = Instantiate(pietrario, placementIndicator.transform.position,
                placementIndicator.transform.rotation);
            no_pietrario++;
        }
    }
}
