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
    
    public Rigidbody rb;

    private float x, z;
    
    // public float rayOffsetY;
    // public float rayOffsetX;
    // public float rayOffsetZ;
    // public float rayLength;
    
    //Start is called before the first frame update
    void Awake() {
        rb = gameObject.GetComponent<Rigidbody>();

    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.transform.position = GetComponent<SpawnManager>().transform.position;

        jumpHeight = 1;
        var position = spawnPoint.transform.position;
        gameObject.transform.position = new Vector3(position.x, position.y, position.z);

    }

    //Update is called once per frame
    void Update() {
        
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        
        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, z * moveSpeed);
        
        if (Input.GetKeyDown(KeyCode.Space) && canjump) {
            Jump(jumpHeight);
        }
    }

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Untagged"))
        {
            canjump = true;
        }
    }


    void Jump(float jumpHeight) {
        canjump = false;
        rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
    }
}
