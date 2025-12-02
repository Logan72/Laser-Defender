using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waves;
    [SerializeField] float timeBetweenWaves = 2f;
    [SerializeField] bool isLooping = true;

    public WaveConfigSO CurrentWave { get; private set; }
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waves)
            {
                CurrentWave = wave;

                for (int i = 0; i < wave.GetEnemyPrefabCount(); i++)
                {
                    Instantiate(wave.GetEnemyPrefab(i), wave.GetStartingWaypoint().position, wave.GetEnemyPrefab(i).transform.rotation, transform);
                    yield return new WaitForSeconds(wave.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping);        
    }
}
