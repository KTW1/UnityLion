using Unity.Cinemachine;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public static Shaker instance;
    private CinemachineCollisionImpulseSource ImpulseSource;

    void Start()
    {
        instance = this;
        ImpulseSource = GetComponent<CinemachineCollisionImpulseSource>();
    }

    public void Shaking()
    {
        if (ImpulseSource != null) { ImpulseSource.GenerateImpulse(); }
    }   
    void Update()
    {
        
    }
}