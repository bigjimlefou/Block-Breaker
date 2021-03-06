﻿using UnityEngine;
using static UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [Tooltip("The Paddle instance to follow for start position")] [SerializeField]
    private Paddle paddle;

    [SerializeField] private AudioClip[] sounds;

    private AudioSource _audioSource;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private Vector2 launchVelocity = new Vector2(2f, 10f);
    [SerializeField] private float ramdomFactor = 0.2f;

    private Vector2 _paddleToBallVector;
    private bool _ballLaunched = false;


    // Start is called before the first frame update
    void Start()
    {
        _paddleToBallVector = transform.position - paddle.transform.position;
        _audioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_ballLaunched)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _ballLaunched = true;
                LaunchBallOnMouseClick();
            }
            else
            {
                LockBallToPaddle();
            }
        }
        else
        {
        }
    }

    private void LaunchBallOnMouseClick()
    {
        _rigidbody2D.velocity = launchVelocity;
    }

    void LockBallToPaddle()
    {
        var position = paddle.transform.position;
        Vector2 paddlePosition = new Vector2(position.x, position.y);
        transform.position = paddlePosition + _paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 velocityTweak = new Vector2(Range(0f, ramdomFactor), Range(0f, ramdomFactor));
        if (_ballLaunched)
        {
            AudioClip audioClip = sounds[(int) Range(0, sounds.Length)];
            _audioSource.PlayOneShot(audioClip);
            _rigidbody2D.velocity += velocityTweak;
        }
    }
}