using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlatformPlayerController2D : MonoBehaviour
{
    [Header("Required")]
    [SerializeField] Collider2D[] platformCollider2D = null;
    [SerializeField] Collider2D floorTriggerCollider2D = null;

    [Header("Game Value")]
    [SerializeField] float moveVelocity = 0;
    [SerializeField] float jumpForce = 0;
    [SerializeField] int maxJumpInAirCount = 1;

    Rigidbody2D rb;


    private bool _isMovable = true;
    public bool IsMovable
    {
        get => _isMovable;
        set
        {
            _isMovable = value;
            switch (value)
            {
                case false:
                    rb.isKinematic = true;
                    rb.velocity = Vector2.zero;
                    break;
                case true:
                    rb.isKinematic = false;
                    break;
            }
        }
    }

    public bool IsGrounded { get; private set; }
    public int JumpCount { get; private set; }

    public Action OnJump;
    public Action OnLand;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float axis)
    {
        if (!IsMovable) return;
        rb.velocity = new Vector2(moveVelocity * axis * Time.deltaTime, rb.velocity.y);
    }

    public bool Jump()
    {
        if (!IsMovable) return false;

        if (!IsGrounded)
        {
            if (maxJumpInAirCount <= JumpCount)
            {
                return false;
            }

            JumpCount++;
        }

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpForce));

        OnJump();

        return true;
    }

    private void FixedUpdate()
    {
        bool wasGrounded = IsGrounded;
        IsGrounded = false;

        foreach (var platform in platformCollider2D)
        {
            if (floorTriggerCollider2D.IsTouching(platform))
            {
                if (!wasGrounded)
                {
                    JumpCount = 0;
                    OnLand();
                }

                IsGrounded = true;
                return;
            }
        }
    }
}
