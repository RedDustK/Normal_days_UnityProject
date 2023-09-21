using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    [SerializeField] private int damage;
    private Rigidbody bulletRigidbody;
    [SerializeField]float speed = 100f;
    private float Lifetime=4f;
    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
       
       
        bulletRigidbody.velocity = transform.forward * speed;
        Destroy(gameObject,Lifetime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletTarget>() != null)
        {
           // Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        }
        else { 
            // Instantiate(vfxHitRed, transform.position, Quaternion.identity);

        }
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
       
    }
}
