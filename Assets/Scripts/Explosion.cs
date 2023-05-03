using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionForce = 100f;
    public float explosionRadius = 5f;
    public ParticleSystem explosionParticles;

    private void Start()
    {
        explosionParticles.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // You can adjust this tag to fit your scenario
        {
            // Activate particle system and apply explosive force
            explosionParticles.Play();
            ApplyExplosionForce();
            Debug.Log("Explosion triggered!");

            other.GetComponent<player>().TakeDamage(30);


            // Remove the mine from the scene
            Destroy(gameObject);
        }
    }

    void ApplyExplosionForce()
    {
        // Find all colliders within the explosion radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        
        // Apply explosive force to each nearby object
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1f, ForceMode.Impulse);
            }
        }
    }
}