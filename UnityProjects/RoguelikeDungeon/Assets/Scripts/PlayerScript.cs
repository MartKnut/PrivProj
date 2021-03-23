using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public EntityObj playerObject;
    private float attackSpeed;
    private float x, y;

    private bool canshoot = true;
    
    // Includes so far:
    
    // public float movespeed = 5;
    // public int health = 100;
    // public int attackDamage;
    // public float attackSpeed;
    
    // pointer
    public Camera cam;
    public Rigidbody2D pointer;
    public Transform bulletOrigin;
    private Vector2 movement;
    private Vector2 mousePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        attackSpeed = 0.01f * playerObject.attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        cam.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, -10);
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        Move();
        MouseControl();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canshoot == true) 
        {
            StartCoroutine(Shoot());
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(x, y);
        rb.velocity = rb.velocity.normalized * playerObject.movespeed;
    }

    IEnumerator Shoot()
    {
        canshoot = false;
        Debug.Log("Gunshot");
        yield return new WaitForSeconds(attackSpeed);
        canshoot = true;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(bulletOrigin.position, mousePosition);
        Gizmos.DrawSphere(mousePosition, .3f);
    }
    
    private void MouseControl()
    {
        pointer.MovePosition(bulletOrigin.position);
        
        // I need a Vector2 value to get the angle from mouse to rigidbody.
        Vector2 lookDirection = mousePosition - pointer.position;
            
        // I want the pointer to follow the player
        pointer.position = new Vector2(rb.transform.position.x, rb.transform.position.y);
        
            
        // get the angle of Y and X from the previous Vector 2. Use it to tell the pointer where to rotate towards.
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        // We want to move our player, so we have to seperately set the rotation of or player and pointer
        pointer.rotation = angle;
        rb.rotation = angle;
    }
}
