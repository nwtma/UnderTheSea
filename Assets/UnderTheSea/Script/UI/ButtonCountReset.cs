using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////스킬 버튼 카운트 최대치와 현재의 카운트를 선언하는 클래스
//public class ButtonCount
//{
//    public int max = 2;        //버튼 카운트 최대치
//    public int current = 0;    //현재 버튼이 갖고 있는 카운트 수
//}

public class ButtonCountReset : MonoBehaviour
{
    //스킬아이콘 버튼의 카운트를 초기화 시켜주는 역활을 해주는 함수
    public int Skill_ICon_clickEventReset(int maxButtenCount, int currentButtenCount)  //maxButtenCount = 초기 설정한 버튼의 카운트 값(2), currentButtenCount(1) = 현재 버튼의 카운트 값
    {
        if (currentButtenCount == maxButtenCount - 1) //상수값 1과 currentButtenCount을 더해준 값이 maxButtenCount와 같을 때 실행
            currentButtenCount += 1;

        return currentButtenCount;
    }
}
