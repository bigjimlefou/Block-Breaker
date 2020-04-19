using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //This field gets serialized even though it is private
    //because it has the SerializeField attribute applied.
    [SerializeField] private float screenWidthInUnit  = 16f; 

    // Update is called once per frame
    void Update()
    {
        var mousePositionXInUnit = Input.mousePosition.x / Screen.width * screenWidthInUnit;
        Debug.Log(mousePositionXInUnit);
        Vector2 paddlePosition = new Vector2(mousePositionXInUnit,transform.position.y);
        transform.position = paddlePosition;
    }
}
