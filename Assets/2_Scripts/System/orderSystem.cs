using UnityEngine;
using UnityEngine.UI;

public class orderSystem : MonoBehaviour
{
    int Customer; //1.무샹, 2.아저씨, 3.여자애, 4.SUN, 5.판다

    [SerializeField] Text[] Order_Text;
    [SerializeField] Sprite[] Order_Sprite;
    [SerializeField] Image Order_Image;
    bool CanOrder = true;

    void Order()
    {
        //주문자 스프라이트
        Order_Image.sprite = Order_Sprite[Customer];

        //1.주문
        int a = Random.Range(1, 2);
        //if (a == 0)
        Order_Text[1].text = "";

        //2.요청사항(랜덤 텍스트)
        int b = Random.Range(1, 2);
        Order_Text[2].text = "";

        //3.결제 금액
        int c = Random.Range(1, 2);
        Order_Text[3].text = "";
    }

    void Update()
    {
        if (Delivery.hasChicken == 1 && CanOrder)
        {
            Debug.Log("오더 시작");
            Customer = Random.Range(0, Order_Sprite.Length);
            CanOrder = false;

            if (Customer == 1)
            {
                //주문자 명
                Order_Text[0].text = "무샹";
                Order();
            }

            if (Customer == 2)
            {
                //주문자 명
                Order_Text[0].text = "아저씨";
            }

            if (Customer == 3)
            {
                //주문자 명
                Order_Text[0].text = "여자애";
            }

            if (Customer == 4)
            {
                //주문자 명
                Order_Text[0].text = "SUN";
            }

            if (Customer == 5)
            {
                //주문자 명
                Order_Text[0].text = "판다";
            }

        }

    }
}
