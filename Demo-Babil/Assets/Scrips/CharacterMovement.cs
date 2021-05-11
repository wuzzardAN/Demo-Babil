using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController _characterController;
    
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;

    public float moveSpeed;
    public float turnTime;
    public float turnVelocity;
    public float smoothBlend = 0.1f;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hor, 0, ver).normalized;

        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);
            
            _characterController.Move(direction * moveSpeed * Time.deltaTime);
            _animator.SetBool("isMoving",true);
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }
    }

    
}
