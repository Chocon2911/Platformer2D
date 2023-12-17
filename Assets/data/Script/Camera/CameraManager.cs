using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : HuyMonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    public CameraFollow CameraFollow => cameraFollow;

    [SerializeField] private Transform cameraTrans;
    public Transform CameraTrans => cameraTrans;

    [SerializeField] private Transform targetTrans;
    public Transform TargetTrans => targetTrans;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCameraFollow();
        this.LoadCameraPos();
    }

    protected virtual void LoadCameraFollow()
    {
        if (this.cameraFollow != null) return;
        this.cameraFollow = transform.Find("FollowObj").GetComponentInChildren<CameraFollow>();
        Debug.Log(transform.name + ": LoadCameraFollow", transform.gameObject);
    }

    protected virtual void LoadCameraPos()
    {
        if (this.cameraTrans != null) return;
        this.cameraTrans = transform.GetComponent<Transform>();
        Debug.Log(transform.name + ": LoadCameraPos", transform.gameObject);
    }
}
