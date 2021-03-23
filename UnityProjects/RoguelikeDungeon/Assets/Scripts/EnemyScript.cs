using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public EntityObj enemyObject;
    
    public Transform shootPos;
    private float attackSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        attackSpeed = 0.01f * enemyObject.attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
