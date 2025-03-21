using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance{ get; private set; } // 인스턴스 1가지로 다중접근
    private void Awake() //1번 실행
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //씬이 바뀌어도 유지
        }
        else
        {
            Destroy(gameObject); //중복 생성 방지
        }
    }
    public void PrintMessage()
    {
        Debug.Log("싱글톤 메시지");
    }
}
