using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    private int playerScore;
    [SerializeField] private float deathDelayTime = 1.0f;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    private void Start()
    {
        scoreTxt.text = playerScore.ToString();
    }
    public void IncreasePlayerScore()
    {
        playerScore++;
        scoreTxt.text = playerScore.ToString();
    }
    public void killPlayer(GameObject player)
    {
        Destroy(player);
        StartCoroutine(deathDelay());
    }
    private IEnumerator deathDelay()
    {
        yield return new WaitForSeconds(deathDelayTime);
        SceneManager.LoadScene(0);
    }
}
