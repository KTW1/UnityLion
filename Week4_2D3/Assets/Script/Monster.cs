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
        //인보크. 1회용,딜레이
        Invoke("fire", Delay);
    }

    //함수. 생성 불렛, 포지션ms1,2, 회전없음
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
        //변환 전환 아래. 스피드. 델타타임
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
