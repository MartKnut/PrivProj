using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private static FollowPlayer instance;
    public GameObject camera;
    public Rigidbody player;
    // Start is called before the first frame update
    

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().rb;
    }

    private void Update()
    {
        var position = player.transform.position;
        camera.transform.position = new Vector3(position.x, position.y, position.z);
    }
}
