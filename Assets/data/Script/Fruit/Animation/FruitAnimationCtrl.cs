using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitAnimationCtrl : HuyMonoBehaviour
{
    [SerializeField] private FruitManager fruitManager;

    [SerializeField] private Animator animator;
    public Animator Animator => animator;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFruitManager();
        this.LoadAnimator();
    }

    protected virtual void LoadFruitManager()
    {
        if (this.fruitManager != null) return;
        this.fruitManager = GetComponent<FruitManager>();
        Debug.Log(transform.name + ": LoadFruitManager", transform.gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", transform.gameObject);
    }

    //Make the fruit run disapear then deactive it
    public IEnumerator FruitDeactive()
    {
        animator.SetTrigger("isCollected");

        //wait until end of animation
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        //enable the collider
        this.fruitManager.BoxCollide.enabled = true;

        //disable the fruit
        this.fruitManager.gameObject.SetActive(false);
    }
}
