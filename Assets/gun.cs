using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
     public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;
    public GameObject bulletPrefab ;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetMouseButton(0))
       {
           var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position,bulletSpawnPoint.rotation);
           bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
       }
    }
}
