using System.Collections;
using UnityEngine;
using TMPro;

public class Commentator_logic_script : MonoBehaviour
{
    public enum State { Idle, Surprised, V_surprised, Sus }
    public State Current_state;
    public Sprite Idle_sprite, Surprised_sprite, V_surprised_sprite, Sus_sprite;
    public SpriteRenderer Com_sprite;
    public TMP_Text Comment_text;

    private string[] Idle_comments = new string[]
    {
        "Top o' the mornin' to ya laddies!",
        "I wonder what's for dinner.",
        "What's the craic?",
        "failing means yer playin!",
        "Where's the jacks?",
        "Yer erse is in the wey",
        "2 pints are better than one",
        "I am both scottish and irish, half guinness half whiskey!",
        "GIE IT LALDY!",
        "GIVE IT A LASH!."
    };
    private string[] Surprised_comments = new string[]
    {
        "Great Scot!",
        "Oi swear by me father's tammie!",
        "Jaysus!",
        "smoother than a pint of Guinness on St. Paddy’s Day!",
        "Well, blow me bagpipes",
        "Well, paint me green and call me Nessie!",
        "Would you look at that! As surprising as a sunny day in both Dublin and Glasgow!"
    };
    private string[] Sus_comments = new string[]
    {
        "That’s fishy, like haggis in an Irish stew",
        "y ever get that feeling when the bagpipes play an odd note? Aye, that’s the feeling I’ve got now.!",
        "JaySUS...",
        "I don’t trust that hole... not one bit.",
        "Did that hole just move, or is it the whisky?"
    };

    private float Comment_interval = 5f;
    private float timer; 

    void Start()
    {
        Current_state = State.Idle;
        timer = Comment_interval; 
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Current_state = State.Idle;
            int Rand_ind = Random.Range(0, Idle_comments.Length);
            Comment(Idle_comments[Rand_ind], State.Idle);
            timer = Comment_interval;
        }
    
        switch (Current_state)
        {
            case State.Idle:
                Com_sprite.sprite = Idle_sprite;
                break;

            case State.Surprised:
                Com_sprite.sprite = Surprised_sprite;
                break;

            case State.V_surprised:
                Com_sprite.sprite = V_surprised_sprite;
                break;

            case State.Sus:
                Com_sprite.sprite = Sus_sprite;
                break;
        }
    }

    void Comment(string comment, State New_state = State.Idle)
    {
        UnityEngine.Debug.Log(comment);
        Comment_text.SetText(comment);
        Current_state = New_state;
        timer = Comment_interval;
    }
    [ContextMenu("Surprise_com")]
    void Surprise_com()
    {
        int Rand_ind = Random.Range(0, Surprised_comments.Length);
        Comment(Surprised_comments[Rand_ind], State.Surprised);
    }
    [ContextMenu("V_surprise_com")]
    void V_surprise_com()
    {
        int Rand_ind = Random.Range(0, Surprised_comments.Length);
        Comment(Surprised_comments[Rand_ind], State.V_surprised);
    }
    [ContextMenu("Sus_com")]
    void Sus_com()
    {
        int Rand_ind = Random.Range(0, Sus_comments.Length);
        Comment(Sus_comments[Rand_ind], State.Sus);
    }
    [ContextMenu("Test Comment Function")]
    public void TestComment()
    {
        Comment("No fucking way", State.Surprised);
        Comment_text.SetText("No fucking way man");
    }
}