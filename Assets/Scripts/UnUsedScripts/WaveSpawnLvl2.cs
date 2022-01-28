using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class WaveSpawnLvl2 : MonoBehaviour
{
    public enum SpawnState
    {
        Spawning, Waiting, Counting
    }
    
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

     GlobalDataLvl1 gd;
    public Wave[] waves;
    private int nextwave = 0;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;
    private SpawnState state = SpawnState.Counting;

    public Transform[] spawnPoints;
    
    private void Start()
    {
        if (spawnPoints.Length ==0)
        {
            Debug.LogError("nospawnreferenced");
        }
        
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.Waiting)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        
        if (waveCountdown <=0)
        {
            if (state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextwave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave finished");

        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if (nextwave + 1 > waves.Length - 1)
        {
            nextwave = 0;
            Debug.Log("Finshed all Waves!");
            //Time.timeScale = 0f;
            GameObject.Find("Manager").GetComponent<GlobalDataLvl2>().GameWin();
            Debug.Log("Called");
        }
        else
        {
            nextwave++;            
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown<=0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("beginwave" + _wave.name);
        state = SpawnState.Spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.Waiting;
        
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("spawning enemy:"+ _enemy.name);

        
        Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
        
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
    
    
}
