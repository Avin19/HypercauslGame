using System;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [Header("Element")]
    [SerializeField] private GameObject pfEnemy;

    [Header("Setting")]
    [SerializeField] private float radius = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateEnemies();
    }

    private void GenerateEnemies()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
