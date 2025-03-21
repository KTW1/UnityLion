using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class SpawnN : MonoBehaviour
{

    public float StartTime = 1;
    public float SpawnStop = 10; 
    public GameObject Monster;
    public GameObject Monster2;
    public GameObject Boss;
    //시작시간 1,10. 몬스터 1,2 오브젝트

    bool swi = true;
    bool swi2 = true;
    //while문 판별값

    [SerializeField]
    GameObject warning;


    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("Stop", SpawnStop);
    }

    // 코루틴 함수. 반복/출력 대기시간. 랜덤값. 2차원좌표. 생성
    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            yield return new WaitForSeconds(StartTime);
            float x = Random.Range(-2f, 2f);

            Vector2 r = new Vector2(x, transform.position.y);
            Instantiate(Monster, r, Quaternion.identity);

        }
    }
    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            yield return new WaitForSeconds(StartTime+3);
            float x = Random.Range(-2f, 2f);

            Vector2 r = new Vector2(x, transform.position.y);
            Instantiate(Monster2, r, Quaternion.identity);
        }
    }
    void Stop()
    {
        swi = false;
        StartCoroutine("RandomSpawn");
        StartCoroutine("RandomSpawn2");
        Invoke("Stop2", SpawnStop+20);
    }
    void Stop2()
    {
        swi2 = false;
        StartCoroutine("RandomSpawn2");
        warning.SetActive(true);
        Shaker.instance.Shaking();

        Vector2 pos = new Vector2(0, 3f);
        GameObject boss = Instantiate(Boss, pos, Quaternion.identity);
    }
    void Update()
    {
        
    }
}
