using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerManager : HuyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected CapsuleCollider2D bodyCollider;
    public CapsuleCollider2D BodyCollider => bodyCollider;

    [SerializeField] protected PlayerInputManager playerInputManager;
    public PlayerInputManager PlayerInputManager => playerInputManager;

    [SerializeField] protected PlayerStatSO playerStatSO;
    public PlayerStatSO PlayerStatSO => playerStatSO;

    [SerializeField] protected PlayerMove playerMove;
    public PlayerMove PlayerMove => playerMove;

    [SerializeField] protected PlayerJump playerJump;
    public PlayerJump PlayerJump => playerJump;

    [SerializeField] protected PlayerAnimationCtrl animationCtrl;
    public PlayerAnimationCtrl AnimationCtrl => animationCtrl;

    [SerializeField] protected SpriteRenderer sprite;
    public SpriteRenderer Sprite => sprite;

    [SerializeField] private PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBodyCollider();
        this.LoadRigidbody();
        this.LoadPlayerInputManager();
        this.LoadPlayerJump();
        this.LoadPlayerMove();
        this.LoadAnimationCtrl();
        this.LoadSprite();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody2D>();
        this.rb.isKinematic = false;
        this.rb.freezeRotation = true;
        Debug.Log(transform.name + ": LoadRigidbody", transform.gameObject);
    }

    protected virtual void LoadBodyCollider()
    {
        if (this.bodyCollider != null) return;
        this.bodyCollider = GetComponent<CapsuleCollider2D>();
        this.bodyCollider.isTrigger = false;
        Debug.Log(transform.name + ": LoadBodyCollider", transform.gameObject);
    }

    protected virtual void LoadPlayerInputManager()
    {
        if (this.playerInputManager != null) return;
        this.playerInputManager = GetComponent<PlayerInputManager>();
        Debug.Log(transform.name + ": LoadPlayerInputManager", transform.gameObject);
    }

    protected virtual void LoadPlayerJump()
    {
        if(this.playerJump != null) return;
        this.playerJump = transform.transform.GetComponentInChildren<PlayerJump>();
        Debug.Log(transform.name + ": LoadPlayerJump", transform.gameObject);
    }

    protected virtual void LoadPlayerMove()
    {
        if (this.playerMove != null) return;
        this.playerMove = transform.transform.GetComponentInChildren<PlayerMove>();
        Debug.Log(transform.name + ": LoadPlayerMove", transform.gameObject);
    }

    protected virtual void LoadAnimationCtrl()
    {
        if (this.animationCtrl != null) return;
        this.animationCtrl = GetComponent<PlayerAnimationCtrl>();
        Debug.Log(transform.name + ": LoadAnimationCtrl", transform.gameObject);
    }

    protected virtual void LoadSprite()
    {
        if (this.sprite != null) return;
        this.sprite = GetComponent<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadSprite", transform.gameObject);
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", transform.gameObject);
    }
}
