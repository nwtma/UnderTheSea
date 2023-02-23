//GameManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event System.Action<Player> OnLocalPlayerJoined;
    private GameObject Obj;
    public bool result;
    private static GameManager m_Instance;
    public static GameManager Instance
    { 
       get
        {
            //if (m_Instance == null)
            //{
            //    m_Instance = new GameManager();
            //    m_Instance.Obj = new GameObject ("_gameManager");
            //    m_Instance.Obj.AddComponent<Timer>();
            //    m_Instance.Obj.AddComponent<Respawn>();

            //    
            //}

            return m_Instance;

        }//get 끝

        //set
        //{
        //    m_Instance = value;
        //}
    }   //GameManager Instance 끝

    private InputController m_Inputcontroller;
    public InputController InputController
    {
        get
        {
            if (m_Inputcontroller == null)
            {
                m_Inputcontroller = m_Instance.Obj.GetComponent<InputController>();
            }

            return m_Inputcontroller;
        }
    }

    //private Timer m_Timer;
    //public Timer Timer
    //{
    //    get
    //    {
    //        if (m_Timer == null)
    //            m_Timer = Obj.GetComponent<Timer>();
    //        return m_Timer;
    //    }
    //}

    private Player m_LocalPlayer;
    public Player LocalPlayer
    {
        get
        {
            return m_LocalPlayer;
        }

        set
        {
            m_LocalPlayer = value;
            OnLocalPlayerJoined?.Invoke(m_LocalPlayer);
        }


    }
    
    private CharacterInt m_CharacterInt;
    public CharacterInt CharacterInt
    {
        get
        {
            if (m_CharacterInt == null)
            {
                m_CharacterInt = m_Instance.Obj.GetComponent<CharacterInt>();
            }
            return m_CharacterInt;
        }
    }
    void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = new GameManager
            {
                Obj = new GameObject("_gameManager")
            };
            //m_Instance.Obj = GameObject.FindGameObjectWithTag("_gameManager");
            m_Instance.Obj.AddComponent<InputController>();
            //m_Instance.Obj.AddComponent<Timer>();
            m_Instance.Obj.AddComponent<CharacterInt>();
        }
        DontDestroyOnLoad(m_Instance.Obj);
    }
    
}   //class GameManager 끝