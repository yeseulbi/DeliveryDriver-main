using UnityEngine;
using UnityEngine.UI;

public class Delivery : MonoBehaviour
{
    public Chicken chickenCS;
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] Color noChickenColor = new Color(1, 1, 1, 1);
    [SerializeField] Color hasChickenColor = new Color(1, 0.3884149f, 0, 1);

    public static int hasChicken = 0; //0.�⺻ 1.�߰�� ���� 2.ġŲ ����
    bool Seasoning = false;

    [SerializeField] Text Order;
    [SerializeField] Text Money;
    [SerializeField] GameObject akfvndtjs;
    [SerializeField] GameObject[] mistake_akfvndtjs; // �� Customer ���� �ٸ��� ����
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
        if (collision.gameObject.CompareTag("Chicken") && hasChicken == 0) // ġŲ �Ծ��� ��
        {
            orderSystem.CanOrder = true;
            OrderObj.SetActive(true);
            Debug.Log("ġŲ �Ⱦ���");
            Order.text = "�߰�� ȹ��! ������ �°� ��������";
            hasChicken = 1;
            Seasoning = true;
            Destroy(collision.gameObject, delayTime);
            spriteRenderer.color = hasChickenColor;
        }

        if (collision.gameObject.CompareTag("Store") && hasChicken == 0) // �߰�Ⱑ ���� �� �� �ɾ��� ��
        {
            akfvndtjs.SetActive(true);
            Invoke(nameof(akfvndtjsSetActive), 2f);
        }

        if(orderSystem.Instance.CustomerName == collision.gameObject.name)
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
                OrderObj.SetActive(false);
                Debug.Log("ġŲ ��޵�");
                Order.text = "�߰�Ⱑ �����ϴ�. ��⸦ ȹ���ϼ���";
                chickenCS.ChickenStart();
                hasChicken = 0;
                buttonSystem.Seasoning = 0; //ġŲ ����� ����
                spriteRenderer.color = noChickenColor;
            }
        }
        else
        {
            Debug.Log("���� �Ƚ��״µ���?");
        }
    }
    private void Update()
    {
        if (hasChicken == 2 && Seasoning)
        {
            Order.text = "����� ��������!";
            Seasoning = false;
        }
    }
}
