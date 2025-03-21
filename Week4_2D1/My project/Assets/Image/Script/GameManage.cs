using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public static GameManage instance; //싱글톤
    public Text scoreText;
    public Text StartText; //게임시작전3,2,1

    int score = 0;
    private void Awake()
    {
        if (instance == null) //정적으로 자신을 체크합니다. null인지
        {
            instance = this; //자기자신을 저장한다.
        }
    }

    void Start()
    {
        StartCoroutine("StartGame");
    }


    IEnumerator StartGame()
    {
        int i = 3;
        Time.timeScale = 0;
        while (i > 0)
        {
            StartText.text = i.ToString();
            yield return new WaitForSeconds(1);
            i--;
            if (i == 0)
            {
                StartText.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    void Update()
    {
        
    }
    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score: " + score; //텍스트 업데이트
    }
}
