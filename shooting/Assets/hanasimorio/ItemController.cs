﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //playerに当たったら消える
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    
    
  }
