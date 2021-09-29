using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
    public GameObject score_object = null;
    // Start is called before the first frame update
    void Start()
    {
        Text score_text = score_object.GetComponent<Text>();
        score_text.text = "SCORE：" + ScoreManager.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickNextlevel()
    {
        LevelManager.Level++;
        SceneManager.LoadScene("GameScene");
    }

    public void OnclickTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
