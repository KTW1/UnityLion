using UnityEngine;

public class launcher : MonoBehaviour
{
    public GameObject Bullet;
    void Start()
    {
        //InvokeRepeating(�Լ��̸�,�ʱ������ð�, ������ �ð�)
        InvokeRepeating("Shoot", 0.5f, 0.5f);
    }

    void Shoot()
    {
        //�̻��� ������, ����������, ���Ⱚ ����
        Instantiate(Bullet, transform.position, Quaternion.identity);

    }

    void Update()
    {

    }
}
