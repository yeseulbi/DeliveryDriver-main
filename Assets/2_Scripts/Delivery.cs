using UnityEngine;
using UnityEngine.UI;

public class Delivery : MonoBehaviour
{
    public Chicken chickenCS;
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] Color noChickenColor = new Color(1, 1, 1, 1);
    [SerializeField] Color hasChickenColor = new Color(1, 0.3884149f, 0, 1);

    public static int hasChicken = 0; //0.기본 1.닭고기 보유 2.치킨 보유
    bool Seasoning = false;

    [SerializeField] Text Order;
    [SerializeField] Text Money;
    [SerializeField] GameObject akfvndtjs;
    [SerializeField] GameObject[] mistake_akfvndtjs; // 각 Customer 마다 다르게 수정
    [SerializeField] GameObject OrderObj;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        akfvndtjsSetActive();
        OrderObj.SetActive(false);
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
            orderSystem.CanOrder = true;
            OrderObj.SetActive(true);
            Debug.Log("치킨 픽업됨");
            Order.text = "닭고기 획득! 오더에 맞게 조리하자";
            hasChicken = 1;
            Seasoning = true;
            Destroy(collision.gameObject, delayTime);
            spriteRenderer.color = hasChickenColor;
        }

        if (collision.gameObject.CompareTag("Store") && hasChicken == 0) // 닭고기가 없는 데 말 걸었을 때
        {
            akfvndtjs.SetActive(true);
            Invoke(nameof(akfvndtjsSetActive), 2f);
        }

        if(orderSystem.Instance.CustomerName == collision.gameObject.name)
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
                OrderObj.SetActive(false);
                Debug.Log("치킨 배달됨");
                Order.text = "닭고기가 없습니다. 고기를 획득하세요";
                chickenCS.ChickenStart();
                hasChicken = 0;
                buttonSystem.Seasoning = 0; //치킨 시즈닝 제거
                spriteRenderer.color = noChickenColor;
            }
        }
        else
        {
            Debug.Log("제가 안시켰는데요?");
        }
    }
    private void Update()
    {
        if (hasChicken == 2 && Seasoning)
        {
            Order.text = "배달을 시작하자!";
            Seasoning = false;
        }
    }
}
