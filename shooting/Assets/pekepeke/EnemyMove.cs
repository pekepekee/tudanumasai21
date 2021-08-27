using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public EnemyBullet Ebullet;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(CPU());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shot(float angle,float speed)
    {
        EnemyBullet bullet = Instantiate(Ebullet, transform.position, transform.rotation);
        bullet.Setting(angle,speed);
    }

    IEnumerator CPU()
    {
        while(true)
        {
            yield return WaveNShotMCurve(2, 16);
            yield return new WaitForSeconds(1f);
            yield return WaveNShotM(3, 20);
            yield return new WaitForSeconds(1f);
        }
        


    }

    IEnumerator WaveNShotM(int n,int m)
    {
        for(int w = 0;w < n; w++)
        {
            ShotN(m, 3);
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
            PlayerAimShot(m, 3);
            yield return new WaitForSeconds(0.3f);
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
}
