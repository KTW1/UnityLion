using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float Speed = 1.0f;
    public GameObject target;
    Vector2 dir;
    Vector2 dirNo;
    void Start()
    {
        //Ÿ��. ������Ʈ find�±�
        target = GameObject.FindGameObjectWithTag("Player");
        dir = target.transform.position - transform.position;
        dirNo = dir.normalized;
    //Ÿ����ġ-��ġ. ����ȭ �븻������
    }

    void Update()
    {
        transform.Translate(Speed * dirNo* Time.deltaTime);
    }
}
