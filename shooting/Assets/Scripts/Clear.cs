﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickNextlevel()
    {
        LevelManager.Level++;
        SceneManager.LoadScene("GameScene");
    }

    public void OnclickTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}