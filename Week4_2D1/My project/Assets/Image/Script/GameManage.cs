using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public static GameManage instance; //�̱���
    public Text scoreText;
    public Text StartText; //���ӽ�����3,2,1

    int score = 0;
    private void Awake()
    {
        if (instance == null) //�������� �ڽ��� üũ�մϴ�. null����
        {
            instance = this; //�ڱ��ڽ��� �����Ѵ�.
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
        scoreText.text = "Score: " + score; //�ؽ�Ʈ ������Ʈ
    }
}
