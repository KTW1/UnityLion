using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance{ get; private set; } // �ν��Ͻ� 1������ ��������
    private void Awake() //1�� ����
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //���� �ٲ� ����
        }
        else
        {
            Destroy(gameObject); //�ߺ� ���� ����
        }
    }
    public void PrintMessage()
    {
        Debug.Log("�̱��� �޽���");
    }
}
