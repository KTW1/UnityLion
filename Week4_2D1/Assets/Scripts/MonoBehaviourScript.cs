using UnityEngine;

public class MonoBehaviourScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start: ������ ���۵� �� ȣ��˴ϴ�.");

    }

/*    ctrl shift M ����Ű. 
 *    private void OnAudioFilterRead(float[] data, int channels)
    {

    }

    private void OnBecameInvisible()
    {

    }*/

    void Update()
    {
        Debug.Log("Update: �����Ӹ��� ȣ��˴ϴ�.");

    }
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate: ���� ���꿡 ���˴ϴ�.");
    }
}
