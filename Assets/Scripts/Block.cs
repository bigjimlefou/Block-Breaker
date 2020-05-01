using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip collisionSound;

    [SerializeField]
    private int blockScoreValue = 50;
    
    private Level level;
    private GameStatus gameStatus;
    
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        AudioSource.PlayClipAtPoint(collisionSound, Camera.main.transform.position);
        level.decrementBlocksCounter();
        gameStatus.addToScore(blockScoreValue);
        
        Destroy(gameObject);
    }

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        
        level.incrementBlocksCounter();
    }
}
