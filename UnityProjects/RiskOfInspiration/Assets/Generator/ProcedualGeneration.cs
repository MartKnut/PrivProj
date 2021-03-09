using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProcedualGeneration : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private int minStoneheight, maxStoneHeight;
    [SerializeField] private GameObject dirt, grass, stone;
    
    
        // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

    // Update is called once per frame
    void Generation()
    {
        for (int x = 0; x < width; x++) // Spawn tiles on the X
        {
            // set a min and max alternation height
            int minHeight = height - 1;
            int maxHeight = height + 2;
            // Use the min and max to randomly alternate eZ terrain
            height = Random.Range(minHeight, maxHeight);
            // Stone
            int minStoneSpawnDistance = height - minStoneheight;
            int maxStoneSpawnDistance = height - maxStoneHeight;
            int totalStoneSpawnDistance = Random.Range(minStoneSpawnDistance, maxStoneSpawnDistance);
            for (int y = 0; y < height; y++) // Spawn tiles on the Y
            {
                if (y<totalStoneSpawnDistance)
                {
                    spawnObj(stone, x, y);
                }
                else
                {
                    spawnObj(dirt,x,y);
                }
            }
            spawnObj(grass, x, height);
        }
    }

    void spawnObj(GameObject obj,int width, int height)
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
    }

}
