using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    
    [Tooltip("The Paddle instance to follow for start position")]
    [SerializeField] private Paddle paddle;

    [SerializeField] private Vector2 launchVelocity = new Vector2(2f,10f);

    [SerializeField] private AudioClip[] sounds;

    private Vector2 paddleToBallVector;
    private bool ballLaunched = false;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballLaunched)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ballLaunched = true;
                LaunchBallOnMouseClick();
            }
            else
            {
                LockBallToPaddle();
            }
        }else
        {
        }
    }

    private void LaunchBallOnMouseClick()
    {
        
            GetComponent<Rigidbody2D>().velocity = launchVelocity;
    }

    void LockBallToPaddle()
    {
        var position = paddle.transform.position;
        Vector2 paddlePosition = new Vector2(position.x, position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (ballLaunched)
        {
            AudioClip audioClip = sounds[(int)Random.Range(0, sounds.Length)];
            audioSource.PlayOneShot(audioClip);
        }
    }
}
