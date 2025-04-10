using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Delivery : MonoBehaviour
{

    public static int hasChicken = 0; //0.기본 1.닭고기 보유 2.치킨 보유
    bool Seasoning = false;
    bool Open;

    [SerializeField] Text Order;
    [SerializeField] Text Money;
    [SerializeField] GameObject akfvndtjs;
    [SerializeField] GameObject[] mistake_akfvndtjs; // 각 Customer 마다 다르게 수정
    [SerializeField] GameObject OrderObj;
    [SerializeField] GameObject Driver_Chicken;
    [SerializeField] GameObject Driver_Fried;
    [SerializeField] Animator Orderanimator;
    [SerializeField] Button Order_Exit_Open_Button;
    SpriteRenderer spriteRenderer;

    public Chicken chickenCS;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        akfvndtjsSetActive();
        OrderObj.SetActive(false);

        if (Order_Exit_Open_Button != null)
        {
            Order_Exit_Open_Button.onClick.AddListener(Order_Exit_Open_Click);
        }
    }

    void akfvndtjsSetActive()
    {
        akfvndtjs.SetActive(false);
    }
    void mistake_akfvndtjsSetActive()
    {
        mistake_akfvndtjs[orderSystem.Instance.Customer].SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken") && hasChicken == 0) // 치킨 먹었을 때
        {
            Order.text = "닭고기 획득! 오더에 맞게 조리하자";
            
            orderSystem.CanOrder = true;
            Open=true;
            Seasoning = true;
            hasChicken = 1;

            Driver_Chicken.SetActive(true);
            OrderObj.SetActive(true);
            
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Store") && hasChicken == 0) // 닭고기가 없는 데 말 걸었을 때
        {
            akfvndtjs.SetActive(true);
            Invoke(nameof(akfvndtjsSetActive), 2f);
        }
        if (orderSystem.Instance != null &&
    !string.IsNullOrEmpty(orderSystem.Instance.CustomerName) &&
    collision.gameObject != null)
        {
            if (orderSystem.Instance.CustomerName == collision.gameObject.name)
            {
                if (collision.gameObject.CompareTag("Customer") && hasChicken == 2)
                {
                    if (orderSystem.Instance.a != buttonSystem.Seasoning) // 주문과 치킨 종류가 다를 시 발생
                    {
                        mistake_akfvndtjs[orderSystem.Instance.Customer].SetActive(true);
                        Debug.Log("잘 못 가져왔다...");
                        Invoke("mistake_akfvndtjsSetActive", 2f);
                    }
                    else
                        orderSystem.intMoney += orderSystem.Instance.b;
                    Money.text = "돈: " + (orderSystem.intMoney / 10000) + "만원";
                    Order.text = "닭고기가 없습니다. 고기를 찾으세요";

                    Driver_Fried.SetActive(false);
                    OrderObj.SetActive(false);

                    chickenCS.ChickenStart(); // 치킨 재생성

                    hasChicken = 0;
                    buttonSystem.Seasoning = 0; //치킨 시즈닝 제거
                }
            }
            else
            {
                //Debug.Log("저 치킨 안 시켰는데요?");
            }
        }
    }
    private void Update()
    {
        if (hasChicken == 2 && Seasoning)
        {
            Driver_Chicken.SetActive(false);
            Driver_Fried.SetActive(true);
            Order.text = "배달을 시작하자!";
            Seasoning = false;
        }
    }
    void Order_Exit_Open_Click()
    {
        if (Open)
        {
            Orderanimator.SetTrigger("orderExit");
            Open = false;
        }
        else if(!Open)
        {
            Orderanimator.SetTrigger("orderOpen");
            Open = true;
        }
    }
}
