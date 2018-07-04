using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour {
    /*
     * This is for part 4.
     * 
     * This script generates a terrain perlin noise with random seed so that each
     * time start the scene will give a different landscape.
     */

    // set the attribute of the terrain
    public int depth = 3;
    public int width = 50;
    public int height = 50;

    // set the scale parameter to adjust the steepness. 
    public float scale = 10.0f;

	// Use this for initialization
	void Start() {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
	}

    private TerrainData GenerateTerrain(TerrainData terrainData)
    {
        // Generate the Terrain
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeight());

        return terrainData;

    }

    private float[,] GenerateHeight()
    {
        // for each unit, generate the height of the terrain
        float[,] heights = new float[width, height];

        for (int i = 0; i < width; i ++) {
            for (int j = 0; j < height; j ++) {
                heights[i, j] = CalculateHeight(i, j);
            }
        }
        return heights;
    }

    private float CalculateHeight(int i, int j)
    {
        // use perlin noise with random seed to calculate the height for each
        // coordinates GenerateHeight() give.

        float xCoord = (float)i / width * scale *  (0.5f * Random.value);
        float yCoord = (float)j / height * scale * (0.5f * Random.value);

        return Mathf.PerlinNoise(xCoord, yCoord);
    }

}
