using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbagePickup : MonoBehaviour
{
    public Transform player;
    public float pickupRange = 3f;
    private bool isInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

   void Update() {
    float distanceToPlayer = Vector3.Distance(transform.position, player.position);
    if (distanceToPlayer < pickupRange) {
        isInRange = true;
    } else {
        isInRange = false;
    }
   }

   void OnMouseDown() {
    if (isInRange) {
        transform.parent = player;
        transform.localPosition = new Vector3(0f, 0.5f, 1f);
        transform.localRotation = Quaternion.identity;
        GetComponent<Rigidbody>().isKinematic = true;
    }
   }

   void OnMouseUp() {
    transform.parent = null;
    GetComponent<Rigidbody>().isKinematic = false;
   }
}
