using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
    public GameObject score_object = null;

    AudioSource AS;
    public AudioClip choice;
    // Start is called before the first frame update
    void Start()
    {
        Text score_text = score_object.GetComponent<Text>();
        score_text.text = "SCORE：" + ScoreManager.score;
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickNextlevel()
    {
        ScoreManager.score = 0;
        LevelManager.Level++;
        AS.PlayOneShot(choice);
        Invoke("Ingame", 0.5f);
    }

    public void OnclickTitle()
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
