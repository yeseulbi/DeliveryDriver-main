using UnityEngine;
using UnityEngine.UI;

public class orderSystem : MonoBehaviour
{
    int Customer; //1.����, 2.������, 3.���ھ�, 4.SUN, 5.�Ǵ�

    [SerializeField] Text[] Order_Text;
    [SerializeField] Sprite[] Order_Sprite;
    [SerializeField] Image Order_Image;
    bool CanOrder = true;

    void Order()
    {
        //�ֹ��� ��������Ʈ
        Order_Image.sprite = Order_Sprite[Customer];

        //1.�ֹ�
        int a = Random.Range(1, 2);
        //if (a == 0)
        Order_Text[1].text = "";

        //2.��û����(���� �ؽ�Ʈ)
        int b = Random.Range(1, 2);
        Order_Text[2].text = "";

        //3.���� �ݾ�
        int c = Random.Range(1, 2);
        Order_Text[3].text = "";
    }

    void Update()
    {
        if (Delivery.hasChicken == 1 && CanOrder)
        {
            Debug.Log("���� ����");
            Customer = Random.Range(0, Order_Sprite.Length);
            CanOrder = false;

            if (Customer == 1)
            {
                //�ֹ��� ��
                Order_Text[0].text = "����";
                Order();
            }

            if (Customer == 2)
            {
                //�ֹ��� ��
                Order_Text[0].text = "������";
            }

            if (Customer == 3)
            {
                //�ֹ��� ��
                Order_Text[0].text = "���ھ�";
            }

            if (Customer == 4)
            {
                //�ֹ��� ��
                Order_Text[0].text = "SUN";
            }

            if (Customer == 5)
            {
                //�ֹ��� ��
                Order_Text[0].text = "�Ǵ�";
            }

        }

    }
}
