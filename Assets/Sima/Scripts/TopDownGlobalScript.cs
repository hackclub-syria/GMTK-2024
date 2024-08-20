using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;
using BayatGames.SaveGameFree;
using UnityEngine.SocialPlatforms.Impl;

public class TopDownGlobalScript : MonoBehaviour
{
    private StatScreenScript stats;
    [Header("Properties")]
    public float ballRadius;
    public float maxHoleRadius;
    public float visionXMargin;
    public float visionYMargin;
    public Transform[] corners;
    [Space]
    [Space]
    [Header("Debug Values")]
    [Header("* Ball")]
    public float ballMoveSpeed;
    public bool ballExists;
    public float ballSpeedIncreaseRate;
    public int ballCountInThisRound;
    [Header("* Round")]
    public int[] scoreCountInThisRound = { 0, 0, 0 }; // first index is not actually used
    private int prevDifficulty;
    public int difficulty;
    public int roundsWon;
    public Text roundNumberText;
    [Header("* Other")]
    public float holeRadius;
    public float susAmountToAdd;
    public float sus;
    public float timeBetweenSusUpdate;
    public float susIncreaseFactor;
    public float timerSus;
    public float naturalSusDecrease;
    public GameObject commentaryCanvas;
    // Start is called before the first frame update
    void Awake()
    {
        ballExists = false;
        holeRadius = 0.5f;
        difficulty = prevDifficulty = 1;
        stats = GameObject.FindGameObjectWithTag("UI Manager").GetComponent<StatScreenScript>();
        timerSus = timeBetweenSusUpdate;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerSus > 0) { timerSus -= Time.deltaTime; }
        else
        {
            timerSus = timeBetweenSusUpdate;
            if (susAmountToAdd > 0){
                sus += susAmountToAdd* susIncreaseFactor;
            }
            else
            {
                sus = Mathf.Clamp(sus - naturalSusDecrease, 0, 11);
            }
            UpdateSus(sus);
        }
        if (difficulty != prevDifficulty)
        {
            ballMoveSpeed += (difficulty - prevDifficulty) * ballSpeedIncreaseRate;
            prevDifficulty = difficulty;
        }
    }

    public GameObject roundCompletePanel;
    public void NewRound()
    {
        roundNumberText.text = (int.Parse(roundNumberText.text)+1).ToString();
        stats.ClearScoreBoard();
        ballCountInThisRound = 0;
        for (int i = 1; i <= 2; i++)
            for (int j = 0; j < 5; j++)
                stats.scoresInThisRound[i, j] = -1;
        scoreCountInThisRound[1] = scoreCountInThisRound[2] = 0;
        IncreaseDifficulty(1);
        StartCoroutine(RoundCompleteCor());
    }
    private IEnumerator RoundCompleteCor()
    {
        Time.timeScale = 0f;
        roundCompletePanel.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        roundCompletePanel.SetActive(false);
    }
    public void IncreaseDifficulty(int increase)
    {
        difficulty = math.max(math.min(difficulty + increase, 10), 0);
    }
    public GameObject gameOverPanel;
    public TextMeshProUGUI yourScoreIsText;
    public void UpdateScores(int team, bool scored)
    {
        if (scored)
        {
            scoreCountInThisRound[team]++;
        }
        if (scoreCountInThisRound[1] == 5)
        {
            gameOverPanel.SetActive(true);
            // round has been won by dad :)
            NewRound();

        }
        else if (scoreCountInThisRound[2] == 5)
        {
            GameOver();
        }
        stats.UpdateScoreUI(team, scored);
    }

    public void UpdateSus(float level)
    {
        stats.UpdateSusUI(level);
    }
    public void GameOver()
    {
        // GAME OVER
        Cursor.visible = true;
        Destroy(roundCompletePanel);
        gameOverPanel.SetActive(true);
        commentaryCanvas.SetActive(false);
        yourScoreIsText.text = "Your score is: " + (int.Parse(roundNumberText.text).ToString());
        if (SaveGame.Exists("high score"))
        {
            if (int.Parse(roundNumberText.text) > SaveGame.Load<int>("high score"))
            {
                SaveGame.Save<int>("high score", int.Parse(roundNumberText.text));
                Leaderboards.Leaderboard.UploadNewEntry(SaveGame.Load<string>("username"), SaveGame.Load<int>("high score"));
            }
        }
        else
        {
            SaveGame.Save<int>("high score", int.Parse(roundNumberText.text));
            Leaderboards.Leaderboard.UploadNewEntry(SaveGame.Load<string>("username"), SaveGame.Load<int>("high score"));
        }
        // round has been won by opponent ;-;
        // stop spawning balls to prepare to exit
        ballExists = true;
    }
}
