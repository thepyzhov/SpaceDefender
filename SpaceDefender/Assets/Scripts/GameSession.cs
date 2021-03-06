﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
	int score = 0;
    int bestScore = 0;

    public int enemyHealthLevel = 1;
    public int enemySpeedLevel = 1;
    public int maxSpeedLevel = 2;
    public int maxHealthLevel = 3;

    public float timeToLevel = 100f;
    public float timeInSeconds = 0f;

    private void Start() {
        bestScore = PlayerPrefs.GetInt("bestScore");
    }

    private void Awake() {
        SetUpSingleton();
    }

    private void Update() {
        TimeToLevelEnd();
    }

	public void TimeToLevelEnd() {
        timeInSeconds += Time.deltaTime;

        if (timeInSeconds >= timeToLevel) {
            timeInSeconds = 0;
            enemySpeedLevel++;

            if (enemySpeedLevel > maxSpeedLevel) {
                enemySpeedLevel = 1;
                enemyHealthLevel++;
            }
        }
    }

    public string GetLevel() {
        return enemyHealthLevel + "-" + enemySpeedLevel;
    }

    private void SetUpSingleton() {
        int numberGameSessions = FindObjectsOfType(GetType()).Length;
        if (numberGameSessions > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore() {
        return score;	
	}

    public int BestScore() {
        if (score > bestScore) {
            PlayerPrefs.SetInt("bestScore", score);
            PlayerPrefs.Save();
            bestScore = PlayerPrefs.GetInt("bestScore");
            return bestScore;
        }
        else return bestScore;
    }

    public bool Buy(int cost) {
        if (cost > score) {
            return false;
		}
        score -= cost;
        FindObjectOfType<AudioManager>().Play("BuySound");
        return true;
	}

	public void AddScore(int score) {
		this.score += score;
	}

	public void ResetScore() {
		Destroy(gameObject);
	}
}
