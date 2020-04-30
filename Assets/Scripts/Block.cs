using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip collisionSound;
    
    private Level level;
    
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        AudioSource.PlayClipAtPoint(collisionSound, Camera.main.transform.position);
        level.decrementBlocksCounter();
        Destroy(gameObject);
    }

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.incrementBlocksCounter();
    }
}
