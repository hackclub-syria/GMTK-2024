using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectController : MonoBehaviour
{
    public bool SpawnedLeft;
    public int speed;
    private SpriteRenderer sr;
    public Animator insectAnimator;
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
            insectAnimator.CrossFade("BITE",0f);
            collision.GetComponent<Animator>().CrossFade("OUCH", 0f);
            Destroy(gameObject, 1f);
        }
    }
    public void Killed()
    {
        // play animation and destroy
    }
}
