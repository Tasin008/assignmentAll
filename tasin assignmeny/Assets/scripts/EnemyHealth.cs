using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 10f;
    public void takeDamage(float damage)
    {
        print("take damage");
       
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0)
        {
            die();
        }
    }
    public void die()
    {
        Destroy (gameObject);
    }
}
