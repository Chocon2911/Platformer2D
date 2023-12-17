using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWaypointFollower : HuyMonoBehaviour
{
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private float speed = 2f;
    [SerializeField] private int currWaypointIndex;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlatformManager();
    }

    protected override void FixedUpdate()
    {
        base.Update();
        this.CheckWaypointIndex();
        this.FollowWaypoint();
    }

    protected virtual void LoadPlatformManager()
    {
        if (this.platformManager != null) return;
        this.platformManager = transform.parent.GetComponent<PlatformManager>();
        Debug.Log(transform.name + ": LoadPlatformManager", transform.gameObject);
    }

    protected virtual void CheckWaypointIndex()
    {
        if (this.platformManager == null 
            || this.platformManager.WayPoints[this.currWaypointIndex].transform.position == null) return;
        else
        {
            Vector2 platformPos = this.platformManager.gameObject.transform.position;
            Vector2 targetPos = this.platformManager.WayPoints[this.currWaypointIndex].transform.position;
            if (Vector2.Distance(platformPos, targetPos) < 0.1f)
            {
                if (this.currWaypointIndex < this.platformManager.WayPoints.Length - 1)
                {
                    this.currWaypointIndex++;
                }
                else
                {
                    this.currWaypointIndex = 0;
                }
            }
        }
    }

    protected virtual void FollowWaypoint()
    {
        Vector2 platformPos = this.platformManager.transform.position;
        Vector2 waypointPos = this.platformManager.WayPoints[this.currWaypointIndex].transform.position;

        this.platformManager.Rb.velocity = (waypointPos - platformPos).normalized * this.speed;
    }
}
