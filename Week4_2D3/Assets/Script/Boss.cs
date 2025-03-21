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
        //�����ֱ�, �߻�ü ��������. ���̰�. ���� ����ġ (�׻� ���� ��ġ�� �߻����� �ʵ��� ����)
        float attackRate = 3;
        int count = 30;
        float intervalAngle = 360 / count;
        float weightAngle = 0f;

        //�� ���·� ����ϴ� �߻�ü ����(count ���� ��ŭ)
        while (true)
        {

            for (int i = 0; i < count; ++i)
            {
                GameObject clone = Instantiate(mb2, transform.position, Quaternion.identity);

                //c;one ������Ʈ. �߻�ü ���� + conut �̵� ����
                float angle = weightAngle + intervalAngle * i;
                
                //x��cos y�� sin. ������ pi/180 ����=��
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                //clone�� ������Ʈ class. �Ѿ� �̵���ǥ ����
                clone.GetComponent<BBullet>().Move(new Vector2(x, y));
            }
            
            weightAngle += 1;

            //�ڷ�ƾ �ݺ�. ���ð�=�����ֱ�
            yield return new WaitForSeconds(attackRate);

        }

    }

    private void Update()
    {
        if (transform.position.x >= 1)
            flag *= -1;
        if (transform.position.x <= -1)
            flag *= -1;
        //��ǥ�� 1������ ��. , -1���� ��. 

        transform.Translate(flag * speed * Time.deltaTime, 0, 0);
    }
}
