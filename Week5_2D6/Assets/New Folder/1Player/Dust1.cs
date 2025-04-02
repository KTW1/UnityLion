using UnityEngine;

public class Dust1 : MonoBehaviour
{
    public float lifetime = 0.5f;

    void Awake()
    {
        Destroy(gameObject, lifetime);

    }

}
