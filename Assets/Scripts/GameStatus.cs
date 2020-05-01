using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField][Range(0.1f,2f)] private float timeScale = 1f;
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        var gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
    }
    
    public void addToScore(int toAdd)
    {
        score += toAdd;
        scoreText.text = score.ToString();
    }
}
