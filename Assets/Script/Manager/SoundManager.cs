using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource myAudio;
    public AudioClip SoundBullet; //재생할소리
    public AudioClip soundDie; //죽는 사운드

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        myAudio = GetComponent<AudioSource>(); //AudioSource 컴포넌트 가져오기
    }

    public void PlayBulletSound()
    {
        myAudio.PlayOneShot(SoundBullet);
    }

    public void SoundDie()
    {
        myAudio.PlayOneShot(soundDie); //몬스터 죽음사운드
    }
}
