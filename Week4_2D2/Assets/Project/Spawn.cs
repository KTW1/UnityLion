using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Slime;
    public Animator animator;
    void spawn()
    {
        float RandomX = Random.Range(-2f, 2f);
        Instantiate(Slime, new Vector3(RandomX, transform.position.y, 0f), Quaternion.identity);
    }
    void Start()
    {
        spawn();
        InvokeRepeating("Spawn", 1.0f, 0.5f);
    }

    void Update()
    {

    }
}
