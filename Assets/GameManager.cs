using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject timer;
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
}
