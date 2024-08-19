using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatScreenScript : MonoBehaviour
{
    private TopDownGlobalScript logic;
    public int[,] scoresInThisRound = {
        {-1, -1, -1 , -1, -1},
        {-1, -1, -1 , -1, -1},
        {-1, -1, -1 , -1, -1},
    }; // first row is not actually used

    public GameObject[] dadScoreSpots;
    public GameObject[] joeScoreSpots;

    public Sprite miss, score;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<TopDownGlobalScript>();
    }

    public void UpdateScoreUI(int team, bool scored)
    {
        for (int i = 0; i < 5; i++)
        {
            if (scoresInThisRound[team, i] != -1)
            {
                if (scored)
                {
                    scoresInThisRound[team, i] = 1;
                    if (team == 1)
                    {
                        dadScoreSpots[i].GetComponent<SpriteRenderer>().sprite = score;
                    }
                    else
                    {
                        joeScoreSpots[i].GetComponent<SpriteRenderer>().sprite = score;
                    }
                }
                else
                {
                    scoresInThisRound[team, i] = 0;
                    if (team == 1)
                    {
                        dadScoreSpots[i].GetComponent<SpriteRenderer>().sprite = miss;
                    }
                    else
                    {
                        joeScoreSpots[i].GetComponent<SpriteRenderer>().sprite = miss;
                    }
                }

                break;
            }
        }
    }

    public void UpdateSusUI(float level)
    {

    }
}
