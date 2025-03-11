using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // 싱글톤 
    // 어디에서나 접근 할수 있도록 static(정적)으로 자기자신을 저장함
    public static GameManager instance;
    public Text scoreText; // 점수 표시 텍스트
    public Text startText; // 게임 시작 전(3,2,1) 텍스트
    public Text gameOverText; // 게임 오버 되었을 때 나오는 텍스트
    public List<Image> lifeImage; // 남은 목숨 이미지
    private int score;
    private int life = 3;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 0f; // 게임 일시 정지
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        int i = 3;
        yield return new WaitForSecondsRealtime(0.5f);
        while(i>0)
        {
            startText.text = i.ToString();

            yield return new WaitForSecondsRealtime(1f);
            i--;
            if (i == 0)
            {
                startText.gameObject.SetActive(false);
            }
        }

        Time.timeScale = 1f; // 게임 진행
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score : " + score; 
    }

    public void UpdateLife(bool flag)
    {
        if (flag) life ++; // 생명 플러스
        else life --; // 생명 마이너스

        for (int i = 0; i < 3; i ++)
        {
            lifeImage[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < life; i ++)
        {
            lifeImage[i].gameObject.SetActive(true);
        }

        if (life <= 0)
        {
            GameLose();
        }

    }

    public void GameLose()
    {
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
