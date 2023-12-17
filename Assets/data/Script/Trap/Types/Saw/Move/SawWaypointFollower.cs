using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawWaypointFollower : HuyMonoBehaviour
{
    [SerializeField] private SawManager sawManager;
    [SerializeField] private float speed = 10f;
    [SerializeField] private int currWaypointIndex;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSawManager();
    }

    protected override void FixedUpdate()
    {
        base.Update();
        this.CheckWaypointIndex();
        this.FollowWaypoint();
    }

    protected virtual void LoadSawManager()
    {
        if (this.sawManager != null) return;
        this.sawManager = transform.parent.GetComponent<SawManager>();
        Debug.Log(transform.name + ": LoadSawManager", transform.gameObject);
    }

    protected virtual void CheckWaypointIndex()
    {
        if (this.sawManager == null
            || this.sawManager.WayPoints[this.currWaypointIndex].transform.position == null) return;
        else
        {
            Vector2 platformPos = this.sawManager.gameObject.transform.position;
            Vector2 targetPos = this.sawManager.WayPoints[this.currWaypointIndex].transform.position;
            if (Vector2.Distance(platformPos, targetPos) < 0.4f)
            {
                if (this.currWaypointIndex < this.sawManager.WayPoints.Length - 1)
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
        Vector2 platformPos = this.sawManager.transform.position;
        Vector2 waypointPos = this.sawManager.WayPoints[this.currWaypointIndex].transform.position;

        this.sawManager.Rb.velocity = (waypointPos - platformPos).normalized * this.speed;
    }
}
