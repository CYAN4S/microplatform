using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlatformPlayerController2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    PlatformPlayerController2D player;

    public Joystick joystick;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlatformPlayerController2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !GameManager.Instance.isTouchEnabled)
        {
            player.Jump();
        }
    }

    private void FixedUpdate()
    {
        player.Move(!GameManager.Instance.isTouchEnabled ? Input.GetAxisRaw("Horizontal") : joystick.Horizontal);
    }

    public void OnJumpButtonClick()
    {
        player.Jump();
    }

}
