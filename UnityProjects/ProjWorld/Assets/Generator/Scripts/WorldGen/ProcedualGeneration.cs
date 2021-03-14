using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class ProcedualGeneration : MonoBehaviour
{
    [SerializeField] private int width, height, debth;
    [SerializeField] private int minStoneheight, maxStoneHeight;
    [SerializeField] private GameObject dirt, grass, stone, spawnPoint;
    //[SerializeField] private Tile dirt, grass, stone, spawnPoint;
    private int spawnX, spawnY, spawnZ;

    
        // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

    // Update is called once per frame
    void Generation() {
        for (int x = 0; x < width; x++) // Spawn tiles on the X{
            for (int z = 0; z < debth; z++) {
                spawnX = Random.Range(x, width);
                spawnZ = Random.Range(z, debth);
                
                
                //set a min and max alternation height
                // int minHeight = height - 1;
                // int maxHeight = height + 2;
                //Use the min and max to randomly alternate eZ terrain
                // height = Random.Range(minHeight, maxHeight);
                

                // Stone
                int minStoneSpawnDistance = height - minStoneheight;
                int maxStoneSpawnDistance = height - maxStoneHeight;
                int totalStoneSpawnDistance = Random.Range(minStoneSpawnDistance, maxStoneSpawnDistance);

                
                for (int y = 0; y < height; y++) // Spawn tiles on the Y
                {
                    
                    
                    if (y<totalStoneSpawnDistance) // Spawn Stone on a random distance from dirt between minstoneheight and maxstoneheight
                    {
                        spawnObj(stone, x, y,z);
                    }
                    else // Place dirt above stone by being above the maxstoneheight
                    {
                        spawnObj(dirt,x,y,z);
                    }

                    if (x == spawnX && y == spawnY && z == spawnZ) 
                    {
                        spawnY = height + 2;
                        
                        spawnObj(spawnPoint, spawnX, spawnY, spawnZ);
                    }
   
                }
                spawnObj(grass, x, height, z);
            }
        //Spawn the SpawnPoint
    }

    void spawnObj(GameObject obj,int width, int height, int debth)
    //void spawnObj(Tile obj,int width, int height)
    {
        obj = Instantiate(obj, new Vector3(width, height,debth), Quaternion.identity);
        obj.transform.parent = this.transform;
    }

    
}
