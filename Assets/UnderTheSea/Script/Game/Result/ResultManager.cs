using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public static ResultManager instance;
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject defeatUI;
    [SerializeField] GameObject victoryUI;
    [SerializeField] public bool isFinish;
    [SerializeField] private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this; // 인스턴스는 자기자신
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinish)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Option_Manager.instance.Exit_Yes();
            }
        }
    }

    public void Defeat()
    {
        Destroy(Enemy);
        defeatUI.SetActive(true);

        var characterAudio = FindObjectsOfType<Character_Audio>();

        for (int i = 0; i < characterAudio.Length; ++i)
        {
            characterAudio[i].MuteSEAudio();
        }

        SoundManager.instance.StopAllAudio();
        SoundManager.instance.PlayAudio("defeat", "SE");
        isFinish = true;
    }

    public void Victory(float deltatime)
    {
        SoundManager.instance.PlayAudio("BossDead", "SE");
        Health health = FindObjectOfType<Health>();
        health.fHitpoints = 1000;
        health.fDamageTaken = 0;

        time += deltatime;
        Debug.Log(time);

        if (time >= 1.5f)
        {
            Destroy(Enemy);
            victoryUI.SetActive(true);

            var characterAudio = FindObjectsOfType<Character_Audio>();
            for (int i = 0; i < characterAudio.Length; ++i)
            {
                characterAudio[i].MuteSEAudio();
            }

            SoundManager.instance.StopAllAudio();
            SoundManager.instance.PlayAudio("victory", "SE");
            isFinish = true;
        }

    }
}
