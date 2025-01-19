using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform pfEnemy;
    private Animator animator;

   private void Awake() {


    for(int i = 0; i < 10; i++)
    {
        int enemyNum = Random.Range(0, 20);
        for (int j = 0; j< enemyNum ; j++)
        {
            Instantiate(pfEnemy,new Vector3(0f,0f,i*30),Quaternion.identity,transform.parent);
        }
        
    }
   }
}
