using UnityEngine;

public class SoundManage : MonoBehaviour
{
    public static SoundManage Instance;
    public AudioClip SoundBullet;
    public AudioClip soundDie;

    AudioSource myAudio;
    

    private void Awake()
    {
        if(SoundManage.Instance == null)
        {
            SoundManage.Instance = this;
        }
    }
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayBullet()
    {
        myAudio.PlayOneShot(SoundBullet);
    }
    void Update()
    {
        
    }
    public void SoundDie()
    {
        myAudio.PlayOneShot(soundDie);
    }
}
