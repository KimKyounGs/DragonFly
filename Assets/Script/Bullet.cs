using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;
    public GameObject explosion;

    void Start()
    {
        
    }

    void Update()
    {
        // Y축 이동
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }
    void OnBecameInvisible()
    {
        // 화면 밖으로 나가면 미사일 지우기.
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 폭발 이펙트 생성
            Instantiate(explosion, transform.position, Quaternion.identity);
            //적지우기
            Destroy(collision.gameObject);
            //총알 지우기 자기자신
            Destroy(gameObject);
        }
    }
}
