using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawCtrl : HuyMonoBehaviour
{
    [SerializeField] private SawManager sawManager;
    public SawManager SawManager => sawManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSawManager();
    }

    protected virtual void LoadSawManager()
    {
        if (this.sawManager != null) return;
        this.sawManager = transform.GetComponent<SawManager>();
        Debug.Log(transform.name + ": LoadSawManager", transform.gameObject);
    }
}
