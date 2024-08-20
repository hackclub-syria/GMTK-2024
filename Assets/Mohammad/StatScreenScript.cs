using UnityEngine;
using UnityEngine.UI;

public class StatScreenScript : MonoBehaviour
{
    private TopDownGlobalScript logic;
    public int scoreInThisRound = 0;
    public Commentator_logic_script commentator;
    // first index is not actually used. ik bro ~zaid

    public SpriteRenderer[] dadScoreSpots;
    public SpriteRenderer[] joeScoreSpots;

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
        // Adjust the score based on which team and whether they scored
        if (scored)
        {
            if (team == 1) // Dad scored
                scoreInThisRound = Mathf.Clamp(scoreInThisRound + 1, -5, 5);
            else if (team == 2) // Joe scored
                scoreInThisRound = Mathf.Clamp(scoreInThisRound - 1, -5, 5);
        }
        else
        {
            if (team == 1) // Dad missed
                scoreInThisRound = Mathf.Clamp(scoreInThisRound - 1, -5, 5);
            else if (team == 2) // Joe missed
                scoreInThisRound = Mathf.Clamp(scoreInThisRound + 1, -5, 5);
        }

        // Update Dad's score points
        for (int i = 0; i < dadScoreSpots.Length; i++)
        {
            if (i < scoreInThisRound) // Positive score indicates Dad's points
                dadScoreSpots[i].sprite = score;
            else
                dadScoreSpots[i].sprite = blank;
        }

        // Update Joe's score points
        for (int i = 0; i < joeScoreSpots.Length; i++)
        {
            if (i < -scoreInThisRound) // Negative score indicates Joe's points
                joeScoreSpots[i].sprite = score;
            else
                joeScoreSpots[i].sprite = blank;
        }
    }
    public TopDownGlobalScript logicManager;
    public void ClearScoreBoard()
    {
        scoreInThisRound = 0;
        for (int i = 0; i < 5; i++)
        {
            dadScoreSpots[i].GetComponent<SpriteRenderer>().sprite = blank;
            joeScoreSpots[i].GetComponent<SpriteRenderer>().sprite = blank;
        }
    }

    bool calledCommentator = false;
    public void UpdateSusUI(float level)
    {
        susSlider.value = Mathf.RoundToInt(level);
        if (susSlider.value == 11)
        {
            logic.GameOver("sus");
        }
        if (susSlider.value > 6)
        {
            if (!calledCommentator)
            {
                commentator.Suspect();
                calledCommentator = true;
                Invoke("delayedCommentary", 5.2f);
            }
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
    void delayedCommentary()
    {
        calledCommentator = false;
    }
}
