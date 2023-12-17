using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCtrl : HuyMonoBehaviour
{
    [SerializeField] private GameObject player;
    public GameObject Player => player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.player = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.player = null;
        }
    }
}
