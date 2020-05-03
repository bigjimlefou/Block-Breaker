using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int blocksCounter;

    private SceneLoader sceneLoader;

    public void IncrementBlocksCounter()
    {
        blocksCounter++;
    }
    public void DecrementBlocksCounter()
    {
        blocksCounter--;

        CheckWinConditions();
    }

    private void CheckWinConditions()
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
