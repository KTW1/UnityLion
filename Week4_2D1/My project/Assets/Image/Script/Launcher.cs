using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bullet;
    void Start()
    {
        InvokeRepeating("Shoot", 0.5f, 0.5f);
    }
    public void Shoot()
    {
        //�߿��� �κ�. prefab,  �����ǰ� ����
        Instantiate(bullet, transform.position, Quaternion.identity);
        SoundManage.Instance.PlayBullet();
    }
    void Update()
    {
        
    }
}
