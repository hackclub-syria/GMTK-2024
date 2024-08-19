using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TopDownGlobalScript : MonoBehaviour
{
    public float[] SpawnCornersX, SpawnCornersY;
    public float ballMoveSpeed;
    public float holeRadius;
    public bool ballExists;
    public int difficulty;
    private int prevDifficulty;
    public float ballSpeedIncreaseRate;
    public int ballCountInThisRound;
    public int[] scoreCountInThisRound = { 0, 0, 0 }; // first index is not actually used
    public int roundsWon;
    // Start is called before the first frame update
    void Start()
    {
        ballExists = false;
        holeRadius = 0.5f;
        difficulty = prevDifficulty = 1;
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
        scoreCountInThisRound[1] = scoreCountInThisRound[2] = 0;
        IncreaseDifficulty(1);
    }
    public void IncreaseDifficulty(int increase)
    {
        difficulty = math.max(math.min(difficulty + increase, 10), 0);
    }
}
