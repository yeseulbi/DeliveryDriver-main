using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class orderSystem : MonoBehaviour
{
    public int Customer; //1.����, 2.������, 3.���ھ�, 4.SUN, 5.�Ǵ�
    public string CustomerName;

    [SerializeField] Text[] Order_Text;
    [SerializeField] Sprite[] Order_Sprite;
    [SerializeField] Image Order_Image;


    static public bool CanOrder = true;

    int RandomWithStep(int min, int max, int step)
    {
        int count = ((max - min) / step) + 1;
        int randIndex = Random.Range(0, count);
        return min + randIndex * step;
    }

    public static orderSystem Instance;

    public int a, b, c;
    public static float intMoney;

    void Awake()
    {
        Instance = this;
    }

    void Order()
    {
        //�ֹ��� ��������Ʈ
        Order_Image.sprite = Order_Sprite[Customer];

        //�ֹ��� �̸� ���
        Order_Text[0].text = CustomerName;

        //1.�ֹ�
        a = Random.Range(1, 5);
        Debug.Log("Random " + a);
        if (a == 1)
        {
            Order_Text[1].text = "��������";
        }
        if (a == 2)
            Order_Text[1].text = "���� �޺�";
        if (a == 3)
            Order_Text[1].text = "Ȳ�� �ø���";
        if (a == 4)
            Order_Text[1].text = "��� �޺�";

        //2.���� �ݾ�
        b = RandomWithStep(10000, 50000, 1000);
        Order_Text[2].text ="����: "+ b + "��";

        //3.��û����(���� �ؽ�Ʈ)
        c = Random.Range(1, 5);
        if (c == 1)
            Order_Text[3].text = "��û ����:\nġŲ�� ����, �˲� ä���ּ���.";
        if (c == 2)
            Order_Text[3].text = "��û ����:\n��l�� �̺�Ʈ �����߾��! �ݶ� �ϳ� �� �ּ���.";
        if (c == 3)
            Order_Text[3].text = "��û ����:\n�ߴٸ� �ϳ� �� �ּ���.";
        if (c == 4)
            Order_Text[3].text = "��û ����:\n����Ŀ� ���� ������.";
    }

    void Update()
    {
        if (Delivery.hasChicken == 1 && CanOrder)
        {
            Debug.Log("���� ����");
            Customer = Random.Range(0, Order_Sprite.Length);
            CanOrder = false;

            if (Customer == 0)
            {
                //�ֹ��� ��
                CustomerName = "����";
                Order();
            }

            if (Customer == 1)
            {
                //�ֹ��� ��
                CustomerName = "������";
                Order();
            }

            if (Customer == 2)
            {
                //�ֹ��� ��
                CustomerName = "���ھ�";
                Order();
            }

            if (Customer == 3)
            {
                //�ֹ��� ��
                CustomerName = "SUN";
                Order();
            }

            if (Customer == 4)
            {
                //�ֹ��� ��
                CustomerName = "�Ǵ�";
                Order();
            }
        }
    }
}
