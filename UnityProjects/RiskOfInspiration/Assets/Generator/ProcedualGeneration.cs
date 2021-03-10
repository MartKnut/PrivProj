using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class ProcedualGeneration : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private int minStoneheight, maxStoneHeight;
    [SerializeField] private GameObject dirt, grass, stone, spawnPoint;
    //[SerializeField] private Tile dirt, grass, stone, spawnPoint;
    private int spawnX, spawnY;
    
        // Start is called before the first frame update
    void Awake()
    {
        Generation();
        
    }

    // Update is called once per frame
    void Generation()
    {
        
        for (int x = 0; x < width; x++) // Spawn tiles on the X
        {
            spawnX = Random.Range(x, width);

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
                if (y<totalStoneSpawnDistance) // Spawn Stone on a random distance from dirt between minstoneheight and maxstoneheight
                {
                    spawnObj(stone, x, y);
                }
                else // Place dirt above dirt by being above the maxstoneheight
                {
                    spawnObj(dirt,x,y);
                }
                
                if (x == spawnX && y == spawnY)
                {
                    spawnY = y + height;
                    spawnObj(spawnPoint, spawnX, spawnY);
                }

            }
            spawnObj(grass, x, height);
            

        }
        //Spawn the SpawnPoint
    }

    void spawnObj(GameObject obj,int width, int height)
    //void spawnObj(Tile obj,int width, int height)
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
    }

    
}
