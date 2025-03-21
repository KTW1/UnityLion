using Unity.VisualScripting;
using UnityEngine;

public class pBullet : MonoBehaviour
{
    //전역 실수형 Speed 값은 4
    public float Speed = 4.0f;
    public GameObject effect;
    public GameObject Item;
    public int Attack = 10;
    void Start()
    {
        
    }

    void Update()
    {
        //변환 전환 Vector2 위, 속도, 델타타임
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    //폐쇄적 함수 트리거2d. 콜리더 충돌시
    //태그 몬스터 충돌시. 몬스터.충돌/삭제. 미사일삭제
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(go, 1f);
            GameObject power = Instantiate(Item, transform.position, Quaternion.identity);
            Destroy(power, 10f);

            collision.gameObject.GetComponent<Monster>().Damage(Attack);
            //충돌시. 오브젝트에.컴포넌트 Monater에. 데미지 호출
            Destroy(collision.gameObject);
            Destroy(gameObject);
          
        }

        if (collision.CompareTag("Boss"))
        {

            //이펙트생성
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //1초뒤에 지우기
            Destroy(go, 1);

            //미사일 삭제
            Destroy(gameObject);

        }
    }

    private void OnBecameInvisible()
    {
        //파괴 오브젝트
        Destroy(gameObject);
    }

}
