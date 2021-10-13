using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //rigidbody 2D を格納
    private Rigidbody2D rb;

    //右・左の方向を格納する変数
    float x;
    float y;

    //Playerの移動速度の変数
    //float speed ;
    float CurrentSpeed;
    float StartSpeed;

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

    //SpriteRendererを格納
    public SpriteRenderer sp;

    //ダメージ判定のフラグ
    private bool isDamage { get; set; }

    //HP
    int maxhp = 100;
    int currenthp;
    public Slider slider;
    int EnemyDamage = 20;


    //SpeedItemカウント
    int SpeedItemCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        CurrentSpeed = 6;
        StartSpeed = 6;

        //Rigidbody2D Conpo を取得して格納
        rb = GetComponent<Rigidbody2D>();


        Itemcount = 0;//format

        slider.value = 1; //HP満タン

        currenthp = maxhp;

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
        rb.velocity = direction * CurrentSpeed;

        //レートをカウント
        frame++;

        if(Input.GetKeyDown(KeyCode.X))
        {
            CurrentSpeed = 3;
        }

        if(Input.GetKeyUp(KeyCode.X))
        {
            CurrentSpeed = StartSpeed + SpeedItemCount;
        }

        

        Debug.Log(CurrentSpeed);


        //スペースを押してる＆10秒ごとに弾を発射
        if (Input.GetKey(KeyCode.Z) && frame % count == 0)
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

        //ダメージ判定
        if (isDamage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            sp.color = new Color(1f, 1f, 1f, level);
        }
       
        if(currenthp == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }


    }

    //当たり判定
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
            SpeedItemCount += 1;
            //SpeedUp
            CurrentSpeed = StartSpeed + SpeedItemCount;
        }

        if(collision.gameObject.tag=="Item03")
        {
            ScoreManager.score += 500;
        }

        //敵に当たったら
        if(collision.gameObject.tag == "Enemyshot")
        {
            if (isDamage)
            {
                return;
            }
            StartCoroutine(OnDamage());

            currenthp = currenthp - EnemyDamage;
            slider.value = (float)currenthp / (float)maxhp;


            

        }

        

    }


    public IEnumerator OnDamage()
    {
        isDamage = true;
        yield return new WaitForSeconds(3.0f);

        //通常に戻す
        isDamage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);
    }



}
