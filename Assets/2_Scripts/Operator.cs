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
                Debug.Log("��� �հ�");
            else Debug.Log("�Ϲ� �հ�");
        }
        else Debug.Log("���հ�");
    }
    void ex3()
    {
        int level = 6;
        bool hasSpecialItem = true;
        bool isInBattle = true;

        if (level > 5 && hasSpecialItem && isInBattle)
            Debug.Log("������ ��� ����");
        else Debug.Log("������ ��� �Ұ���");
    }


    private static void ex1()
    {
        int health = 100;

        if (health > 70)
            Debug.Log("�ǰ��ؿ�");
        else if (health > 30)
            Debug.Log("�ణ ���ƾ��");
        else if (health > 0)
            Debug.Log("�����ؿ�");
        else
            Debug.Log("���...");
    }
}