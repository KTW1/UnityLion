using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float Speed = 1.0f;
    public GameObject target;
    Vector2 dir;
    Vector2 dirNo;
    void Start()
    {
        //타겟. 오브젝트 find태그
        target = GameObject.FindGameObjectWithTag("Player");
        dir = target.transform.position - transform.position;
        dirNo = dir.normalized;
    //타겟위치-위치. 정규화 노말라이즈
    }

    void Update()
    {
        transform.Translate(Speed * dirNo* Time.deltaTime);
    }
}
