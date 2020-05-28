using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class LightEstimator: MonoBehaviour {
    [SerializeField] private ARCameraManager _arCameraManager;

    [SerializeField] private Text accumulatorPreview;

    [SerializeField] private Image sunIconIndicator;

    private Color grayColor = new Color(40, 40, 40);

    private int frameCounter = 1;
    Pietrario pietrario;

    private void Start() {
        pietrario = (Pietrario) PietrarioRepository.LoadPietrarios()[0];
        PlayerPrefs.SetString("last_accumulator_timestamp", "0");
        //PlayerPrefs.SetInt("current_light_accumulator_value", 0);
        if (pietrario.sunLightLevel < 0) {
            pietrario.sunLightLevel = 0;
            pietrario.Save();
        }
    }

    private void OnEnable() {
        _arCameraManager.frameReceived += FrameUpdated;
    }

    private void OnDisable() {
        _arCameraManager.frameReceived -= FrameUpdated;
    }

    private void FrameUpdated(ARCameraFrameEventArgs args) {
        // Cada 60 frames
        if (frameCounter % 30 == 0 && args.lightEstimation.averageBrightness.HasValue) {
            float lightValue = args.lightEstimation.averageBrightness.Value;
            accumulatorPreview.text = pietrario.getRealLightLevel() + " Lux";
            attemptUpdateAccumulator(lightValue);
        }

        frameCounter++;
    }

    private void attemptUpdateAccumulator(float lightValue) {
        // Si ha pasado por lo menos 1s desde la última actualización, se actualizará.
        if (DateTime.Now.Ticks - long.Parse(PlayerPrefs.GetString("last_accumulator_timestamp")) > 500) {
            if (lightValue > 0.3) {
                PlayerPrefs.SetString("last_accumulator_timestamp", DateTime.Now.Ticks.ToString());
                float valueSnapshot = pietrario.getRealLightLevel();
                if (valueSnapshot < 100)
                    pietrario.setLightLevel(valueSnapshot + 1);
                sunIconIndicator.color = Color.white;
            } else {
                sunIconIndicator.color = grayColor;
            }

        }

    }
}