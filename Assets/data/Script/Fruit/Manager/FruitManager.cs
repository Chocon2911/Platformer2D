using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FruitManager : HuyMonoBehaviour
{
    [SerializeField] private BoxCollider2D bodyCollide;
    public BoxCollider2D BoxCollide => bodyCollide;

    [SerializeField] private FruitSO fruitSO;
    public FruitSO FruitSO => fruitSO;
    [SerializeField] private ScoreManager scoreManager;
    public ScoreManager ScoreManager => scoreManager;

    [SerializeField] private FruitAnimationCtrl animCtrl;
    public FruitAnimationCtrl AnimCtrl => animCtrl;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBodyCollide();
        this.LoadScoreManager();
        this.LoadAnimCtrl();
    }

    protected virtual void LoadBodyCollide()
    {
        if (this.bodyCollide != null) return;
        this.bodyCollide = transform.GetComponent<BoxCollider2D>();
        Debug.Log(transform.name + ": LoadBodyCollide", transform.gameObject);
    }

    protected virtual void LoadScoreManager()
    {
        if(this.scoreManager != null) return;
        this.scoreManager = 
            GameObject.Find("Score").transform.GetComponent<ScoreManager>();
        Debug.Log(transform.name + ": LoadScoreManager", transform.gameObject);
    }

    protected virtual void LoadAnimCtrl()
    {
        if(this.animCtrl != null) return;
        this.animCtrl = transform.GetComponent<FruitAnimationCtrl>();
        Debug.Log(transform.name + ": LoadAnimCtrl", transform.gameObject);
    }
}
