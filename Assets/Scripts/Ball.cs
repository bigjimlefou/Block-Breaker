using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    
    [Tooltip("The Paddle instance to follow for start position")]
    [SerializeField] private Paddle paddle;

    [SerializeField] private Vector2 launchVelocity = new Vector2(2f,10f);

    private Vector2 paddleToBallVector;
    private bool ballLaunched = false;
    
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
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
}
