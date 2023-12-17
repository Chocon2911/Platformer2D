using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GoalManager : HuyMonoBehaviour
{
    [SerializeField] private BoxCollider2D bodyCollide;
    public BoxCollider2D BodyCollide => bodyCollide;

    [SerializeField] private GoalCtrl goalCtrl;
    public GoalCtrl GoalCtrl => goalCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBodyCollide();
        this.LoadGoalCtrl();
    }

    protected virtual void LoadBodyCollide()
    {
        if (this.bodyCollide != null) return;
        this.bodyCollide = transform.GetComponent<BoxCollider2D>();
        this.bodyCollide.isTrigger = true;
        Debug.Log(transform.name + ": LoadBodyCollide", transform.gameObject);
    }

    protected virtual void LoadGoalCtrl()
    {
        if (this.goalCtrl != null) return;
        this.goalCtrl = transform.GetComponent<GoalCtrl>();
        Debug.Log(transform.name + ": LoadGoalCtrl", transform.gameObject);
    }
}
