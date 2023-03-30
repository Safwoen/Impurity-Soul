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
    public float bulletSpeed = 10;
    public GameObject bulletPrefab ;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        difference = player.position - this.transform.position;
        if(difference.magnitude < 20)
        {
            rb.velocity = difference.normalized * moveSpeed;
            canShoot = true;
        }
       if(Input.GetMouseButton(0))
       {
           var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position,bulletSpawnPoint.rotation);
           bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
       }
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