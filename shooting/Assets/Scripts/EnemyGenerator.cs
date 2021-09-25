using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> Enemy;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < 3; i++)
        {
            if(LevelManager.Level == 0)
            {
                Instantiate(Enemy[0], transform.position, transform.rotation);
            }

            if (LevelManager.Level == 1)
            {
                Instantiate(Enemy[1], transform.position, transform.rotation);
            }

            if (LevelManager.Level == 2)
            {
                Instantiate(Enemy[2], transform.position, transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
