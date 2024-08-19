using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreLogicScript : MonoBehaviour
{
    public int roundNumber;
    //keeps trak of the number of the ball in each round
    private int ballInRoundNumber;
    public Sprite indecatorOn;
    public Sprite indecatorOff;
    public int playerScore = 0;
    public int enemyScore = 0;
    public GameObject[] playerScoreIndicators;
    public GameObject[] enemyScoreIndicators;
    
    [ContextMenu("addplayerscore")]
    public void test(){
        addenemyScore(1);
    }

    public void addPlayerScore(int addedScore){
        playerScore += addedScore;
        ballInRoundNumber += 1;
        numberOfPlayerOnIndicators(playerScore);
    }
    public void addenemyScore(int addedScore){
        enemyScore += addedScore;
         ballInRoundNumber += 1;
        numberOfEnemyOnIndicators(enemyScore);
        

    }
    //changes the number of on indicators
    public void numberOfPlayerOnIndicators(int numberOfIndicators){
        for (int i = 0; i < 5; i++){
            if(i<numberOfIndicators){
             SpriteRenderer indicatorSpriteRenderer = playerScoreIndicators[i].GetComponent<SpriteRenderer>();
             indicatorSpriteRenderer.sprite = indecatorOn;
            }else{
             SpriteRenderer indicatorSpriteRenderer = playerScoreIndicators[i].GetComponent<SpriteRenderer>();
             indicatorSpriteRenderer.sprite = indecatorOff;
            }
        }

    }
    public void numberOfEnemyOnIndicators(int numberOfIndicators){
        for (int i = 0; i < 5; i++){
            if(i<numberOfIndicators){
             SpriteRenderer indicatorSpriteRenderer = enemyScoreIndicators[i].GetComponent<SpriteRenderer>();
             indicatorSpriteRenderer.sprite = indecatorOn;
            }else{
             SpriteRenderer indicatorSpriteRenderer = enemyScoreIndicators[i].GetComponent<SpriteRenderer>();
             indicatorSpriteRenderer.sprite = indecatorOff;
            }
        }

    }
    

}
