using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //rigidbody 2D を格納
    private Rigidbody2D rb;

    //右・左の方向を格納する変数
    float x;
    float y;

    //Playerの移動速度の変数
    [SerializeField] float speed = 3;

    //Bullet プレハブ
    public GameObject bullet;

    //Shotposition
    public Transform Shotobject1;
    public Transform Shotobject2;
    public Transform Shotobject3;
    public Transform Shotobject4;
    public Transform Shotobject5;
    public Transform Shotobject6;



    //発射間隔
    public int count;

    //レート
    public int frame;

    //アイテムカウント
    int Itemcount;



    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D Conpo を取得して格納
        rb = GetComponent<Rigidbody2D>();

        Itemcount = 0;//format
    }

    // Update is called once per frame
    void Update()
    {

        //右・左の入力
        x = Input.GetAxisRaw("Horizontal");

        //上・下の入力
        y = Input.GetAxisRaw("Vertical");

        //移動する向きを求め、xとyをdirectionに渡す
        Vector2 direction = new Vector2(x, y).normalized;

        //移動とスピードを代入
        rb.velocity = direction * speed;

        //レートをカウント
        frame++;


        //スペースを押してる＆10秒ごとに弾を発射
        if (Input.GetKey(KeyCode.Space) && frame % count == 0)
        {
            //Itemcountが0の時は通常攻撃
            if (Itemcount == 0)
            {
                Instantiate(bullet, Shotobject1.position, transform.rotation);
            }

            //Itemcountが1の時は攻撃を変える
            if (Itemcount == 1)
            {
                Instantiate(bullet, Shotobject2.position, transform.rotation);
                Instantiate(bullet, Shotobject3.position, transform.rotation);
            }

            //Itemcount = 2
            if(Itemcount == 2)
            {
                Instantiate(bullet, Shotobject4.position, transform.rotation);
                Instantiate(bullet, Shotobject5.position, transform.rotation);
                Instantiate(bullet, Shotobject6.position, transform.rotation);
            }
        }

        
       



    }

    //アイテムをとる判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //弾を増やすアイテムをとったら
        if (collision.gameObject.tag == "Item")
        {
            Itemcount += 1;
        }
        //速度が上がるアイテムをとったら
        if(collision.gameObject.tag == "Item02")
        {
            speed += 2;
        }
    }



}
