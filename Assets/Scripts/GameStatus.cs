using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField][Range(0.1f,2f)] private float timeScale = 1f;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
    }
}
