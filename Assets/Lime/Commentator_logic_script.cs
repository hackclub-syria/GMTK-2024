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

    // Array of possible idle comments
    private string[] idleComments = new string[]
    {
        "Just another day...",
        "I wonder what's for dinner.",
        "Do you think it will rain today?",
        "I could use a coffee right now.",
        "Is it time for a break yet?",
        "I need to finish this task.",
        "I hope everything goes well.",
        "Maybe I should check my emails.",
        "Is it almost lunchtime?",
        "Time to get back to work."
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
            int Rand_ind = Random.Range(0, idleComments.Length);
            Comment(idleComments[Rand_ind], State.Idle);
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

    [ContextMenu("Test Comment Function")]
    public void TestComment()
    {
        Comment("No fucking way", State.Surprised);
        Comment_text.SetText("No fucking way man");
    }
}
