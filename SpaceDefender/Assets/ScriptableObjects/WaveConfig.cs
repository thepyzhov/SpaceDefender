﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config", order = 52)]
public class WaveConfig : ScriptableObject
{
    public GameObject enemyPrefab;
    public GameObject pathPrefab;
    public float timeBetweenSpawns = 0.5f;
    public float spawnRandomFactor = 0.3f;
    public int numberOfEnemies = 5;
    public float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() {
        return enemyPrefab;
	}

    public List<Transform> GetWaypoints() {
        var waveWaypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform) {
            waveWaypoints.Add(child);
		}

        return waveWaypoints;
	}

    public float GetTimeBetweenSpawns() {
        return timeBetweenSpawns;
	}

    public float GetSpawnRandomFactor() {
        return spawnRandomFactor;
	}

    public int GetNumberOfEnemies() {
        return numberOfEnemies;
	}

    public float GetMoveSpeed() {
        return moveSpeed;
	}
}
