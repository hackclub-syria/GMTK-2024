using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectController : MonoBehaviour
{
    public bool SpawnedLeft;
    public int speed;
    private SpriteRenderer sr;
    public Animator insectAnimator;
    public GameObject dust;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (!SpawnedLeft)
        {
            sr.flipX = true;
        }
    }
    private void Update()
    {
        if(SpawnedLeft)
        {
            transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
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
            insectAnimator.CrossFade("BITE",0f);
            GameObject.Find("player body").GetComponent<Animator>().CrossFade("OUCH", 0f); // f it shitty ass code
            GameObject.Find("cursor").GetComponent<CursorManager>().notParalyzed = false;
            Invoke("delay",1.2f);
            Destroy(gameObject, 1.4f);
        }
    }
    private void delay()
    {
        GameObject.Find("cursor").GetComponent<CursorManager>().notParalyzed = true;
    }
    public void Killed()
    {
        Instantiate(dust, transform.position, Quaternion.identity);
        speed = 0;
        insectAnimator.CrossFade("BITE", 0f);
        Destroy(gameObject, 0.1f);
    }
}
