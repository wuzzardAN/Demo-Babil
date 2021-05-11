using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using DG.Tweening;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Pipe : MonoBehaviour
{
    public Transform pipe;
    public GameObject knockbackParticle;

    [SerializeField] private float knockbackStrenght;

    void Update()
    {
        pipe
            .DORotate(new Vector3(90, 360, 0), 10, RotateMode.FastBeyond360);
    }

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction = collision.transform.position - transform.position;
            direction.y = 0;
            
            rb.AddForce(direction.normalized * knockbackStrenght, ForceMode.Impulse);
            Knockback();
        }
    }

    void Knockback()
    {
        GameObject knockBack = Instantiate(knockbackParticle, transform.position, Quaternion.identity);
        knockBack.GetComponent<ParticleSystem>().Play();
    }
    
}
