using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientScript: MonoBehaviour {
    public UnityEngine.UI.RawImage RawImage;

    private Texture2D backgroundTexture;
    private Color color1;
    private Color color2;

    //Asigna las texturas iniciales
    void Awake() {
        backgroundTexture = new Texture2D(1, 2);
        backgroundTexture.wrapMode = TextureWrapMode.Clamp;
        backgroundTexture.filterMode = FilterMode.Bilinear;
        SetColor(new Color(0.75F, 0.75F, 0.75F), Color.gray);
    }
    //Establece el color por defecto
    public void SetColor(Color color1, Color color2) {
        backgroundTexture.SetPixels(new Color[] {
            color1,
            color2
        });
        backgroundTexture.Apply();
        RawImage.texture = backgroundTexture;
    }
}