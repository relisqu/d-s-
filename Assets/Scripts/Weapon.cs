using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool isAbleToshoot = true;
    public float cooldownTime;
    // Update is called once per frame
    void Start() {
        cooldownTime = PlayerPrefs.GetFloat("reload");
    }
    void Update()
    {
        if (Input.touchCount > 0 && isAbleToshoot)
        {
             StartCoroutine(Fire());
        }
        
    }
    
    public IEnumerator Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        isAbleToshoot = false;
        //wait for some time
        yield return new WaitForSeconds(cooldownTime);
        isAbleToshoot = true;
    }

}
