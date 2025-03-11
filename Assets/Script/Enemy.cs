using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 움직일 속도 지정
    public float moveSpeed = 1.3f;

    void Start()
    {
        
    }

    void Update()
    {
        // 움직일 거리를 계산해준다.
        float distanceY = moveSpeed * Time.deltaTime;

        // 움직임을 반영
        transform.Translate(0, -distanceY, 0);
    }

    // 화면 밖으로 나가 카메라에서 보이지 않으면 호출되는 함수
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.UpdateLife(false);
            Destroy(gameObject);
        }
    }
}
