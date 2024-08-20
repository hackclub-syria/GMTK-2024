using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScreenScript : MonoBehaviour
{
    private TopDownGlobalScript logic;
    public int[,] scoresInThisRound = {
        {-1, -1, -1 , -1, -1},
        {-1, -1, -1 , -1, -1},
        {-1, -1, -1 , -1, -1},
    }; // first row is not actually used. ik bro ~zaid

    public GameObject[] dadScoreSpots;
    public GameObject[] joeScoreSpots;

    public Sprite miss, score, blank;
    public Slider susSlider;
    // Start is called before the first frame update

    public GameObject warning;
    void Start()
    {
        ClearScoreBoard();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<TopDownGlobalScript>();
    }

    public void UpdateScoreUI(int team, bool scored)
    {
        for (int i = 0; i < 5; i++)
        {
            if (scoresInThisRound[team, i] == -1)
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
    public void ClearScoreBoard()
    {
        scoresInThisRound = new int[,] {
            { -1, -1, -1 , -1, -1},
        { -1, -1, -1 , -1, -1},
        { -1, -1, -1 , -1, -1},
    };
        for (int i = 0; i < 5; i++)
        {
            dadScoreSpots[i].GetComponent<SpriteRenderer>().sprite = blank;
            joeScoreSpots[i].GetComponent<SpriteRenderer>().sprite = blank;
        }
    }

    public void UpdateSusUI(float level)
    {
        susSlider.value = Mathf.RoundToInt(level);
        if (susSlider.value == 11)
        {
            logic.GameOver("sus");
        }
        if(susSlider.value > 8)
        {
            warning.SetActive(true);
        }
        else
        {
            warning.SetActive(false);
        }
    }
}
