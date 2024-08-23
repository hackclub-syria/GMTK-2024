
using UnityEngine;

public class InsectController : MonoBehaviour
{
    public GameManager cameraScript;
    public bool SpawnedLeft;
    public float speed;
    private SpriteRenderer sr;
    public Animator insectAnimator;
    public GameObject dust, Warning;
    private bool cursorLocked = false;
    private Vector3 cursorPosition;
    private float timer = 0;
    public float paralyzeInterval = 1.2f;
    private void Start()
    {
        cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        sr = GetComponent<SpriteRenderer>();
        if (!SpawnedLeft)
        {
            sr.flipX = true;
        }
    }
    private void Update()
    {
        if (cursorLocked)
        {
            if (timer >= paralyzeInterval)
            {
                timer = 0;
                cursorLocked = false;
            }
            else
            {
                GameObject.Find("cursor").transform.position = cursorPosition;
                timer += Time.deltaTime;
            }
        }
        if (SpawnedLeft)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            speed = 0;
            insectAnimator.CrossFade("BITE", 0f);
            Warning.SetActive(true);
            GameObject.Find("player body").GetComponent<Animator>().CrossFade("OUCH", 0f); // f it shitty ass code
            GameObject.Find("cursor").GetComponent<CursorManager>().notParalyzed = false;
            cursorLocked = true;
            cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPosition.z = 0;
            cameraScript.shake = true;
            Invoke(nameof(delay), paralyzeInterval);
            Destroy(gameObject, 1.4f);
        }
    }
    private void delay()
    {
        GameObject.Find("cursor").GetComponent<CursorManager>().notParalyzed = true;
        Warning.SetActive(false);
    }
    public void Killed()
    {
        Instantiate(dust, transform.position, Quaternion.identity);
        speed = 0;
        Destroy(gameObject);
    }
}
