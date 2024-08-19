using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

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
    [Header("* Other")]
    public float holeRadius;

    // Start is called before the first frame update
    void Awake()
    {
        ballExists = false;
        holeRadius = 0.5f;
        difficulty = prevDifficulty = 1;
        stats = GameObject.FindGameObjectWithTag("UI Manager").GetComponent<StatScreenScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (difficulty != prevDifficulty)
        {
            ballMoveSpeed += (difficulty - prevDifficulty) * ballSpeedIncreaseRate;
            prevDifficulty = difficulty;
        }
    }

    public void NewRound()
    {
        ballCountInThisRound = 0;
        for (int i = 1; i <= 2; i++)
            for (int j = 0; j < 5; j++)
                stats.scoresInThisRound[i, j] = -1;
        scoreCountInThisRound[1] = scoreCountInThisRound[2] = 0;
        IncreaseDifficulty(1);
    }
    public void IncreaseDifficulty(int increase)
    {
        difficulty = math.max(math.min(difficulty + increase, 10), 0);
    }
    public void UpdateScores(int team, bool scored)
    {
        scoreCountInThisRound[team]++;
        if (scoreCountInThisRound[1] == 5)
        {
            // round has been won by dad :)
            NewRound();
        }
        else if (scoreCountInThisRound[2] == 5)
        {
            // round has been won by opponent ;-;
            // stop spawning balls to prepare to exit
            ballExists = true;
        }
        stats.UpdateScoreUI(team, scored);
    }

    public void UpdateSus(float level)
    {
        stats.UpdateSusUI(level);
    }
}
