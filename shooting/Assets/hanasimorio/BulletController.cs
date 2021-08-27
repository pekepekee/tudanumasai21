using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //bulletの速度
    [SerializeField] float bs = 5;
    
    //rigidbody2Dを格納
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   //前方に球を発射
        rb.velocity = new Vector2(0, bs);
    }

   //カメラに映らなくなったら破壊
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

