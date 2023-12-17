using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCtrl : HuyMonoBehaviour
{
    [SerializeField] private AudioSource winSound;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWinSound();
    }

    protected virtual void LoadWinSound()
    {
        if (this.winSound != null) return;
        this.winSound = transform.GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadWinSound", transform.gameObject);
    }

    private IEnumerator EndGame()
    {
        this.winSound.Play();

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EndGame());
        }
    }
}
