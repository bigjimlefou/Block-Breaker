using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnit  = 8f;
    [SerializeField] private float minScreenXPositionInUnit = 1f;
    [SerializeField] private float maxScreenXPositionInUnit = 7f;

    // Update is called once per frame
    void Update()
    {
        var mousePositionXInUnit = Input.mousePosition.x / Screen.width * screenWidthInUnit;
        var position = transform.position;
        Vector3 paddlePosition = new Vector3(position.y,position.y,position.z);
        paddlePosition.x = Mathf.Clamp(mousePositionXInUnit, minScreenXPositionInUnit, maxScreenXPositionInUnit);
        transform.position = paddlePosition;
    }
}
