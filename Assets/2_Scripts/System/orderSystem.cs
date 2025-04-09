using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class orderSystem : MonoBehaviour
{
    public int Customer; //1.무샹, 2.아저씨, 3.여자애, 4.SUN, 5.판다
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
        //주문자 스프라이트
        Order_Image.sprite = Order_Sprite[Customer];

        //주문자 이름 출력
        Order_Text[0].text = CustomerName;

        //1.주문
        a = Random.Range(1, 5);
        Debug.Log("Random " + a);
        if (a == 1)
        {
            Order_Text[1].text = "오리지날";
        }
        if (a == 2)
            Order_Text[1].text = "레드 콤보";
        if (a == 3)
            Order_Text[1].text = "황금 올리브";
        if (a == 4)
            Order_Text[1].text = "허니 콤보";

        //2.결제 금액
        b = RandomWithStep(10000, 50000, 1000);
        Order_Text[2].text ="가격: "+ b + "원";

        //3.요청사항(랜덤 텍스트)
        c = Random.Range(1, 5);
        if (c == 1)
            Order_Text[3].text = "요청 사항:\n치킨무 많이, 꽉꽉 채워주세요.";
        if (c == 2)
            Order_Text[3].text = "요청 사항:\nㄹl뷰 이벤트 참여했어요! 콜라 하나 더 주세요.";
        if (c == 3)
            Order_Text[3].text = "요청 사항:\n닭다리 하나 더 주세요.";
        if (c == 4)
            Order_Text[3].text = "요청 사항:\n배고파요 빨리 오세요.";
    }

    void Update()
    {
        if (Delivery.hasChicken == 1 && CanOrder)
        {
            Debug.Log("오더 시작");
            Customer = Random.Range(0, Order_Sprite.Length);
            CanOrder = false;

            if (Customer == 0)
            {
                //주문자 명
                CustomerName = "무샹";
                Order();
            }

            if (Customer == 1)
            {
                //주문자 명
                CustomerName = "아저씨";
                Order();
            }

            if (Customer == 2)
            {
                //주문자 명
                CustomerName = "여자애";
                Order();
            }

            if (Customer == 3)
            {
                //주문자 명
                CustomerName = "SUN";
                Order();
            }

            if (Customer == 4)
            {
                //주문자 명
                CustomerName = "판다";
                Order();
            }
        }
    }
}
