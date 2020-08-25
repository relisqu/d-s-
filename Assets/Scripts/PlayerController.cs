using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoBehaviour
{
    private Transform player;
    public float speed;
    public float maxBound, minBound;
    Camera cam; public Transform firePoint;
    public GameObject bulletPrefab;
    public bool isAbleToshoot = true;
    public float cooldownTime;
    // Start is called before the first frame update
    void Start()
    {
        cooldownTime = PlayerPrefs.GetFloat("reload");
        if (cam == null)
            cam = Camera.main;
        player = GetComponent<Transform>();    
    }

    // Update is called once per frame
    void Update()
    {   
         
        if (Input.touchCount > 0 && isAbleToshoot)
        {
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);

            float angle = 90 + AngleBetweenTwoPoints(transform.position, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            StartCoroutine(Fire());
        }
        
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
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
