using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public GameObject hole;
    public TopDownGlobalScript logic;
    private float ballMoveSpeed; // change this value in logic manager only
    public int ballBelongsToTeam; // 1 for dad's team, 2 for opponent's team
    private UnityEngine.Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<TopDownGlobalScript>();
        hole = GameObject.Find("Hole");
        if (ballBelongsToTeam == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        dir = (hole.transform.position - transform.position).normalized;
        dir += new UnityEngine.Vector3(UnityEngine.Random.Range(-0.15f, 0.15f), UnityEngine.Random.Range(-0.15f, 0.15f), 0f);
    }
    // Update is called once per frame
    void Update()
    {
        ballMoveSpeed = logic.ballMoveSpeed;
        // if its outside range, destroy it and report
        transform.position += ballMoveSpeed * Time.deltaTime * dir;
        if (transform.position.x > logic.corners[3].position.x + 0.2|| // Check right boundary
            transform.position.x < logic.corners[0].position.x - 0.2|| // Check left boundary
            transform.position.y > logic.corners[0].position.y + 0.1|| // Check top boundary
            transform.position.y < logic.corners[1].position.y - 0.1)// Check bottom boundary
        {
            logic.UpdateScores(ballBelongsToTeam, false);
            DestroyBall();
        }
        // Make it white when it's in-range
        if (gameObject.GetComponent<SpriteRenderer>().color != Color.white
            && (transform.position.x < logic.corners[3].position.x - logic.visionXMargin && // Check right boundary
            transform.position.x > logic.corners[0].position.x + logic.visionXMargin && // Check left boundary
            transform.position.y < logic.corners[0].position.y - logic.visionYMargin && // Check top boundary
            transform.position.y > logic.corners[1].position.y + logic.visionYMargin))   // Check bottom boundary)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void DestroyBall()
    {
        logic.ballExists = false;
        Destroy(gameObject);
    }
}
