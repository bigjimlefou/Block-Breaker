﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip collisionSound;

    [SerializeField] private int blockScoreValue = 50;
    [SerializeField] private GameObject blockSparkesVFX;
    
    private Level level;
    private GameSession _gameSession;
    
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        AudioSource.PlayClipAtPoint(collisionSound, Camera.main.transform.position);
        level.decrementBlocksCounter();
        _gameSession.addToScore(blockScoreValue);
        
        Destroy(gameObject);
        triggerSparkesVFX();
    }

    private void triggerSparkesVFX()
    {
        var sparkelVFX = Instantiate(blockSparkesVFX, transform.position,transform.rotation);
        Destroy(sparkelVFX,1f);
    }

    private void Start()
    {
        level = FindObjectOfType<Level>();
        _gameSession = FindObjectOfType<GameSession>();
        
        level.incrementBlocksCounter();
    }
}
