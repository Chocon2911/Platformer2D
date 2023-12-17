using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public abstract class PlayerMovement : HuyMonoBehaviour
{
    [SerializeField] protected PlayerManager playerManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerManager();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected virtual void LoadPlayerManager()
    {
        if (this.playerManager != null) return;
        this.playerManager = transform.GetComponentInParent<PlayerManager>();
        Debug.Log(transform.name + ": LoadPlayerManager", transform.gameObject);
    }
}
