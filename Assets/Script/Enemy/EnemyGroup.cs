using System;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [Header("Element")]
    [SerializeField] private GameObject pfEnemy;

    [Header("Setting")]
    [SerializeField] private int amount;
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    // Start is called before the first frame update
    void Start()
    {
        GenerateEnemies();
    }
    // Generate Enemy 
    private void GenerateEnemies()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 enemyPosition = EnemyRunnerPosition(i);

            Vector3 enemyWorldPosition = transform.TransformPoint(enemyPosition);
            Instantiate(pfEnemy, enemyWorldPosition, Quaternion.identity, transform);

        }
    }
    //A void Overlapping of the enemy 
    private Vector3 EnemyRunnerPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * angle * index);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * angle * index);
        return new Vector3(x, 0, z);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
