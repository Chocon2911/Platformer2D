using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlatformManager : MovingTrapManager
{
    [SerializeField] private PlatformCtrl platformCtrl;
    public PlatformCtrl PlatformCtrl => platformCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlatformCtrl();
    }

    protected virtual void LoadPlatformCtrl()
    {
        if (this.platformCtrl != null) return;
        this.platformCtrl = transform.GetComponent<PlatformCtrl>();
        Debug.Log(transform.name + ": LoadPlatformCtrl", transform.gameObject);
    }
}
