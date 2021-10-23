using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbargenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> HPbar;
    // Start is called before the first frame update
    void Start()
    {
        var parent = this.transform;
        Instantiate(HPbar[0], transform.position, transform.rotation,parent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
