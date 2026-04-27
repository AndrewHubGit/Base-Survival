using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private int _minSpawnRadius;
    [SerializeField] private int _maxSpawnRadius;
    [SerializeField] private int _spawnRate;
    [SerializeField] private Transform _baseCentre;
    [SerializeField] private Transform _playerCenter;
    [SerializeField] private GameObject _enemy;
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        for (int i = 0; i < 10; i++)
        {
            var distance = Random.Range(_minSpawnRadius, _maxSpawnRadius);
            Vector3 direction = Random.insideUnitCircle.normalized;
            var spawnedEnemy = Instantiate(_enemy, _baseCentre.position + new Vector3(direction.x, 0, direction.y) * distance, _baseCentre.rotation);
            var randomTarget = Random.Range(0, 2);
            if(randomTarget == 0)
            {
                spawnedEnemy.GetComponent<Enemy>().TargetPosition(_playerCenter);
            }
            else
            {
                spawnedEnemy.GetComponent<Enemy>().TargetPosition(_playerCenter);
            }
            yield return new WaitForSeconds(_spawnRate);
        }
        
    }
}
