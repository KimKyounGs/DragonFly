using System.Security.Cryptography;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {
        // InvokeRepeating  같은 경우는 해당 게임 오브젝트가 액티브가 꺼지거나 없어져도 계속 돌기 때문에 InvokeRepeating을 직접 해제해야만 멈출수 있습니다. 
        InvokeRepeating("SpawnEnemy", 1, 0.5f);
    }

    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-2f, 2f); // 적이 나타날 x좌표를 랜덤으로 생성하기

        Instantiate(enemy, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);

        
    }
}
