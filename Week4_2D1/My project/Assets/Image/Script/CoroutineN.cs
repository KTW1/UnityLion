using System.Collections;
using UnityEngine;

public class CoroutineN : MonoBehaviour
{
    /* 실행/중지/재실행 루틴. 일정시간 후 혹은 조건기다리기/뱀서 선택같은 기능
     */
    void Start()
    {
        StartCoroutine(Coru());
    }

    IEnumerator Coru()
    {
        Debug.Log("start");
        yield return new WaitForSeconds(2f);
        Debug.Log("execute");
    }

    void Update()
    {
        
    }
}
