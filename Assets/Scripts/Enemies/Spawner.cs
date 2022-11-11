using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SpawnPoints
{
    [SerializeField] private Transform[] points;
    public Transform[] Points { get => points; }
}

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoints[] spawnPoints;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject leftEnemy;
    [SerializeField] private GameObject rightEnemy;

    [SerializeField] private float spawnRate = 3f;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float timeBeforeUpgrade;
    [SerializeField] private float multiplierTimeUpgrade = 1f;
    private float _elapsedUpgradeTime = 0f;
    private Transform _spaceShipTransform;
    private Transform _playerTransform;
    private float _elapsedSpawnTime = 0f;

    private int _lastColumnIndex = -1;
    private float _zOffSet;

    public System.Action<int> OnScoreAdded;
    public System.Action<EnemiesUpgrade> OnEnemiesUpgrade;

    private void Awake()
    {
        _spaceShipTransform = GameObject.FindGameObjectWithTag("SpaceShip").transform;      
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _playerTransform.GetComponent<PlayerHealth>().OnPlayerDeath += PlayerDeath;
    }

    private void PlayerDeath()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        _zOffSet = Mathf.Abs((_spaceShipTransform.position - transform.position).z);
        _elapsedUpgradeTime = timeBeforeUpgrade;
    }

    private void Update()
    {
        Vector3 oldPos = transform.position;
        oldPos.z = _playerTransform.position.z + _zOffSet;
        transform.position = oldPos;

        _elapsedSpawnTime -= Time.deltaTime;

        if(_elapsedSpawnTime <= 0f)
        {
            Spawn();
            _elapsedSpawnTime = spawnRate;
        }

        _elapsedUpgradeTime -= Time.deltaTime;

        if(_elapsedUpgradeTime <= 0f)
        {
            Debug.Log("Increment enemies");
            timeBeforeUpgrade *= multiplierTimeUpgrade;
            _elapsedUpgradeTime = timeBeforeUpgrade;
        }
    }

    private void Spawn()
    {
        int random = Random.Range(0,9);

        if(random == 0)
        {
            //spawn right/left enemies
            int leftOrRight = Random.Range(0, 2);
            if(leftOrRight == 0)
            {
                //spawn left
                SpawnEnemy(spawnPoints[0].Points, leftEnemy);
                _lastColumnIndex = 0;
            }
            else
            {
                //spawn right
                SpawnEnemy(spawnPoints[spawnPoints.Length -1].Points, rightEnemy);
                _lastColumnIndex = spawnPoints.Length - 1;
            }          
        }
        else
        {
            if (_lastColumnIndex != -1)
            {
                int currentIndex = _lastColumnIndex;
                while (currentIndex == _lastColumnIndex)
                {
                    currentIndex = Random.Range(0, spawnPoints.Length);
                }
                SpawnEnemy(spawnPoints[currentIndex].Points, enemies);
            }
            else
            {
                //first spawn of the game
                int randomIndex = Random.Range(0, spawnPoints.Length);
                SpawnEnemy(spawnPoints[randomIndex].Points, enemies);
                _lastColumnIndex = randomIndex;
            }
        }
    }


    private void SpawnEnemy(Transform[] possiblePoints, GameObject enemy)
    {
        Transform randomPoint = possiblePoints[Random.Range(0, possiblePoints.Length)];
        GameObject enemySpawned = Instantiate(enemy, randomPoint.position, Quaternion.identity);
        //enemySpawned.GetComponent<BaseEnemy>().Speed = _spaceShipTransform.GetComponent<PlayerMovment>().ForwardSpeed - 1f;

        enemySpawned.GetComponent<BaseEnemy>().Speed = _playerTransform.GetComponent<PlayerMovment>().ForwardSpeed - enemySpeed;
        enemySpawned.GetComponent<BaseEnemy>().OnEnemyDeath += TriggerScoreEvent;

        //AudioSource.PlayClipAtPoint(AudioManager.Instance.SpawnSfx, _spaceShipTransform.position);
        AudioManager.Instance.PlayClip(AudioManager.Instance.SpawnSfx, enemySpawned);

        //enemySpawned.GetComponent<BaseEnemy>().PlayerRb = playerTransform.GetComponent<Rigidbody>();
        //enemySpawned.transform.SetParent(playerTransform);
    }

    private void SpawnEnemy(Transform[] possiblePoints, GameObject[] enemies)
    {
        Transform randomPoint = possiblePoints[Random.Range(0, possiblePoints.Length)];
        GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];
        GameObject enemySpawned = Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
        //enemySpawned.GetComponent<BaseEnemy>().Speed = _spaceShipTransform.GetComponent<PlayerMovment>().ForwardSpeed - 1f;

        enemySpawned.GetComponent<BaseEnemy>().Speed = _playerTransform.GetComponent<PlayerMovment>().ForwardSpeed - enemySpeed;
        enemySpawned.GetComponent<BaseEnemy>().OnEnemyDeath += TriggerScoreEvent;

        //enemySpawned.GetComponent<BaseEnemy>().PlayerRb = playerTransform.GetComponent<Rigidbody>();
        //enemySpawned.transform.SetParent(playerTransform);
    }

    //private void SpawnEnemy(Transform[] possiblePoints, BaseEnemy[] enemies)
    //{
    //    Transform randomPoint = possiblePoints[Random.Range(0, possiblePoints.Length)];
    //    BaseEnemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
    //    Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
    //}

    private void TriggerScoreEvent(int scoreToAdd)
    {
        OnScoreAdded?.Invoke(scoreToAdd);
    }

}
