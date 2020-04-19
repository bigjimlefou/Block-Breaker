using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    [Tooltip("The Paddle instance to follow for start position")]
    [SerializeField] private Paddle paddle;

    private Vector2 paddleToBallVector;
    
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var position = paddle.transform.position;
        Vector2 paddlePosition = new Vector2(position.x,position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }
}
