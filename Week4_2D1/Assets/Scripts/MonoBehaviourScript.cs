using UnityEngine;

public class MonoBehaviourScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start: 게임이 시작될 때 호출됩니다.");

    }

/*    ctrl shift M 단축키. 
 *    private void OnAudioFilterRead(float[] data, int channels)
    {

    }

    private void OnBecameInvisible()
    {

    }*/

    void Update()
    {
        Debug.Log("Update: 프레임마다 호출됩니다.");

    }
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate: 물리 연산에 사용됩니다.");
    }
}
