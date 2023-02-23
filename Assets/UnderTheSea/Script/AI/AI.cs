using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Idle,
    Move,
    Trace, 
    Attack,
}

public class AI : MonoBehaviour
{
    State currentState = State.Move;

    public Ai_Weapon AIweapon;

    private Transform playerPos;    //플레이어 위치
    private Transform AiPos;        //AI 위치

    //ai의 이동에 필요한 변수
    public List<Transform> AiPoint;         //AI 랜덤이동할 위치 리스트
    NavMeshAgent agent;              //네브매쉬 저장할 변수
    int nextPoint = 0;               //다음 목적지 랜덤으로 줄 변수

    public float traceDis;  //추적 범위
    public float attackDis; //공격 범위

    private float MvTime = 1;
    private float MvTime2;
    private bool isAttack;

    private void Start()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        AiPos = this.GetComponent<Transform>();

        SetWaypoint();
    }
    
    private void Update()
    {
        StateAction();
        
        if (isAttack)
        {
            AiLeftRightMove(Time.deltaTime);
        }
    }

    public void SetWaypoint()
    {
        agent = GetComponent<NavMeshAgent>();           //오브젝트의 네브메쉬 가져오기
        agent.autoBraking = false;                      //목적지에 다다르면 속도가 자동으로 줄어드는것 오프

        var PointGroup = GameObject.Find("Ai point");
        if (PointGroup != null)
        {
            PointGroup.GetComponentsInChildren<Transform>(AiPoint); //웨이포인트 그룹의 각 웨이포인트의 위치 확인
            AiPoint.RemoveAt(0);                                    //웨이포인트의 시작지점 제거

            nextPoint = Random.Range(0, AiPoint.Count);             //다음 이동할 지점 랜덤 지정
        }
    }

    public void SetState(State newState)
    {
        currentState = newState;
    }

    public float GetDistance()
    {
        float distance = Vector3.Distance(playerPos.position, this.transform.position);
        return distance;
    }

    public void StateAction()
    {
        switch (currentState)
        {
            case State.Idle:
                {
                    if(GetDistance() > traceDis)
                    {
                        SetState(State.Move);
                    }

                    else if(GetDistance() <= attackDis)
                    {
                        SetState(State.Attack);
                    }

                    else if(GetDistance() <= traceDis)
                    {
                        SetState(State.Trace);
                    }
                }
                break;

            case State.Move:
                {
                    AiMove();
                }
                break;

            case State.Trace:
                {
                    AiTrace();
                }
                break;

            case State.Attack:
                {
                    AiAttack();
                }
                break;
        }
    }

    public void AiMove()
    {
        if (agent.enabled == false)
            return;

        isAttack = false;
        agent.isStopped = false;

        //현재 경로에서 남은 거리가 1f 이하 일때
        if (agent.remainingDistance < 1.0f)
        {
            //다음 이동할 지점 랜덤 지정
            nextPoint = Random.Range(0, AiPoint.Count);
        }

        //현재 경로가 사용 가능한 경로인지 확인
        if (agent.isPathStale)
            return;

        //네브메쉬를 이용한 이동 (네브메쉬.destination : 목적지)
        agent.destination = AiPoint[nextPoint].position;

        SetState(State.Idle);
    }

    public void AiTrace()
    {
        if (agent.enabled == false)
            return;

        isAttack = false;
        agent.isStopped = false;
        agent.destination = playerPos.position;

        SetState(State.Idle);
    }

    public virtual void AiAttack()
    {
        if (agent.enabled == false)
            return;

        agent.isStopped = true;

        isAttack = true;
        
        Vector3 lookAtPoint = new Vector3(playerPos.position.x, AiPos.position.y, playerPos.position.z);
        AiPos.LookAt(lookAtPoint);
        //Vector3 dirToTarget = playerPos.position - AiPos.position;
        //AiPos.rotation = Quaternion.LookRotation(dirToTarget, Vector3.up);
    }

    [SerializeField] public float moveTime;

    public void AiLeftRightMove(float delta)
    {
        AiPos.position += transform.forward * -0.1f;

        //좌우 무빙
        if (MvTime >= 0.7f)
        {
            AiPos.position += transform.right * moveTime;
            MvTime2 += delta;

            if (MvTime2 >= 0.7f)
            {
                MvTime = 0;
            }
        }
        else if (MvTime2 >= 0.7f)
        {
            AiPos.position += transform.right * -moveTime;
            MvTime += delta;
            if (MvTime >= 0.7f)
            {
                MvTime2 = 0;
            }
        }
    }
}