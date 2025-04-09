using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    public RectTransform rectTransform;        // UI 이미지
    public Transform followTarget;             // 따라갈 오브젝트 (플레이어 등)
    public Canvas canvas;                      // UI 캔버스 (필수!)
    public Vector2 offset = new Vector2(-137, 0); // 미니맵 내 위치 보정

    void Update()
    {
        // 1. 타겟의 월드 좌표 → 스크린 좌표
        Vector2 screenPos = Camera.main.WorldToScreenPoint(followTarget.position);

        // 2. 스크린 좌표 → 캔버스 로컬 좌표
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.GetComponent<RectTransform>(),
            screenPos,
            canvas.worldCamera,
            out Vector2 localPoint
        );

        // 3. 보정값 더해서 적용
        rectTransform.anchoredPosition = localPoint + offset;
    }
}
