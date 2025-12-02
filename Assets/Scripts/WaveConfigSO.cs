using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New wave config", menuName = "WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float speed = 5f;
    [Header("Spawn time")]
    [SerializeField] float minSpawnTime = 0.25f;
    [SerializeField] float maxSpawnTime = 2f;
    
    public GameObject GetEnemyPrefab(int index) {  return enemyPrefabs[index]; }
    public int GetEnemyPrefabCount() {  return enemyPrefabs.Count; }
    public float Speed { get { return speed; } }
    public Transform GetStartingWaypoint() { return pathPrefab.GetChild(0); } 
    public List<Transform> Waypoints
    {
        get
        {
            List<Transform> list = new List<Transform>();

            foreach (Transform t in pathPrefab) list.Add(t);

            return list;
        }
    }
    public float GetRandomSpawnTime()
    {
        return Random.Range(minSpawnTime, maxSpawnTime);
    }
}
