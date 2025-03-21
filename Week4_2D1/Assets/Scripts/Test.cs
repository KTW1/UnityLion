
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    void Start() // 1회만 실행
    {
        Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update() // 메인/반복
    {
        print("Repeat");
    }
}
