using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject EnemyPrefab;

    private GameObject Enemy;

    public Vector2 SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = Instantiate(EnemyPrefab, SpawnPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(SpawnPoint, 0.1f);
    }
}
