using UnityEngine;

public class HoleScript : MonoBehaviour
{
    public TopDownGlobalScript logic;
    public float holeRadius = 2f;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<TopDownGlobalScript>();

        holeRadius = logic.holeRadius;
        print("since hole radius should be " + logic.holeRadius + " I will set myself to " + holeRadius);
        transform.localScale = new Vector3(holeRadius, holeRadius, 1f);

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
    public GameObject sound;
    public AudioClip goodBol, badBol;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 2 && holeRadius >= logic.ballRadius)
        {

            BallScript ballScript = collision.gameObject.GetComponent<BallScript>();
            logic.ballExists = false;
            logic.UpdateScores(ballScript.ballBelongsToTeam, true);
            if (ballScript.ballBelongsToTeam == 1)
            {
                PlaySound(goodBol);
            }
            else
            {
                PlaySound(badBol);
            }
            Destroy(collision.gameObject); // we should change this to: shrink then destroy
        }
    }
    public void PlaySound(AudioClip s)
    {
        GameObject _sound = Instantiate(sound);
        _sound.GetComponent<AudioSource>().clip = s;
        _sound.GetComponent<AudioSource>().Play();
        Destroy(_sound, 5f);
    }
}
