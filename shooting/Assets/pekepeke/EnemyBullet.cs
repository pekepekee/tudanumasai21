using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float dx;
    float dy;
    public void Setting(float angle,float speed)
    {
        dx = Mathf.Cos(angle) * speed;
        dy = Mathf.Sin(angle) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(dx, dy, 0) * Time.deltaTime;
        if(transform.position.x < -7.5 || transform.position.x > 7.5 ||
            transform.position.y < -7.5 || transform.position.y > 7.5)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
