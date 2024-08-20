using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMirror : MonoBehaviour
{
    public StatScreenScript statsManager;

    public void ClearScoreBoard()
    {
        statsManager.ClearScoreBoard();
    }
}
