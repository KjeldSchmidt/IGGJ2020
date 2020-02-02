using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorInversion : MonoBehaviour
{
    private Material _colorInversionMaterial;
    public void Start()
    {
        Shader colorInversionShader = Shader.Find("ColorInversionShader");
        _colorInversionMaterial = new Material(colorInversionShader);
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, _colorInversionMaterial);
    }
}
