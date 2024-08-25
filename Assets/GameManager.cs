using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject timer;
    public AnimationCurve shakeCurve;
    public float shakeDuration;
    public bool shake = false;
    private Vector3 startPos;
    private float elapsedTime = 0f;
    private void Start()
    {
        timer.SetActive(true);
        StartCoroutine(CountdownCor());
    }
    private IEnumerator CountdownCor()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(3.5f);
        Time.timeScale = 1f;
        timer.SetActive(false);
    }
    public IEnumerator Shaking()
    {
        startPos = transform.position;
        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            float strength = shakeCurve.Evaluate(elapsedTime / shakeDuration);
            transform.position = startPos + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPos;
        elapsedTime = 0;
    }
}
