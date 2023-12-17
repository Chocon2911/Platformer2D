using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class MovingTrapManager : HuyMonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] private BoxCollider2D bodyCollide;
    public BoxCollider2D BodyCollide => bodyCollide;

    [SerializeField] private GameObject obj;

    [SerializeField] private GameObject[] wayPoints;
    public GameObject[] WayPoints => wayPoints;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
        this.LoadBodyCollide();
        this.LoadWayPoints();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigidbody", transform.gameObject);
    }

    protected virtual void LoadBodyCollide()
    {
        if (this.bodyCollide != null) return;
        this.bodyCollide = transform.GetComponent<BoxCollider2D>();
        Debug.Log(transform.name + ": LoadBodyCollide", transform.gameObject);
    }

    protected virtual void LoadWayPoints()
    {
        if (this.obj != null && this.wayPoints != null) { return; }
        else
        {
            this.obj = transform.parent.Find("Waypoints").gameObject;

            this.wayPoints = this.obj.GetComponentsInChildren<Transform>()
            .Where(t => t != this.obj.transform)
            .Select(t => t.gameObject)
            .ToArray();


            Debug.Log(transform.name + ": LoadWayPoints", transform.gameObject);
        }
    }
}
