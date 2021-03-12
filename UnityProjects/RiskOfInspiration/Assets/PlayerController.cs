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
    
    public Rigidbody2D rb;

    public float rayOffsetY;
    public float rayOffsetX;
    public float rayLength;
    
    // Start is called before the first frame update
    void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.transform.position = GetComponent<SpawnManager>().transform.position;

        jumpHeight = 1;
        var position = spawnPoint.transform.position;
        gameObject.transform.position = new Vector3(position.x,position.y);
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    private void FixedUpdate() { 
        Move();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canjump) {
            StartCoroutine(Jump(jumpHeight));
        }
        
        var x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
        
    }

    

    

    IEnumerator Jump(float jumpHeight) {
        canjump = false;
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        yield return new WaitForSeconds(jumpSpeed);
        canjump = true;
    }
}
