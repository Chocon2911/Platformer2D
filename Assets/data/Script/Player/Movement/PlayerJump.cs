using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerJump : PlayerMovement
{

    [SerializeField] private AudioSource jumpSound;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJumpSound();
    }

    protected override void Update()
    {
        base.FixedUpdate();
        this.Jump();
    }

    protected virtual void LoadJumpSound()
    {
        if (this.jumpSound != null) return;
        this.jumpSound = transform.GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadJumpSound", transform.gameObject);
    }

    protected virtual void DoJump()
    {
        float xSpeed = this.playerManager.Rb.velocity.x;
        float ySpeed = this.playerManager.PlayerInputManager.jumpHeight
            * this.playerManager.PlayerStatSO.jumpHeightBuff;
        this.playerManager.Rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    protected virtual void PlayJumpSound()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)) 
        {
            this.jumpSound.Play();
        }
    }

    protected virtual void Jump()
    {
        if (!this.playerManager.PlayerCtrl.IsGround) return;
        this.PlayJumpSound();
        this.DoJump();
    }
}
