using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject Ebullet;
    private float k;
    public Quaternion rotation = Quaternion.identity;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BulletSet");
        k = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BulletSet()
    {
        for (int i = 0; i < 40; i++)
        {
            rotation.eulerAngles = new Vector3(0, k, 0);
            yield return new WaitForSeconds(0.3f);
            Instantiate(Ebullet, transform.position, rotation);
            k += 10;
        }
    }
}
