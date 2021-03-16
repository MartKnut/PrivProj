using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP_ProceduralGeneration : MonoBehaviour
{
    public GameObject spawnPoint;
    
    public int sizeX, sizeZ;

    public int groundHeight;
    public float terrainDetail;
    public float terrainHeight;
    public int seed;
    
    public GameObject[] blocks;
    
    // Start is called before the first frame update
    void Start()
    {
        if (seed == 0)
        {
            seed = Random.Range(100000, 999999);
        }
        GenerateTerrain();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateTerrain() { 
        for (int x = 0; x < sizeX; x++) {
            for (int z = 0; z < sizeZ; z++)
            {
                int maxY = (int)(Mathf.PerlinNoise((x * .5f + seed) / terrainDetail, (z * .5f + seed) / terrainDetail) *
                        terrainHeight);
                maxY += groundHeight;
                
                GameObject grass = Instantiate(blocks[0], new Vector3(x, maxY, z), Quaternion.identity);
                grass.transform.SetParent(GameObject.FindGameObjectWithTag("WorldGen").transform);

                for (int y = 0; y < maxY; y++)
                {
                    int dirtLayers = Random.Range(1, 5);
                    if (y>=maxY-dirtLayers) {
                        GameObject dirt = Instantiate(blocks[2], new Vector3(x, y, z), Quaternion.identity);
                        dirt.transform.SetParent(GameObject.FindGameObjectWithTag("WorldGen").transform);
                    } else {
                        GameObject stone = Instantiate(blocks[1], new Vector3(x, y, z), Quaternion.identity);
                        stone.transform.SetParent(GameObject.FindGameObjectWithTag("WorldGen").transform);
                    }
                }
                
                if (x == (int) (sizeX * .5f) && z == (int) (sizeZ * .5f))
                {
                    Instantiate(spawnPoint, new Vector3(x, maxY + 3, z), Quaternion.identity);
                }
            }
        }
    }
}
