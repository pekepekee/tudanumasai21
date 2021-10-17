using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

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

    public void Onclickretry()
    {
        ScoreManager.score = 0;
        AS.PlayOneShot(choice);
        Invoke("Ingame", 0.5f);
        
    }

    public void Onclicktitle()
    {
        ScoreManager.score = 0;
        AS.PlayOneShot(choice);
        Invoke("Title", 0.5f);
    }

    private void Ingame()
    {
        SceneManager.LoadScene("GameScene");
    }
    private void Title()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
