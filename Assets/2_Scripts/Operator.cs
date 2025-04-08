using UnityEngine;

public class Operator : MonoBehaviour
{
    private void Start()
    {
        ex2();
        ex3();
    }

    private static void ex2()
    {
        int mathScore = 95;
        int englishScore = 85;

        if (mathScore >= 60 && englishScore >= 60)
        {
            if ((mathScore + englishScore) / 2 >= 90)
                Debug.Log("우수 합격");
            else Debug.Log("일반 합격");
        }
        else Debug.Log("불합격");
    }
    void ex3()
    {
        int level = 6;
        bool hasSpecialItem = true;
        bool isInBattle = true;

        if (level > 5 && hasSpecialItem && isInBattle)
            Debug.Log("아이템 사용 가능");
        else Debug.Log("아이템 사용 불가능");
    }


    private static void ex1()
    {
        int health = 100;

        if (health > 70)
            Debug.Log("건강해요");
        else if (health > 30)
            Debug.Log("약간 지쳤어요");
        else if (health > 0)
            Debug.Log("위험해요");
        else
            Debug.Log("사망...");
    }
}