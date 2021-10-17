using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> Button;
    public GameObject Background;
    public static int Level;

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

    public void OnclickStart()
    {
        AS.PlayOneShot(choice);
        Background.SetActive(true);
        for(int i = 0;i < 3;i++)
        {
            Button[i].SetActive(true);
        }
    }

    public void OnclickLevel1()
    {
        Level = 0;
        AS.PlayOneShot(choice);
        Invoke("Ingame", 0.5f);
        

    }

    public void OnclickLevel2()
    {
        Level = 1;
        AS.PlayOneShot(choice);
        Invoke("Ingame", 0.5f);
        
    }

    public void OnclickLevel3()
    {
        Level = 2;
        AS.PlayOneShot(choice);
        Invoke("Ingame", 0.5f);
    }

    private void Ingame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
