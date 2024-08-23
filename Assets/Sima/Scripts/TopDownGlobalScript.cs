using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;
using BayatGames.SaveGameFree;

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
    public Commentator_logic_script commentary;
    public GameObject newHighScoreBox;
    // Start is called before the first frame update
    void Awake()
    {
        ballExists = false;
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
    public string LoadUsername()
    {
        if (PlayerPrefs.HasKey("uName"))
        {
            string username = PlayerPrefs.GetString("uName");
            Debug.Log("Username retrieved: " + username);
            return username;
        }
        else
        {
            Debug.Log("No username found!");
            return null;
        }
    }
    public void NewRound()
    {
        roundNumberText.text = (int.Parse(roundNumberText.text)+1).ToString();
        // if its a high score, display v_surprised
        if (int.Parse(roundNumberText.text) > SaveGame.Load<int>("high score")) {
            commentary.V_surprise();
            newHighScoreBox.SetActive(true);
            Invoke("HideNewHigh", 1.5f);
            if (SaveGame.Exists("high score"))
            {
                if (int.Parse(roundNumberText.text) > SaveGame.Load<int>("high score"))
                {
                    SaveGame.Save<int>("high score", int.Parse(roundNumberText.text));
                    Leaderboards.Leaderboard.UploadNewEntry(LoadUsername(), SaveGame.Load<int>("high score"));
                }
            }
            else
            {
                SaveGame.Save<int>("high score", int.Parse(roundNumberText.text));
                Leaderboards.Leaderboard.UploadNewEntry(LoadUsername(), SaveGame.Load<int>("high score"));
            }
        }
        scoreCountInThisRound[1] = 0;
        scoreCountInThisRound[2] = 0;
        stats.ClearScoreBoard();
        ballCountInThisRound = 0;
        stats.scoreInThisRound = 0;
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
        stats.ClearScoreBoard();
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
        else
        {
            if (team == 1)
            {
                scoreCountInThisRound[2]++;
            }
            else if (team == 2)
            {
                scoreCountInThisRound[1]++;
            }
        }
        stats.UpdateScoreUI(team, scored);
        if (Mathf.Abs(stats.scoreInThisRound) == 5) // someone won
        {
            if (stats.scoreInThisRound == 5)
            {
                // round has been won by dad :)
                commentary.Surprise();
                NewRound();
            }
            else
            {
                GameOver("round");
            }
            stats.scoreInThisRound = 0;
        }

    }

    public void UpdateSus(float level)
    {
        stats.UpdateSusUI(level);
    }
    public Image losingReasonImg;
    public Sprite sussySprite, roundLostSprite;
    public void GameOver(string reason)
    {
        if (reason == "round")
        {
            losingReasonImg.sprite = roundLostSprite;
        }
        else
        {
            losingReasonImg.sprite = sussySprite;
        }
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
        // stop spawning balls to prepare to exit
        ballExists = true;
        Time.timeScale = 0;
    }
    void HideNewHigh()
    {
        newHighScoreBox.SetActive(false);
    }
}
