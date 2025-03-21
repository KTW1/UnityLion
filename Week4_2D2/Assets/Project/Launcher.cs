using UnityEngine;

public class launcher : MonoBehaviour
{
    public GameObject Bullet;
    void Start()
    {
        //InvokeRepeating(함수이름,초기지연시간, 지연할 시간)
        InvokeRepeating("Shoot", 0.5f, 0.5f);
    }

    void Shoot()
    {
        //미사일 프리팹, 런쳐포지션, 방향값 안줌
        Instantiate(Bullet, transform.position, Quaternion.identity);

    }

    void Update()
    {

    }
}
