using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Delivery : MonoBehaviour
{

    public static int hasChicken = 0; //0.�⺻ 1.�߰�� ���� 2.ġŲ ����
    bool Seasoning = false;
    bool Open;

    [SerializeField] Text Order;
    [SerializeField] Text Money;
    [SerializeField] GameObject akfvndtjs;
    [SerializeField] GameObject[] mistake_akfvndtjs; // �� Customer ���� �ٸ��� ����
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
        if (collision.gameObject.CompareTag("Chicken") && hasChicken == 0) // ġŲ �Ծ��� ��
        {
            Order.text = "�߰�� ȹ��! ������ �°� ��������";
            
            orderSystem.CanOrder = true;
            Open=true;
            Seasoning = true;
            hasChicken = 1;

            Driver_Chicken.SetActive(true);
            OrderObj.SetActive(true);
            
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Store") && hasChicken == 0) // �߰�Ⱑ ���� �� �� �ɾ��� ��
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
                    if (orderSystem.Instance.a != buttonSystem.Seasoning) // �ֹ��� ġŲ ������ �ٸ� �� �߻�
                    {
                        mistake_akfvndtjs[orderSystem.Instance.Customer].SetActive(true);
                        Debug.Log("�� �� �����Դ�...");
                        Invoke("mistake_akfvndtjsSetActive", 2f);
                    }
                    else
                        orderSystem.intMoney += orderSystem.Instance.b;
                    Money.text = "��: " + (orderSystem.intMoney / 10000) + "����";
                    Order.text = "�߰�Ⱑ �����ϴ�. ��⸦ ã������";

                    Driver_Fried.SetActive(false);
                    OrderObj.SetActive(false);

                    chickenCS.ChickenStart(); // ġŲ �����

                    hasChicken = 0;
                    buttonSystem.Seasoning = 0; //ġŲ ����� ����
                }
            }
            else
            {
                //Debug.Log("�� ġŲ �� ���״µ���?");
            }
        }
    }
    private void Update()
    {
        if (hasChicken == 2 && Seasoning)
        {
            Driver_Chicken.SetActive(false);
            Driver_Fried.SetActive(true);
            Order.text = "����� ��������!";
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
