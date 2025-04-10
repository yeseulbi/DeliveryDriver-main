using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    [SerializeField] Transform follow;  // ���� ������Ʈ (�÷��̾�)
    [SerializeField] Transform[] target;  // Ÿ�� ������Ʈ
    [SerializeField] float radius = 1.5f; // ���� �Ÿ�
    [SerializeField] float heightOffset = 0f; // y�� ������


    SpriteRenderer sr;
    [SerializeField] float transparentTime = 2f; // ���������� �ð�

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void MakeTransparent()
    {
        Color color = sr.color;
        color.a = 0f;
        sr.color = color;
    }

    public void MakeVisible()
    {
        Color color = sr.color;
        color.a = 1f;
        sr.color = color;
    }

    public void MakeTransparentForSeconds()
    {
        StartCoroutine(TransparentThenShow());
    }

    IEnumerator TransparentThenShow()
    {
        MakeTransparent();
        yield return new WaitForSeconds(transparentTime);
        MakeVisible();
    }
    void Update()
    {
        if (follow == null || target == null || orderSystem.Instance == null) return;

        int customerIndex = orderSystem.Instance.Customer;

        if (customerIndex < 0 || customerIndex >= target.Length || target[customerIndex] == null)
            return;
        // ���� ����
        Vector2 dir = (target[customerIndex].position - follow.position).normalized;

        // ��ġ ���� (����)
        Vector3 offset = new Vector3(dir.x, dir.y, 0) * radius;
        transform.position = follow.position + offset + new Vector3(0, heightOffset, 0);

        // ȸ�� ���� (Sprite�� ���� ���ϵ��� �ϰ� ������ +90��)
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
    }
    private void LateUpdate()
    {
        if (Delivery.hasChicken > 0)
            GetComponent<Arrow>().MakeVisible();
        else GetComponent<Arrow>().MakeTransparent();
    }
}
