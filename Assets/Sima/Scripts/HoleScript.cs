using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    public TopDownGlobalScript logic;
    public float holeRadius = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<TopDownGlobalScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (logic.holeRadius != holeRadius)
        {
            holeRadius = logic.holeRadius;
            transform.localScale = new Vector3(0.5f * holeRadius, 0.5f * holeRadius, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision happened");
        if (collision.gameObject.layer == 3 && holeRadius >= 0.5)
        {
            BallScript ballScript = collision.gameObject.GetComponent<BallScript>();
            ballScript.DestroyBall();
            logic.scoreCountInThisRound[ballScript.ballBelongsToTeam]++;
            if (logic.scoreCountInThisRound[1] == 5)
            {
                // round has been won by dad :)
                logic.NewRound();
            }
            else if (logic.scoreCountInThisRound[2] == 5)
            {
                // round has been won by opponent ;-;
                // stop spawning balls to prepare to exit
                logic.ballExists = true;
            }
        }
    }

}
