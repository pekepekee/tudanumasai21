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
                Instantiate(Enemy[0], transform.position, Quaternion.identity);
            }

            if (LevelManager.Level == 1)
            {
                Instantiate(Enemy[1], transform.position, Quaternion.identity);
            }

            if (LevelManager.Level == 2)
            {
                Instantiate(Enemy[2], transform.position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
