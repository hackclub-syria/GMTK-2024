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
    public string[] idleComments = new string[]
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

    private float idleCommentInterval = 5f; // Time in seconds between idle comments
    private float timer; // Timer to track elapsed time

    void Start()
    {
        Current_state = State.Idle;
        timer = idleCommentInterval; // Set initial timer value to the interval
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            int randomIndex = Random.Range(0, idleComments.Length);
            string randomComment = idleComments[randomIndex];
            Comment(randomComment, State.Idle);
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
    }

    [ContextMenu("Test Comment Function")]
    public void TestComment()
    {
        Comment("No fucking way", State.Surprised);
        Comment_text.SetText("No fucking way man");
    }
}
