using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<EnemyHealth>().takeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy (gameObject);
        }
    }

}
