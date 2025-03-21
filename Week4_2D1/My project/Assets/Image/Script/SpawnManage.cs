using Unity.VisualScripting;
using UnityEngine;

public class SpawnManage : MonoBehaviour
{
    public GameObject Enemy;
    public Animator animator;
    void Spawn()
    {
        float RandomX = Random.Range(-2f, 2f); //�¿�� 2���� �����ϰ� ����
        Instantiate(Enemy, new Vector3(RandomX, transform.position.y, 0f), Quaternion.identity);
    }
    void Start()
    {
        Spawn(); //InvokeRepeating("Spawn", 1.0f, 0.5f);
        InvokeRepeating("Spawn", 1.0f, 0.5f);
    }

    void Update()
    {

    }
}
