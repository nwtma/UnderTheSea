using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 오디오정보 클래스
[System.Serializable]
public class AudioInfomation
{
    public string name; // 오디오이름
    public bool isLoop; // 반복재생(배경음악의 경우)
    public AudioClip clip; // 오디오파일
}

// 오디오를 관리하는 클래스(싱글톤) - 배경음악,효과음,음성을 따로관리
public class SoundManager : MonoBehaviour
{
    // 인스턴스를 정적으로 선언
    public static SoundManager instance;
    [SerializeField] AudioInfomation[] bgmInfo = null; // 배경음악 오디오 정보
    private AudioSource bgmPlayer;
    private int currentBGMIndex; // 현재 플레이중인 배경음악의 인덱스번호

    [SerializeField] public AudioInfomation[] seInfo = null; // 효과음 오디오 정보
    public List<AudioSource> sePlayer; // 효과음 오디오 플레이어
    

    // 싱글톤을 위한 초기화과정
    private void Awake()
    {
        // 인스턴스가 null인 상태라면
        if (instance == null)
        {
            instance = this; // 인스턴스는 자기자신
            DontDestroyOnLoad(gameObject); // 다른씬에서도 사용할수 있게 지정
        }
        else
        {
            Destroy(gameObject); // 인스턴스가 이미 생성중이라면 파괴하고 새로 만들기
        }

        // 오디오재생 플레이어에 오디오 소스컴퍼넌트를 붙인다
        bgmPlayer = this.gameObject.AddComponent<AudioSource>();
        sePlayer = new List<AudioSource>();
        for (int i = 0; i < seInfo.Length; ++i)
        {
            sePlayer.Add(this.gameObject.AddComponent<AudioSource>());
        }

        StartCoroutine(Sleep());    //2초 후 배경음악 재생시킬 함수 호출

    }

    //2초 후 배경음악 재생
    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(2);
        PlayAudio("Title", "BGM");
    }

    // BGM재생 메소드 파라미터로 이름을 받는다
    private void PlayBGM(string p_name)
    {
        // bgmInfo의 배열만큼 반복실행
        for (int i = 0; i < bgmInfo.Length; ++i)
        {
            // 파라미터로 넘어온 이름과 bgmInfo의 이름과 비교
            if (p_name == bgmInfo[i].name)
            {
                // bgmInfo에 담겨있는 오디오클립을 재생하고 반복문을 빠져나간다
                bgmPlayer.clip = bgmInfo[i].clip;
                bgmPlayer.loop = bgmInfo[i].isLoop; // 배경음악 반복재생
                bgmPlayer.Play();
                currentBGMIndex = i; // 현재 재생중인 BGM의 인덱스번호를 저장
                return;
            }
        }
        // 파라미터로 넘어온 이름이 bgmInfo에 없을때 에러로그를 띄운다
        Debug.LogError(p_name + "에 해당하는 배경음악이 없습니다");
    }

    public Slider bgm_slider;
    public Text bgm_text;

    public void BGMvolume()
    {
        bgmPlayer.volume = bgm_slider.value / 100;
        bgm_text.text = string.Format("{0}", bgm_slider.value);
    }

    // 배경음악을 멈춘다
    private void StopBGM()
    {
        bgmPlayer.Stop();
    }

    // 배경음악을 일시정지한다
    private void PauseBGM()
    {
        bgmPlayer.Pause();
    }
    // 배경음악의 일시정지를 푼다
    private void UnPauseBGM()
    {
        bgmPlayer.UnPause();
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
                    sePlayer[j].PlayOneShot(sePlayer[j].clip);
                }
            }
        }
    }

    public Slider SE_slider;
    public Text SE_text;

    public void SEvolume()
    {
        for (int j = 0; j < sePlayer.Count; ++j)
        {
            sePlayer[j].volume = SE_slider.value / 100;
        }
        SE_text.text = string.Format("{0}", SE_slider.value);
    }

    // 효과음을 재생 파라미터로 이름을 받는다
    private void PauseSE()
    {
        // seInfo의 배열만큼 반복실행
        for (int i = 0; i < seInfo.Length; ++i)
        {
            for (int n = 0; n < sePlayer.Count; ++n)
            {
                sePlayer[n].Pause();
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
    
    //--------- 외부에서 호출하는 메소드 --------------
    // 파일이름과 어떤타입의 오디오인지를 인수로 넘겨받는다

    ///
    ///p_Type : BGM -> BGM 배경음악 재생
    ///p_Type : SE -> SE 효과음 재생
    ///
     public void PlayAudio(string p_name, string p_type)
    {
        // 넘겨받은 타입변수값에 따라서 해당 플레이어를 재생시킨다
        if (p_type == "BGM") PlayBGM(p_name);
        else if (p_type == "SE") PlaySE(p_name);
        else Debug.LogError("해당하는 타입의 오디오플레이어가 없습니다");
    }
    // 오디오재생을 정지하는 메소드
    public void StopAudio(string p_type)
    {
        if (p_type == "BGM") StopBGM();
        else if (p_type == "SE") StopAllSE();
        else Debug.LogError("해당하는 타입의 오디오플레이어가 없습니다");
    }
    // 모든 오디오재생을 정지하는 메소드
    public void StopAllAudio()
    {
        StopBGM();
        StopAllSE();
    }
    
}