using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStuff : MonoBehaviour
{
    // Start is called before the first frame update

    public float fireRate = 0;
    public float damage = 10;

    public GameObject lazer;

    float timeToFire = 0;
    public Transform firePoint;
    void Awake() {
    
    }

// Update is called once per frame
void Update()
{
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)  {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
}

    void Shoot() {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        GameObject lazerInstance = Instantiate(lazer, firePoint.position, firePoint.rotation);
    }
}
