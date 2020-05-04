using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class LightEstimator : MonoBehaviour
{
    [SerializeField] private ARCameraManager _arCameraManager;

    [SerializeField] private Text accumulatorPreview;

    [SerializeField] private Image sunIconIndicator;

    private int frameCounter = 1;

    private void Start()
    {
        PlayerPrefs.SetString("last_accumulator_timestamp", "0");
        PlayerPrefs.SetInt("current_light_accumulator_value", 0);
    }

    private void OnEnable()
    {
        _arCameraManager.frameReceived += FrameUpdated;
    }

    private void OnDisable()
    {
        _arCameraManager.frameReceived -= FrameUpdated;
    }

    private void FrameUpdated(ARCameraFrameEventArgs args)
    {
        // Cada 60 frames
        if (frameCounter % 60 == 0 && args.lightEstimation.averageBrightness.HasValue)
        {
            float lightValue = args.lightEstimation.averageBrightness.Value;
            accumulatorPreview.text = PlayerPrefs.GetInt("current_light_accumulator_value") + " Lux";

            attemptUpdateAccumulator(lightValue);
        }

        frameCounter++;
    }

    private void attemptUpdateAccumulator(float lightValue)
    {
        // Si ha pasado por lo menos 1s desde la última actualización, se actualizará.
        if (DateTime.Now.Ticks - long.Parse(PlayerPrefs.GetString("last_accumulator_timestamp")) > 1000)
        {
            if (lightValue > 0.3)
            {
                PlayerPrefs.SetString("last_accumulator_timestamp", DateTime.Now.Ticks.ToString());
                int currentAccValue = PlayerPrefs.GetInt("current_light_accumulator_value");
                if (currentAccValue < 100)
                    PlayerPrefs.SetInt("current_light_accumulator_value", currentAccValue + 1);
                
                sunIconIndicator.color = Color.white;
            }
            else
            {
                sunIconIndicator.color = Color.grey;
            }
            
        }
        
    }
}