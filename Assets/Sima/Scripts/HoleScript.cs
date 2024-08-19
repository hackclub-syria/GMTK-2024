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
            transform.localScale = new Vector3(holeRadius, holeRadius, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && holeRadius >= logic.ballRadius)
        {
            BallScript ballScript = collision.gameObject.GetComponent<BallScript>();
            logic.ballExists = false;
            Destroy(collision.gameObject); // we should change this to: shrink then destroy
            logic.UpdateScores(ballScript.ballBelongsToTeam, true);
        }
    }

}
