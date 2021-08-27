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
    [SerializeField] float speed = 5;

    //Bullet プレハブ
    public GameObject bullet;

    //発射の間隔
    [SerializeField] int count;

    //レート
    [SerializeField] int frame;


    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D Conpo を取得して格納
        rb = GetComponent<Rigidbody2D>();

        //bulletの発射処理を実行(完全オート）
        //StartCoroutine("Shot");

       // frame = 0;//format
        //count = 10;//fortmat
    }

    // Update is called once per frame
    void Update()
    {
        //レートをカウント
        frame++;

        //右・左の入力
        x = Input.GetAxisRaw("Horizontal");

        //上・下の入力
        y = Input.GetAxisRaw("Vertical");

        //移動する向きを求め、xとyをdirectionに渡す
        Vector2 direction = new Vector2(x, y).normalized;

        //移動とスピードを代入
        rb.velocity = direction * speed;

        //スペースを押してる＆10秒ごとに弾を発射
        if(Input.GetKey(KeyCode.Space)&& frame % count == 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            
        }

      

    }


    //bulletの発射処理(完全オート）
    /*IEnumerator Shot()
    {
        while (true)
        {
            //bulletを生成
            Instantiate(bullet, transform.position, transform.rotation);

            //wait time
            yield return new WaitForSeconds(100f);
        }
    }*/

}
