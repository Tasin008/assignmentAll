using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Candy"))
        {
            gameManager.IncreasePlayerScore();
            Destroy(other.gameObject);
        }
    }
}
