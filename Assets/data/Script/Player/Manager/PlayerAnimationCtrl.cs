using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class PlayerAnimationCtrl : HuyMonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;

    [SerializeField] private Animator playerAnimation;
    public Animator PlayerAnimation => playerAnimation;

    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMoveAnimation();
        this.LoadPlayerManager();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.UpdateAnimation();
    }

    protected virtual void LoadMoveAnimation()
    {
        if (this.playerAnimation != null) return;
        this.playerAnimation = GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadMoveAnimation", transform.gameObject);
    }

    protected virtual void LoadPlayerManager()
    {
        if (this.playerManager != null) return;
        this.playerManager = GetComponent<PlayerManager>();
        Debug.Log(transform.name + ": LoadPlayerManager", transform.gameObject);
    }

    protected virtual void UpdateAnimation()
    {
        MovementState state = MovementState.idle;
        float xInputSpeed = this.playerManager.PlayerInputManager.horizontalSpeed;
        float yInputSpeed = this.playerManager.PlayerInputManager.jumpHeight;
        float xVelocity = this.playerManager.Rb.velocity.x;
        float yVelocity = this.playerManager.Rb.velocity.y;

        if (xInputSpeed == 0 && yInputSpeed == 0)
        {
            state = MovementState.idle;
        }

        if (xInputSpeed != 0f)
        {
            state = MovementState.running;
            if (xInputSpeed > 0f)
            {
                this.playerManager.Sprite.flipX = false;
            }

            if (xInputSpeed < 0f)
            {
                this.playerManager.Sprite.flipX = true;
            }
        }

        if (yVelocity > 0.1f)
        {
            state = MovementState.jumping;
        }
        
        if (yVelocity < -0.1f)
        {
            state = MovementState.falling;
        }

        this.playerAnimation.SetInteger("Status", (int)state);
    }

    public void PlayerDying()
    {
        StartCoroutine(PlayerDeactive());
    }

    protected IEnumerator PlayerDeactive()
    {
        //disable the player
        this.playerManager.Rb.bodyType = RigidbodyType2D.Static;

        this.playerAnimation.SetTrigger("Dead");

        //wait until the end of animation
        yield return new WaitForSeconds(this.playerAnimation.GetCurrentAnimatorStateInfo(0).length);
    }
}
