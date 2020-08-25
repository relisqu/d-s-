using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;
    private Transform bullet;
    public float attackDamage;
    public bool interactable = true;
    void Start()
    {
            attackDamage = PlayerPrefs.GetFloat("tower_damage");
           bullet = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
        if (Math.Abs(bullet.position.y) >= 8 || Math.Abs(bullet.position.x) > 4)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Base") {
            Destroy(gameObject);
        }
    } 
}
