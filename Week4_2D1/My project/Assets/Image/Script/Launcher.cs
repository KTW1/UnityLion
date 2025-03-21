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
        //중요한 부분. prefab,  포지션과 방향
        Instantiate(bullet, transform.position, Quaternion.identity);
        SoundManage.Instance.PlayBullet();
    }
    void Update()
    {
        
    }
}
