
using UnityEngine;

public class InsectsGenerator : MonoBehaviour
{
    public GameObject insectPrefab;
    public float timeBetweenInsects;
    public Transform leftSpawnPoint, rightSpawnPoint;

    private float timer;
    private void Start()
    {
        timer = timeBetweenInsects;
    }
    // spawns an insect every `timeBetweenInsects` time passed with randomly going left or right
    private void Update()
    {
        if (timer > 0) { timer -= Time.deltaTime; }
        else
        {
            timer = timeBetweenInsects;
            int randomNum = Random.Range(0, 2);
            if (randomNum == 0)
            {
                GameObject insectGenerated = GameObject.Instantiate(insectPrefab, leftSpawnPoint);
                insectGenerated.GetComponent<InsectController>().SpawnedLeft = true;
            }
            else if (randomNum == 1)
            {
                GameObject insectGenerated = GameObject.Instantiate(insectPrefab, rightSpawnPoint);
                insectGenerated.GetComponent<InsectController>().SpawnedLeft = false;
            }
        }
    }
}
