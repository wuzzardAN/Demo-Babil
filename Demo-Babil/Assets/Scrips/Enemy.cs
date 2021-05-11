using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Rigidbody _rigidbody;
    public float speed;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 pos = Vector3.Lerp(transform.position, target.transform.position, speed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(pos);
        transform.LookAt(target.transform);
    }

    public void FindTarget(string targetString)
    {
        target = GameObject.FindGameObjectWithTag(targetString);
    }
    
    

    
}
