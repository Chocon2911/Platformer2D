using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class ScoreManager : HuyMonoBehaviour
{
    public int score = 0;

    [SerializeField] private TextMeshProUGUI scoreText;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadScoreText();
    }

    protected virtual void LoadScoreText()
    {
        if (this.scoreText != null) return;
        this.scoreText = 
            GameObject.Find("Canvas").transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadText", transform.gameObject);
    }

    public void UpdateScore()
    {
        this.scoreText.text = "Score: " + score;
    }
}
