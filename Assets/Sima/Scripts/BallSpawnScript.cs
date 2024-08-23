using UnityEngine;

public class BallSpawnScript : MonoBehaviour
{
    public TopDownGlobalScript logic;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<TopDownGlobalScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (logic.ballExists == false)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        // Randomly choose 2 adjacent corners and spawn a ball in a random place between them
        int index = Random.Range(0, 4);
        float ballx = Random.Range(logic.corners[index].position.x, logic.corners[(index + 1) % 4].position.x);
        float bally = Random.Range(logic.corners[index].position.y, logic.corners[(index + 1) % 4].position.y);
        GameObject newball = Instantiate(ball, new Vector3(ballx, bally, 0f), transform.rotation);
        logic.ballExists = true;
        logic.ballCountInThisRound++;
        if (logic.ballCountInThisRound % 2 == 0)
        {
            // dad shot this ball
            newball.GetComponent<BallScript>().ballBelongsToTeam = 1;
        }
        else
        {
            // opponent shot this ball   
            newball.GetComponent<BallScript>().ballBelongsToTeam = 2;
        }
    }
}
