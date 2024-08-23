using BayatGames.SaveGameFree;
using UnityEngine;

public class Deleter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            SaveGame.DeleteAll();
        }
    }
}
