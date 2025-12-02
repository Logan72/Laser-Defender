using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    WaveConfigSO wave;
    int waypointIndex = 0;
    List<Transform> waypoints;

    void Start()
    {
        wave = FindAnyObjectByType<EnemySpawner>().CurrentWave;
        waypoints = wave.Waypoints;
    }
    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector2 targetPoint = waypoints[waypointIndex].position;
            float delta = wave.Speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, delta);

            if (transform.position.Equals(targetPoint)) waypointIndex++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
