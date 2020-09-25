﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedLevel : MonoBehaviour {

    public bool isUnlock = false;
    public GameObject lockGo;
    public GameObject unlockGo;

    public int mapIndex;
    public int questNum; //Stars ti unclock level
    

    private void Update() {
        UpdateMapStatus();
        UnlockMap();
    }

    private void UpdateMapStatus() {
        if (isUnlock) {
            unlockGo.gameObject.SetActive(true);
            lockGo.gameObject.SetActive(false);
        } else {
            unlockGo.gameObject.SetActive(false);
            lockGo.gameObject.SetActive(true);
        }
    }

    private void UnlockMap() {
       if (FindObjectOfType<UIManager>().stars >= questNum) {
            isUnlock = true;
       } else {
            isUnlock = false;
        }
    }
}
