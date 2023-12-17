using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UI.Image;

public class PlayerCtrl : HuyMonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private CapsuleCollider2D groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool onMovingObj;
    [SerializeField] private bool isGround;
    public bool IsGround => isGround;

    [SerializeField] private AudioSource deadSound;

    [SerializeField] private PlatformManager platformManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerManager();
        this.LoadGroundCheck();
        this.LoadDeadSound();
    }

    protected override void Update()
    {
        base.Update();
        this.CheckIsGround();
        this.MoveWithPlatform();
    }

    protected virtual void LoadPlayerManager()
    {
        if (this.playerManager != null) return;
        this.playerManager = GetComponent<PlayerManager>();
        Debug.Log(transform.name + ": LoadPlayerManager", transform.gameObject);
    }

    protected virtual void LoadGroundCheck()
    {
        if (this.groundCheck != null) return;
        this.groundCheck =
            transform.Find("Checker").Find("GroundCheck").GetComponent<CapsuleCollider2D>();
        this.groundLayer = LayerMask.GetMask("Ground");
        Debug.Log(transform.name + ": LoadGroundCheck", transform.gameObject);
    }

    protected virtual void LoadDeadSound()
    {
        if (this.deadSound != null) return;
        this.deadSound = transform.GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadDeadSound", transform.gameObject);
    }

    protected virtual void RestartLevel()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        this.playerManager.PlayerStatSO.isDead = false;
        Console.Clear();
        Debug.Log(transform.name + ": RestartLevel", transform.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    protected void CheckIsGround()
    {
        Vector2 size = this.groundCheck.size;
        Vector2 position = this.groundCheck.transform.position;
        CapsuleDirection2D direction = CapsuleDirection2D.Horizontal;
        float angle = 0f;

        this.isGround = Physics2D.OverlapCapsule(
            position,
            size,
            direction,
            angle,
            this.groundLayer
        );
    }

    protected virtual void MoveWithPlatform()
    {
        if (this.onMovingObj)
        {
            this.playerManager.Rb.velocity += this.platformManager.Rb.velocity;
            Debug.Log("moving");
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !this.playerManager.PlayerStatSO.isDead)
        {
            this.playerManager.PlayerStatSO.isDead = true;
            this.deadSound.Play();
            this.playerManager.AnimationCtrl.PlayerDying();
            this.RestartLevel();
        }

        if (collision.gameObject.CompareTag("MovingObj"))
        {
            this.platformManager = collision.transform.GetComponent<PlatformManager>();
            if (this.platformManager == null)
            {
                Debug.Log("No platformManager");
            }
            else
            {
                this.onMovingObj = true;
            }
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingObj"))
        {
            this.onMovingObj = false;
            this.platformManager = null;
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !this.playerManager.PlayerStatSO.isDead)
        {
            this.playerManager.PlayerStatSO.isDead = true;
            this.deadSound.Play();
            this.playerManager.AnimationCtrl.PlayerDying();
            this.RestartLevel();
        }
    }
}
