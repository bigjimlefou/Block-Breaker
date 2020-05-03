using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField][Range(0.1f,2f)] private float timeScale = 1f;
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        var gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            // 71. Singleton Pattern Bug Fix
            GameObject o;
            (o = gameObject).SetActive(false);
            
            Destroy(o);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
    }
    
    public void AddToScore(int toAdd)
    {
        score += toAdd;
        scoreText.text = score.ToString();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
