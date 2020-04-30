﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int blocksCounter;

    public void incrementBlocksCounter()
    {
        blocksCounter++;
    }
    public void decrementBlocksCounter()
    {
        blocksCounter--;

        checkWinConditions();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
