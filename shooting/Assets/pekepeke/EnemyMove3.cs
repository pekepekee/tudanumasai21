using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove3 : MonoBehaviour
{
    public EnemyBullet Ebullet;
    GameObject player;
    int faze = 0;   //移動用Faze
    public float Espeed = 1;    //敵のスピード
    float moved = 0;    //移動距離用の変数
    public int EnemyHP = 300;
   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(CPU1());
        StartCoroutine(CPU2());
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(faze)
        {
            case 0:
                transform.position -= new Vector3(Espeed, 0, 0) * Time.deltaTime;
                moved += Espeed * Time.deltaTime;
                if(moved > 2)
                {
                   
                        faze = 1;
                        moved = 0;
                    
                }
                break;
            case 1:
                transform.position += new Vector3(0, Espeed, 0) * Time.deltaTime;
                moved += Espeed * Time.deltaTime;
                if (moved > 2)
                {
                   
                        faze = 2;
                        moved = 0;
                    
                }
                break;
            case 2:
                transform.position += new Vector3(Espeed, 0, 0) * Time.deltaTime;
                moved += Espeed * Time.deltaTime;
                if (moved > 4)
                {
                    
                        faze = 3;
                        moved = 0;
                    
                }
                break;
            case 3:
                transform.position -= new Vector3(0, Espeed, 0) * Time.deltaTime;
                moved += Espeed * Time.deltaTime;
                if (moved > 2)
                {
                    
                        faze = 4;
                        moved = 0;
                    
                }
                break;
            case 4:
                transform.position -= new Vector3(Espeed, 0, 0) * Time.deltaTime;
                moved += Espeed * Time.deltaTime;
                if (moved > 2)
                {
                    
                        faze = 0;
                        moved = 0;
                    
                }
                break;
            default:
                break;
        }
    }

    void Shot(float angle,float speed)
    {
        EnemyBullet bullet = Instantiate(Ebullet, transform.position, transform.rotation);
        bullet.Setting(angle,speed);
    }

    IEnumerator CPU1()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            yield return WaveNShotMCurve(2, 16);
        }

        
    }

    IEnumerator CPU2()
    {
        while (true)
        {
            yield return WaveNShotM(4, 32);
            yield return new WaitForSeconds(1f);
            yield return WaveNShotM(3, 20);
            yield return new WaitForSeconds(1f);
            yield return WaveNPlayerAimShot(5, 6);
            yield return new WaitForSeconds(0.5f);
            yield return WaveNPlayerAimShot(5, 6);
            yield return new WaitForSeconds(0.5f);
            yield return WaveNPlayerAimShot(5, 6);
            yield return new WaitForSeconds(0.5f);
            yield return WaveNShotM(4, 32);
            yield return new WaitForSeconds(1f);
            yield return WaveNPlayerAimShot2(6);
            yield return new WaitForSeconds(0.2f);
            yield return WaveNPlayerAimShot2(6);
            yield return new WaitForSeconds(0.2f);
            yield return WaveNPlayerAimShot2(6);
            yield return new WaitForSeconds(0.2f);
            yield return WaveNPlayerAimShot2(6);
            yield return new WaitForSeconds(0.2f);
            yield return WaveNPlayerAimShot2(6);
            yield return new WaitForSeconds(0.2f);
            yield return WaveNPlayerAimShot2(6);
            yield return new WaitForSeconds(1);
        }
    }

    

    IEnumerator WaveNShotM(int n,int m)
    {
        for(int w = 0;w < n; w++)
        {
            ShotN(m, 1);
            yield return new WaitForSeconds(0.3f);
        }
        
    }

    IEnumerator WaveNShotMCurve(int n, int m)
    {
        for (int w = 0; w < n; w++)
        {
            yield return ShotNCurve(m, 3);
            yield return new WaitForSeconds(0.3f);
        }

    }

    IEnumerator WaveNPlayerAimShot(int n, int m)
    {
        for (int w = 0; w < n; w++)
        {
            PlayerAimShot(m, 7);
            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator WaveNPlayerAimShot2(int n)
    {
        for (int w = 0; w < n; w++)
        {
            PlayerAimShot2(10);
            yield return new WaitForSeconds(0.05f);
        }

    }
    void ShotN(int count,float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount);
            Shot(angle,speed);
        }
    }

    IEnumerator ShotNCurve(int count, float speed)
    {
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount);
            Shot(angle - Mathf.PI/2f, speed);
            Shot(-angle - Mathf.PI / 2f, speed);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void PlayerAimShot(int count,float speed)
    {
        Vector3 diffPosition = player.transform.position - transform.position;
        float angleP = Mathf.Atan2(diffPosition.y,diffPosition.x);
       
        int bulletCount = count;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = (i - bulletCount/2f) * ((Mathf.PI/2f) / bulletCount);
            Shot(angleP + angle, speed);
        }
    }

    void PlayerAimShot2(float speed)
    {
        Vector3 diffPosition = player.transform.position - transform.position;
        float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);
        Shot(angleP, speed);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            EnemyHP--;
            if(EnemyHP == 0)
            {
                Debug.Log("Clear2");
            }
        }
    }
}
