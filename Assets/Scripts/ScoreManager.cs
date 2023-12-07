using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public static ScoreManager Instance;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI finalScoreText;
    public Animator anim;

    void Start()
    {
        score = 0;
    }

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
    }

    public void GameOver ()
    {
        StartCoroutine(IncreaseFinalScore());
        anim.SetTrigger("gameover");
    }

    IEnumerator IncreaseFinalScore()
    {
        yield return new WaitForSeconds(1f);

        int targetScore = score;
        int displayedScore = 0;

        while (displayedScore < targetScore)
        {
            displayedScore += 10;
            finalScoreText.text = displayedScore.ToString();
            yield return null;
        }

        finalScoreText.text = targetScore.ToString();
    }

    public void ResetScore()
    {
        StartCoroutine(ResetGame());
    }

    IEnumerator ResetGame()
    {
        anim.SetTrigger("restartGame");

        score = 0;

        yield return new WaitForSeconds(1f);

        
    }
}
