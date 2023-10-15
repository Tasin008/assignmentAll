using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int playerScore;
    
    public void IncreasePlayerScore()
    {
        playerScore++;
        print($"the player score is: {playerScore}");
    }
    
}
