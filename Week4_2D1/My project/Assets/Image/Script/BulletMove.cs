using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float Speed = 2.0f;
    public GameObject exposion;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) //enter&Exit
    {
        //if(collision.gameObject.tag == "Enemy") //충돌한 오브젝트의 태그가 Enemy라면
        if(collision.gameObject.CompareTag("Enemy")) //안정적?
        {
            SoundManage.Instance.SoundDie();
            
            Destroy(collision.gameObject); //삭제한다.
            Destroy(gameObject); //총알 삭제.
            GameManage.instance.AddScore(10); //uI스코어+점수반환
            Instantiate(exposion, transform.position, Quaternion.identity);
        }
    }

}
