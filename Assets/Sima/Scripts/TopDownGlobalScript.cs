using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TopDownGlobalScript : MonoBehaviour
{
    [Header("Properties")]
    public float ballRadius;
    public float maxHoleRadius;
    public float visionXMargin;
    public float visionYMargin;
    public Transform[] corners;
    [Space][Space]
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
