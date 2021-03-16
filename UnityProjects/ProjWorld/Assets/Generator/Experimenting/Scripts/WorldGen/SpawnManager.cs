using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    private static SpawnManager instance;
    private Transform spawn;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        spawn = gameObject.GetComponent<Transform>();
        spawnPlayer();
    }

    

    private void spawnPlayer()
    {
        player.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y,
            spawn.transform.position.z);
        Instantiate(player);
    }


}
