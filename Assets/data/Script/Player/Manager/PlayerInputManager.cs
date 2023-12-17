using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : HuyMonoBehaviour
{
    public float horizontalSpeed;
    public float jumpHeight;

    protected override void FixedUpdate()
    {
        InputMovement();
    }

    protected virtual void InputMovement()
    {
        horizontalSpeed = Input.GetAxis("Horizontal");
        jumpHeight = Input.GetAxis("Jump");
    }
}
