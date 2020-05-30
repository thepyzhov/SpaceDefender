﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadGameOver() {
		SceneManager.LoadScene("Game Over");
	}

	public void LoadGameScene() {
		SceneManager.LoadScene("Game Scene");
	}

	public void LoadStartMenu() {
		SceneManager.LoadScene("Start Menu");
	}

	public void QuitGame() {
		Application.Quit();
	}
}
