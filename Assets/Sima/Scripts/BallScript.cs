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
        Debug.Log("Ball has been spawned");
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
        transform.position += ballMoveSpeed * Time.deltaTime * dir;
        if (math.abs(transform.position.x) >= 2.61f || math.abs(transform.position.y) >= 1.51f)
        {
            DestroyBall();
        }
        if (gameObject.GetComponent<SpriteRenderer>().color != Color.white && math.abs(transform.position.x) <= 1.4f && math.abs(transform.position.y) <= 0.6f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void DestroyBall()
    {
        Destroy(gameObject);
        logic.ballExists = false;
    }
}
