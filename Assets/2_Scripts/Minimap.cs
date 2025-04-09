using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    public RectTransform rectTransform;        // UI �̹���
    public Transform followTarget;             // ���� ������Ʈ (�÷��̾� ��)
    public Canvas canvas;                      // UI ĵ���� (�ʼ�!)
    public Vector2 offset = new Vector2(-137, 0); // �̴ϸ� �� ��ġ ����

    void Update()
    {
        // 1. Ÿ���� ���� ��ǥ �� ��ũ�� ��ǥ
        Vector2 screenPos = Camera.main.WorldToScreenPoint(followTarget.position);

        // 2. ��ũ�� ��ǥ �� ĵ���� ���� ��ǥ
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.GetComponent<RectTransform>(),
            screenPos,
            canvas.worldCamera,
            out Vector2 localPoint
        );

        // 3. ������ ���ؼ� ����
        rectTransform.anchoredPosition = localPoint + offset;
    }
}
