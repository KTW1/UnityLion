using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    int flag = 1;
    int speed = 2;

    public GameObject mb;
    public GameObject mb2;
    public Transform pos1;
    public Transform pos2;
    void Start()
    {
        Invoke("hide", 3);
        StartCoroutine(BossMissle());
        StartCoroutine(CircleFire());
    }

    void hide()
    {
        GameObject.Find("Warning").SetActive(false);
    }

    IEnumerator BossMissle()
    {
        while (true)
        {
            Instantiate(mb, pos1.position, Quaternion.identity);
            Instantiate(mb2, pos2.position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator CircleFire()
    {
        //공격주기, 발사체 생성갯수. 사이각. 각도 가중치 (항상 같은 위치로 발사하지 않도록 설정)
        float attackRate = 3;
        int count = 30;
        float intervalAngle = 360 / count;
        float weightAngle = 0f;

        //원 형태로 방사하는 발사체 생성(count 갯수 만큼)
        while (true)
        {

            for (int i = 0; i < count; ++i)
            {
                GameObject clone = Instantiate(mb2, transform.position, Quaternion.identity);

                //c;one 오브젝트. 발사체 각도 + conut 이동 벡터
                float angle = weightAngle + intervalAngle * i;
                
                //x는cos y는 sin. 각도에 pi/180 곱셈=원
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                //clone에 컴포넌트 class. 총알 이동좌표 설정
                clone.GetComponent<BBullet>().Move(new Vector2(x, y));
            }
            
            weightAngle += 1;

            //코루틴 반복. 대기시간=공격주기
            yield return new WaitForSeconds(attackRate);

        }

    }

    private void Update()
    {
        if (transform.position.x >= 1)
            flag *= -1;
        if (transform.position.x <= -1)
            flag *= -1;
        //좌표가 1오픈쪽 끝. , -1왼쪽 끝. 

        transform.Translate(flag * speed * Time.deltaTime, 0, 0);
    }
}
