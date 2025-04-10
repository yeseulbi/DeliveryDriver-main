using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    [SerializeField] Transform follow;  // 기준 오브젝트 (플레이어)
    [SerializeField] Transform[] target;  // 타겟 오브젝트
    [SerializeField] float radius = 1.5f; // 원형 거리
    [SerializeField] float heightOffset = 0f; // y축 오프셋


    SpriteRenderer sr;
    [SerializeField] float transparentTime = 2f; // 투명해지는 시간

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
        // 방향 벡터
        Vector2 dir = (target[customerIndex].position - follow.position).normalized;

        // 위치 설정 (원형)
        Vector3 offset = new Vector3(dir.x, dir.y, 0) * radius;
        transform.position = follow.position + offset + new Vector3(0, heightOffset, 0);

        // 회전 보정 (Sprite가 위를 향하도록 하고 싶으면 +90도)
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
