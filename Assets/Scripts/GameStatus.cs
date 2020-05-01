using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField][Range(0.1f,2f)] private float timeScale = 1f;

    [SerializeField] private int score;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
    }
    
    public void addToScore(int toAdd)
    {
        score += toAdd;
    }
}
