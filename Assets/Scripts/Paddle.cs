using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnit  = 8f;
    [SerializeField] private float minScreenXPositionInUnit = 1f;
    [SerializeField] private float maxScreenXPositionInUnit = 7f;
    private GameSession _gameSession;
    private Ball _ball;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame

    void Update()
    {
        var position = transform.position;
        Vector3 paddlePosition = new Vector3(position.x,position.y,position.z);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minScreenXPositionInUnit, maxScreenXPositionInUnit);
        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if (_gameSession.AutoPlay)
        {
            return _ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnit;
        }
    }
}
