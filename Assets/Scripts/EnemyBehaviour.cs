using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float hp;
    int lvl;
    float currentHp;
    public float rotationSpeed;
    Transform smallerEnemy;
    int attackDamage=1;
   
    // Start is called before the first frame update
    void Start()
    {
        hp = PlayerPrefs.GetFloat("enemy_hp");
        currentHp = hp;
        Debug.Log("first_hp " + currentHp);
    }

    // Update is called once per frame`
    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * Random.Range(5,15));
        if (transform.position.y < -5 && this.gameObject != null) {
           this.hitBase();
        }
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (this.gameObject != null)
        {
            if (collision.gameObject.tag == "Bullet" && collision.gameObject.GetComponent<Bullet>().interactable)
                {
                Debug.Log("Hp " + currentHp);
                Destroy(collision.gameObject);
                collision.gameObject.GetComponent<Bullet>().interactable = false;
                GetHitted(collision.gameObject.GetComponent<Bullet>().attackDamage);
                }
        }


        //GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent("GameController") as GameController;
        //controller.KilledEnemy();
        //
    }
    void hitBase()
    {
        if (this.gameObject != null)
        {
            GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent("GameController") as GameController;
            controller.DamageBase(attackDamage);
            Destroy(gameObject);
        }

    }
    void GetHitted(float attackDamage) {
        Debug.Log("Hit " + Time.deltaTime);
        currentHp -= attackDamage;
        if (currentHp <= 0) {
          Die();
        }

    }
    void Die()
    {
        
        Debug.Log("Death " + Time.deltaTime);
        Destroy(gameObject);
    }
}
