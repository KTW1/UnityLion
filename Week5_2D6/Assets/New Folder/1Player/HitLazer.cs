using UnityEngine;

public class HitLazer : MonoBehaviour
{
    [SerializeField]
    float speed = 50f;
    float angle;
    Vector2 Mousepos;
    Transform tr;
    Vector3 dir;
    Vector3 dirNo;

    void Start()
    {
        tr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Mousepos = Input.mousePosition;
        Mousepos = Camera.main.ScreenToWorldPoint(Mousepos);
        Vector3 Pos = new Vector3(Mousepos.x, Mousepos.y, 0);
        dir = Pos - tr.position;
        dirNo = dir.normalized;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Destroy(gameObject, 4f);
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position += dirNo * speed * Time.deltaTime;
    }
}
