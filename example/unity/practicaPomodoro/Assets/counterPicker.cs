using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counterPicker : MonoBehaviour
{
    float currentTime=0;
    float startingTime=10;

    [SerializeField] Text labelText;

    void Start()
    {
      currentTime=startingTime;  
    }
    void Update()
    {
        currentTime -= 1*Time.deltaTime;
        labelText.text=currentTime.ToString();
    }
    
}
