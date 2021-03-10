using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform spawnPoint;
    public bool canjump = true;
    public float moveSpeed;
    public float jumpHeight;
    public float jumpSpeed;
    
    public Rigidbody2D gamer;
    
    
    // Start is called before the first frame update
    void Awake() {
        gamer = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        gamer = gameObject.GetComponent<Rigidbody2D>();
        gamer.transform.position = GetComponent<SpawnManager>().player.transform.position;
        
        jumpHeight = 1;
        var position = spawnPoint.transform.position;
        gameObject.transform.position = new Vector3(position.x,position.y);
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canjump) {
            StartCoroutine(Jump(jumpHeight));
        }
        
        var x = Input.GetAxis("Horizontal");
        gamer.velocity = new Vector2(x * moveSpeed, gamer.velocity.y);
        
    }

    IEnumerator Jump(float jumpHeight) {
        canjump = false;
        gamer.velocity = new Vector2(gamer.velocity.x, jumpHeight);
        yield return new WaitForSeconds(jumpSpeed);
        canjump = true;
    }
}
