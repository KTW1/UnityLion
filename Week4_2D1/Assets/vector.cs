using UnityEngine;

public class vector : MonoBehaviour
{
    Vector2 v2 = new Vector2(10,10);
    Vector3 v3 = new Vector3(1,1,1);
    //Vector4 v4 = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
    void Start()
    {
        Vector3 a = new Vector3(1, 2, 3);
        //Vector3 b = new Vector3(2, 3, 4);

        //Vector3 c = a + b;
        //Debug.Log("Vec C" + c);

        Vector3 normalize = a.normalized;
        Debug.Log("Normal¡§±‘»≠" + normalize);
    }

    void Update()
    {
        
    }
}
