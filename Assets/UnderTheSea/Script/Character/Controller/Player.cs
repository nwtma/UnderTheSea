using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{

    [SerializeField] private float fSpeed;
    [SerializeField] private float fRS;
    [SerializeField] private float fARS;
    private MoveController m_moveController;
    public MoveController MoveController
    {
        get
        {
            if (m_moveController == null)
                m_moveController = GetComponent<MoveController>();
            return m_moveController;
        }
    }

    InputController playerInput;
      
    Vector2 mouseInput;

    void Awake()
    {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
    }

    void Start()
    {
        fARS = fSpeed;
        Character_Audio.instance.PlayAudio("moving", "SE");
    }

    bool isMoving;

    void Update()
    {
        TryRun();
        Vector2 direction = new Vector2(playerInput.Vertical, playerInput.Horizontal) * fARS;
        MoveController.Move(direction);
        
    }

    void TryRun()
    {
        if(GameManager.Instance.InputController.bRun)
        {
            Running();
        }
        if(GameManager.Instance.InputController.bRunFalse)
        {
            RunningFalse();
        }
    }

    private void Running()
    {
        fARS = fRS;
    }

    private void RunningFalse()
    {
        fARS = fSpeed;
    }

}
