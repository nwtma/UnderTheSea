using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SEInfomation
{
    public string name; // 오디오이름
    public bool isLoop; // 반복재생(배경음악의 경우)
    public AudioClip clip; // 오디오파일
}

public class Character_Audio : MonoBehaviour
{
    public static Character_Audio instance;
    [SerializeField] public SEInfomation[] seInfo = null; // 효과음 오디오 정보
    public List<AudioSource> sePlayer; // 효과음 오디오 플레이어

    private Slider sound_slider;

    // 싱글톤을 위한 초기화과정
    private void Awake()
    {
        // 인스턴스가 null인 상태라면
        if (instance == null)
        {
            instance = this; // 인스턴스는 자기자신
        }

        // 오디오재생 플레이어에 오디오 소스컴퍼넌트를 붙인다
        sePlayer = new List<AudioSource>();
        for (int i = 0; i < seInfo.Length; ++i)
        {
            sePlayer.Add(gameObject.AddComponent<AudioSource>());
            GetComponents<AudioSource>()[i].spatialBlend = 1;
            GetComponents<AudioSource>()[i].minDistance = 2;
            GetComponents<AudioSource>()[i].maxDistance = 30;
            GetComponents<AudioSource>()[i].reverbZoneMix = 1;
        }

        sound_slider = FindObjectOfType<SoundManager>().SE_slider;

    }

    // 효과음을 재생 파라미터로 이름을 받는다
    private void PlaySE(string p_name)
    {
        // seInfo의 배열만큼 반복실행
        for (int i = 0; i < seInfo.Length; ++i)
        {
            // 파라미터로 넘어온 이름과 bgmInfo의 이름과 비교
            if (p_name == seInfo[i].name)
            {
                // 효과음 플레이어의 갯수만큼 반복실행
                for (int j = 0; j < sePlayer.Count; ++j)
                {
                    // seInfo에 담겨있는 오디오클립을 재생하고 반복문을 빠져나간다
                    sePlayer[j].clip = seInfo[i].clip;
                    sePlayer[j].volume = sound_slider.value / 100;
                    sePlayer[j].PlayOneShot(sePlayer[j].clip);
                }
            }
        }
    }

    // 재생중인 모든 효과음을 멈춘다
    private void StopAllSE()
    {
        // 효과음 플레이어의 갯수만큼 반복실행
        for (int i = 0; i < sePlayer.Count; ++i)
        {
            sePlayer[i].Stop(); // 효과음 재생 정지
        }
    }

    public void PlayAudio(string p_name, string p_type)
    {
       if (p_type == "SE") PlaySE(p_name);
    }
    // 오디오재생을 정지하는 메소드
    public void StopAudio(string p_type)
    {
        if (p_type == "SE") StopAllSE();
    }
    // 모든 오디오재생을 정지하는 메소드
    public void StopAllAudio()
    {
        StopAllSE();
    }

    public void MuteSEAudio()
    {
        for (int i = 0; i < sePlayer.Count; ++i)
        {
            sePlayer[i].mute = true;
        }
    }
}
