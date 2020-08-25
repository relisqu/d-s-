using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public float timeBeforeSpawning = .5f;
    public float timeBetweenEnemies = .55f;
    public float timeBeforeWaves = 2.0f;
    public float baseHp;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        Debug.Log("hp " + baseHp);
    }

    // Update is called once per frame
    void Update()
    { 
    }
    IEnumerator SpawnEnemies()
    {
        // Give the player time before we start the game
        yield return new WaitForSeconds(timeBeforeSpawning);

        // After timeBeforeSpawning has elapsed, we will enter this loop
        while (true)
        {
            float randDistance = Random.Range(-3, 3);
            float randHeight = Random.Range(8, 16);


            float posX = this.transform.position.x + randDistance;
            float posY = this.transform.position.y + randHeight;

            GameObject spawnedball = Instantiate(enemy, new Vector3(posX, posY, 0), Quaternion.identity);
            
            yield return new WaitForSeconds(timeBetweenEnemies);
            //Destroy(new_enemy);
        }
    }
    public void DamageBase(int enemyDamage) {
        baseHp -= enemyDamage;
        Debug.Log("hp " + baseHp);
        if (baseHp <= 0) {

            GameOver();
        }
        
    }

    public void GameOver() {
        SceneManager.LoadScene("GameOver");
    }
}
