using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject[] train;

    [SerializeField] float span;
    [SerializeField] float delta;

    int number;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            number = Random.Range(0, train.Length);
            GameObject go = Instantiate(train[number]) as GameObject;
            float px = Random.Range(-2.3f, 2.3f);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
