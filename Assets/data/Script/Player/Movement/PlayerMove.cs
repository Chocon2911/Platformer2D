using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerMove : PlayerMovement
{
    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    protected override void Update()
    {
        base.FixedUpdate();
        this.Move();
    }

    protected virtual void Move()
    {
        if (this.playerManager.Rb.bodyType == RigidbodyType2D.Static) return;
        float xSpeed = this.playerManager.PlayerInputManager.horizontalSpeed
            * this.playerManager.PlayerStatSO.speedBuff;
        float ySpeed = this.playerManager.Rb.velocity.y;
            this.playerManager.Rb.velocity = new Vector2(xSpeed, ySpeed); 
    }
}
