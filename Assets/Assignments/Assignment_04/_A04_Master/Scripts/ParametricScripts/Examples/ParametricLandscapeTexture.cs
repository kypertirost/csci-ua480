using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametricLandscapeTexture : MonoBehaviour
{

    public int uDivs = 90;
    public int vDivs = 90;
    public Texture2D texture;
    public float height = .1f;

    void Start()
    {
        GetComponent<MeshFilter>().mesh = Grid.Generate(uDivs, vDivs, Landscape);
    }

    Vector3 Landscape(float u, float v)
    {
        Color color = texture.GetPixel((int)(u * texture.width),(int) (v * texture.height));
        return new Vector3(u, color.r * height, v);
    }

}
