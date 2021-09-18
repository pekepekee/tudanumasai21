using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> Button;
    public GameObject Background;
    public static int Level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickStart()
    {
        Background.SetActive(true);
        for(int i = 0;i < 3;i++)
        {
            Button[i].SetActive(true);
        }
    }

    public void OnclickLevel1()
    {
        Level = 0;
        SceneManager.LoadScene("GameScene");

    }

    public void OnclickLevel2()
    {
        Level = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void OnclickLevel3()
    {
        Level = 2;
        SceneManager.LoadScene("GameScene");
    }
}
