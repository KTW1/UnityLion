using System.Collections;
using UnityEngine;

public class CoroutineN : MonoBehaviour
{
    /* ����/����/����� ��ƾ. �����ð� �� Ȥ�� ���Ǳ�ٸ���/�켭 ���ð��� ���
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
