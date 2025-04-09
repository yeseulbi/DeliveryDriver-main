using UnityEngine;

public class Drift_Sub : MonoBehaviour
{
    public Transform leader;         // 선두 오브젝트 (예: Player)
    public float followDistance = 1f; // 얼마나 뒤에 따라갈지
    public float moveSpeed = 5f;

    private Vector2 lastLeaderPos;

    void Start()
    {
        if (leader != null)
            lastLeaderPos = leader.position;
    }

    void Update()
    {
        if (leader == null) return;

        // 현재 이동 방향 계산
        Vector2 currentLeaderPos = leader.position;
        Vector2 moveDir = ((Vector2)currentLeaderPos - lastLeaderPos).normalized;

        // 목표 위치 = 리더의 위치 - 이동방향 * 거리
        Vector2 targetPos = (Vector2)leader.position - moveDir * followDistance;

        // 부드럽게 이동 (선택)
        transform.position = Vector2.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // 현재 위치 저장
        lastLeaderPos = currentLeaderPos;
    }
}