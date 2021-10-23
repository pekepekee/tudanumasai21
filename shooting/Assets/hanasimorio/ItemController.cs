using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    //アイテム速度
    [SerializeField] float ItemSpeed = 2;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -ItemSpeed);
        if (transform.position.x < -7.5 || transform.position.x > 7.5 ||
            transform.position.y < -7.5 || transform.position.y > 7.5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //playerに当たったら消える
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    //カメラに映らなくなったら破壊
    

}
