using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int blocksCounter;

    private SceneLoader sceneLoader;

    public void incrementBlocksCounter()
    {
        blocksCounter++;
    }
    public void decrementBlocksCounter()
    {
        blocksCounter--;

        checkWinConditions();
    }

    private void checkWinConditions()
    {
        if (blocksCounter <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
