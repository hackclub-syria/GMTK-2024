using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnScript : MonoBehaviour
{
    private float[] SpawnCornersX, SpawnCornersY; // change these values in logic manager only
    public TopDownGlobalScript logic;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<TopDownGlobalScript>();
    }
    // Update is called once per frame
    void Update()
    {
        SpawnCornersX = logic.SpawnCornersX;
        SpawnCornersY = logic.SpawnCornersY;
        if (logic.ballExists == false)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        // Randomly choose 2 adjacent corners and spawn a ball in a random place between them
        int index = Random.Range(0, 4);
        float ballx = Random.Range(SpawnCornersX[index], SpawnCornersX[(index + 1) % 4]);
        float bally = Random.Range(SpawnCornersY[index], SpawnCornersY[(index + 1) % 4]);
        if (logic.ballCountInThisRound < 10)
        {
            GameObject newball = Instantiate(ball, new Vector3(ballx, bally, 0f), transform.rotation);
            logic.ballExists = true;
            logic.ballCountInThisRound++;
            if (logic.ballCountInThisRound % 2 == 0)
            {
                // dad shot this ball
                newball.GetComponent<BallScript>().ballBelongsToTeam = 1;
            }
            else
            {
                // opponent shot this ball   
                newball.GetComponent<BallScript>().ballBelongsToTeam = 2;
            }
        }
        else
        {
            if (logic.scoreCountInThisRound[1] >= logic.scoreCountInThisRound[2])
            {
                // yay dad won
                logic.roundsWon++;
                logic.NewRound();
            }
            else
            {
                // oh no opp won
                // stop spawning balls
                logic.ballExists = true;
            }
        }
    }
}