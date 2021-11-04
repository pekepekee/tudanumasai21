using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualManager : MonoBehaviour
{
    public GameObject Background;
    AudioSource AS;
    public AudioClip choice;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickManual()
    {
        AS.PlayOneShot(choice);
        Background.SetActive(true);
    }

    public void OnclickBack()
    {
        AS.PlayOneShot(choice);
        Background.SetActive(false);
    }

}
