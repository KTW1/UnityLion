using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Speed = 3f;
    public float Delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject MBullet;
    public int HP = 100;
    public GameObject Item = null;

    void Start()
    {
        //�κ�ũ. 1ȸ��,������
        Invoke("fire", Delay);
    }

    //�Լ�. ���� �ҷ�, ������ms1,2, ȸ������
    void fire()
    {
        Instantiate(MBullet, ms1.position, Quaternion.identity);
        Instantiate(MBullet, ms2.position, Quaternion.identity);

        Invoke("fire", Delay);
    }
    public void Damage(int attack)
    {
        HP -= attack;
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //��ȯ ��ȯ �Ʒ�. ���ǵ�. ��ŸŸ��
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
