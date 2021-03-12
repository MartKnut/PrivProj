using System;
using UnityEngine;
using static System.Random;
using Random = UnityEngine.Random;

public class PerlinNoise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public float scale = 20;

    public float offsetX = 100f;
    public float offsetY = 100f;

    public float seed;
    
    private Renderer _renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        
        if (seed == 0f)
        {
            // 1999999
            seed = Random.Range(-1999999f, 1999999f);
            offsetX = seed;
            offsetY = seed;
        }
        else
        {
            offsetX = seed;
            offsetY = seed;
        }
        
        

        
    }

    // Update is called once per frame
    private void Update()
    {
        _renderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width,height);

        // Generate a Perlin Noise map for the texture
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x,y,color);
            }
        }
        
        texture.Apply();
        return texture;
    }

    Color CalculateColor(int x, int y)
    {
        float xCoord = (float) x / width * scale + offsetX;
        float yCoord = (float) y / height * scale + offsetY;
        
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
