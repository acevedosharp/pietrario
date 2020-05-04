using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class LightEstimator : MonoBehaviour
{
    [SerializeField] private ARCameraManager _arCameraManager;

    [SerializeField] private Text brightnessPreview;

    private Light _light;

    private void Awake()
    {
        _light = GetComponent<Light>();
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
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            float lightValue = args.lightEstimation.averageBrightness.Value;
            _light.intensity = lightValue;


            brightnessPreview.text = lightValue.ToString();
        }
    }
}
