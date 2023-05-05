using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    Vector3  difference;
    Rigidbody rb;
    public float moveSpeed = 5f;
     bool canShoot = true;
    public Transform bulletSpawnPoint;
    public float fireRate = 10;
    public GameObject bulletPrefab ;
    public float shootingRange = 20f;
    private float timeSinceLastFire = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        difference = player.position - this.transform.position;

        float dist = difference.magnitude;


        if((dist < 200) && (dist > 20))
        {
            Debug.Log("move and shoot");

            rb.velocity = difference.normalized * moveSpeed;
            canShoot = true;
        }
        
        if (difference.sqrMagnitude <= shootingRange)   
        {
            transform.LookAt(player);
            timeSinceLastFire += Time.deltaTime;
            if(timeSinceLastFire>= 1/ fireRate)
            {
                Shoot();
                timeSinceLastFire = 0;
            }
        }
  
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab,bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = (player.position - bulletSpawnPoint.position).normalized * 10f;

    }
}
 //2 variable
    //1 for player location, get from transform component
    //1 for my (enemy) location
    //subtract them to find distance between them
    //if Vector3.magnitude
    // if ((player.transform.position- this.transform.position).magnitude < 15)
    //set a boolean

    //in Update, check if boolean is true, start shooting