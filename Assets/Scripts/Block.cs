using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip collisionSound;

    [SerializeField] private int blockScoreValue = 50;
    [SerializeField] private GameObject blockSparkesVFX;

    private Level level;
    private GameSession gameSession;

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        AudioSource.PlayClipAtPoint(collisionSound, Camera.main.transform.position);

        if (CompareTag("Breakable"))
        {
            level.decrementBlocksCounter();
            gameSession.addToScore(blockScoreValue);
            Destroy(gameObject);
            triggerSparkesVFX();
        }
    }

    private void triggerSparkesVFX()
    {
        var sparkelVfx = Instantiate(blockSparkesVFX, transform.position, transform.rotation);
        Destroy(sparkelVfx, 1f);
    }

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>();

        if (CompareTag("Breakable"))
        {
            level.incrementBlocksCounter();
        }
    }
}