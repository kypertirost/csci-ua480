

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametricLandscape : MonoBehaviour
{

    public int uDivs = 90;
    public int vDivs = 90;

    void Start()
    {
        GetComponent<MeshFilter>().mesh = Grid.Generate(uDivs, vDivs, Landscape);
    }

    Vector3 Landscape(float u, float v)
    {
        float distance = Vector2.Distance(new Vector2(u, v), new Vector2(.5f, .5f));
        float d = Mathf.Max(0f, distance - .2f);

        float noise1 = CT.Noise.GetNoise(new Vector3(3 * u, 3 * v, 0.5f));
        float noise2 = CT.Noise.GetNoise(new Vector3(12 * u, 12 * v, 4.5f));

        return new Vector3(2 * u - 1,
                           (d * .5f - d * -1.0f * (noise1 + noise2 * .2f)),
                           2 * v - 1);
    }

}
