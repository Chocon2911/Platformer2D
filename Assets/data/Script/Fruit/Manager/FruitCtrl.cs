using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCtrl : HuyMonoBehaviour
{
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private FruitManager fruitManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFruitManager();
        this.LoadCollectSound();
    }

    protected virtual void LoadFruitManager()
    {
        if (this.fruitManager != null) return;
        this.fruitManager = transform.GetComponent<FruitManager>();
        Debug.Log(transform.name + ": LoadFruitManager", transform.gameObject);
    }

    protected virtual void LoadCollectSound()
    {
        if (this.collectSound != null) return;
        this.collectSound = transform.GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadCollectSound", transform.gameObject);
    }

    //give point and disable collider
    protected virtual void AddPoint()
    {
        int additionalPoint = this.fruitManager.FruitSO.score;
        this.fruitManager.ScoreManager.score += additionalPoint;
        this.fruitManager.BoxCollide.enabled = false;
        this.fruitManager.ScoreManager.UpdateScore();
        Debug.Log("Get " + additionalPoint + " point");
    }

    protected virtual void PlayCollectSound()
    {
        this.collectSound.Play();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.AddPoint();
            this.PlayCollectSound();
            StartCoroutine(this.fruitManager.AnimCtrl.FruitDeactive());
        }
    }
}
