using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip collisionSound;
    
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        AudioSource.PlayClipAtPoint(collisionSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
