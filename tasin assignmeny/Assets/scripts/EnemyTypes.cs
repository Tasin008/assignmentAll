using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypes : MonoBehaviour
{
   
   private enum TypeOfEnemy
    {
        Easy,
        Normal,
        Hard
    }
    [SerializeField] private Material EasyMat;
    [SerializeField] private Material NormalMat;
    [SerializeField] private Material HardMat;
    [SerializeField] private Vector3 EasySize = new Vector3 (0.5f, 0.5f, 0.5f);
    [SerializeField] private Vector3 NormalSize = new Vector3 (1.5f, 1.5f, 1.5f);
    [SerializeField] private Vector3 HardSize = new Vector3(2f, 2f, 2f);
    private TypeOfEnemy typeOfEnemy;
    private Renderer Rend;

    private void Start()
    {
        Rend = GetComponent<Renderer>();
    }
    private void Update()
    {
        switch (typeOfEnemy)
        {
            case TypeOfEnemy.Easy:
                Rend.material = EasyMat;
                transform.localScale = EasySize;
                print ("enemy is easy");
                break;
            case TypeOfEnemy.Normal:
                Rend.material = NormalMat;
                transform.localScale = NormalSize;
                print("enemy is normal");
                break;
            case TypeOfEnemy.Hard:
                Rend.material = HardMat;
                transform.localScale = HardSize;
                print("enemy is hard");
                break;

        }
        if (Input.GetKeyDown(KeyCode.Z)) typeOfEnemy = TypeOfEnemy.Easy;
        else if (Input.GetKeyDown(KeyCode.X)) typeOfEnemy = TypeOfEnemy.Normal;
        else if (Input.GetKeyDown(KeyCode.C)) typeOfEnemy = TypeOfEnemy.Hard;
            
        
    }
}
