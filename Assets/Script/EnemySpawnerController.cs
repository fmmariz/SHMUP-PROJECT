using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float enemySpawnDelay;
    [SerializeField]
    private GameObject enemyExplosion;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float _spawnElapsed;
    // Update is called once per frame

    float angle = 0;
    void Update()
    {
        _spawnElapsed+= Time.deltaTime;
        if(_spawnElapsed >= enemySpawnDelay){
            _spawnElapsed = 0;
            SpawnEnemy(Vector3.zero, 0f, 3f);
        }


    }


    private void SpawnEnemy(Vector3 position,float angle, float speed){
        GameObject newEnemy = Instantiate(enemyPrefab,position,Quaternion.identity,null);
        EffectsController.Instance.CreateEnemyImplosion(transform.position, 1f);
        EnemyController ec = newEnemy.GetComponent<EnemyController>();
        ec.SetExplosionObject(enemyExplosion);
        ec.SetupEnemy(angle, speed, 1f);
    }
}
