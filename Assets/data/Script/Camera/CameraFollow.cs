using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : HuyMonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCameraManager();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
        this.FollowTarget();
    }

    protected virtual void LoadCameraManager()
    {
        if (this.cameraManager != null) return;
        this.cameraManager = transform.GetComponentInParent<CameraManager>();
        Debug.Log(transform.name + ": LoadCameraManager", transform.gameObject);
    }

    protected virtual void FollowTarget()
    {
        Vector3 distance = new Vector3(3f, 0, -10f);
        Vector3 targetPos = this.cameraManager.TargetTrans.position
            - new Vector3(0, this.cameraManager.TargetTrans.position.y, 0)
            + new Vector3(0, this.cameraManager.transform.position.y, 0);

        this.cameraManager.CameraTrans.position = targetPos + distance;
    }
}
