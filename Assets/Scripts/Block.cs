using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip collisionSound;
    [SerializeField] private GameObject blockSparkesVfx;
    [SerializeField] private Sprite[] blockBrokenSprites;

    private Level _level;
    private GameSession _gameSession;

    [SerializeField] private int hitsToBreak = 1;
    [SerializeField] private int blockScoreValue = 50;
    
    [SerializeField] private int hits = 0;
    

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        AudioSource.PlayClipAtPoint(collisionSound, Camera.main.transform.position);
        
        hits++;

        if (CompareTag("Breakable"))
        {
            if (hits >= hitsToBreak)
            {
                _level.DecrementBlocksCounter();
                _gameSession.AddToScore(blockScoreValue);
                TriggerSparkesVfx();
                Destroy(gameObject);
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        if (hits <= blockBrokenSprites.Length)
        {
            var spriteIndex = hits - 1;
            if (blockBrokenSprites[spriteIndex] != null)
            {
                GetComponent<SpriteRenderer>().sprite = blockBrokenSprites[spriteIndex];
            }
            else
            {
                Debug.Log("ShowNextHitSprite : Missing broken sprite index "+spriteIndex);
            }
        }
    }

    private void TriggerSparkesVfx()
    {
        var transform1 = transform;
        var sparkelVfx = Instantiate(blockSparkesVfx, transform1.position, transform1.rotation);
        Destroy(sparkelVfx, 1f);
    }

    private void Start()
    {
        _level = FindObjectOfType<Level>();
        _gameSession = FindObjectOfType<GameSession>();

        if (CompareTag("Breakable"))
        {
            _level.IncrementBlocksCounter();
        }
    }
}