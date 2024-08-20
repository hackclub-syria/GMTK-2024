
using UnityEngine;
using TMPro;

public class Commentator_logic_script : MonoBehaviour
{
    public enum State { Idle, Surprised, V_surprised, Sus }
    public State Current_state;
    public Sprite Idle_sprite, Surprised_sprite, V_surprised_sprite, Sus_sprite;
    public SpriteRenderer Com_sprite;
    public TMP_Text Comment_text;
    public GameObject Bubble;

    private string[] Idle_comments = new string[]
    {
        "Top o' the mornin' t'ya laddies!",
        "What's the craic, then?",
        "Failin' means yer playin', aye!",
        "Where's th' jacks?",
        "Yer erse is in the wey!",
        "Two pints are better than one, so they are!",
        "GIE IT LALDY!",
        "GIVE IT A LASH, WILL YA!",
        "I'm both Irish an' Scottish, half beer, half whisky, an' all trouble!"
    };
    private string[] Surprised_comments = new string[]
    {
        "Ma heid's mince, so it is!",
        "Oi swear by me faither's tammie!",
        "Jaysus, Mary, an' Joseph!",
        "Great Scot, would ye look at that!",
        "Smoother than a pint o' Guinness on St. Paddy’s Day!",
        "Blow me bagpipes, I didn’t see that comin'!",
        "Paint me green an' call me Nessie!",
        "Well, I’ll be! As surprisin' as a sunny day in both Dublin an' Glasgow!"
    };
    private string[] Sus_comments = new string[]
    {
        "That’s fishy, like haggis in an Irish stew, so it is.",
        "I got that prickly feelin' when the bagpipes play an odd note...",
        "JaySUS, what’s goin' on here?",
        "I don’t trust that hole... not one bit, aye.",
        "Did that hole just move, or am I seein' things after too much whisky?",
        "It’s like walkin' into a pub an' everyone stops talkin'... somethin’s up!",
        "I’d swear on me lucky shamrock there’s somethin' strange about that hole..."
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
        else if (timer <= 1f)
        {
            Bubble.SetActive(false);
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
        Bubble.SetActive(true);
        Comment_text.SetText(comment);
        Current_state = New_state;
        timer = Comment_interval;
    }
    [ContextMenu("Surprise")]
    void Surprise()
    {
        int Rand_ind = Random.Range(0, Surprised_comments.Length);
        Comment(Surprised_comments[Rand_ind], State.Surprised);
    }
    [ContextMenu("Very Surprise")]
    void V_surprise()
    {
        int Rand_ind = Random.Range(0, Surprised_comments.Length);
        Comment(Surprised_comments[Rand_ind], State.V_surprised);
    }
    [ContextMenu("Sus")]
    void Suspect()
    {
        int Rand_ind = Random.Range(0, Sus_comments.Length);
        Comment(Sus_comments[Rand_ind], State.Sus);
    }

    [ContextMenu("Test")]
    public void TestComment()
    {
        Comment("No fucking way", State.Surprised);
        Comment_text.SetText("No fucking way man");
    }
}
