using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public enum STATE
    {
        NONE = 0,
        START,
        PLAY,
        GAMEOVER
    }
    // 상태값체크는 기본
    public STATE state = STATE.NONE;    // 현재 게임 상태 초기화

    // UI를 쓰려면 UI 헤더 넣기
    // 게임 상태 메시지 띄우기
    public Text msgText;
    public Text scoreText;

    public int score;


    // 캐릭터 위치값을 위한
    public Transform player;









    // 싱글패턴 =================================================
    // GameManager를 접근할 수 있게 됨
    public static GameManager instance;
    
    private void Awake()
    {
        instance = this;
        player.gameObject.SetActive(false); // 캐릭터 비활성
    }
    // ========================================================== 
    
    





    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(StartCnt());
        //Cnt_3();
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case STATE.START:
                {
                    break;
                }
            case STATE.PLAY:
                {
                    scoreText.text = "SCORE : " + score.ToString("000");
                    break;
                }
            case STATE.GAMEOVER:
                {
                    msgText.text = "GAME OVER\nPress Space : ReStart";
                    if(Input.GetKeyDown(KeyCode.Space))
                    {
                        SceneManager.LoadScene("SampleScene");
                    }
                    break;
                }
        }


    }

    
    // ========================================================================
    // 코루틴 방식과 Invoke 방식 구현 방법의 차이

    // 코루틴 : 시간제어
    IEnumerator StartCnt()
    {
        msgText.text = "3";
        yield return new WaitForSeconds(1.0f);
        msgText.text = "2";
        yield return new WaitForSeconds(1.0f);
        msgText.text = "1";
        yield return new WaitForSeconds(1.0f);
        msgText.text = "";
        
        player.gameObject.SetActive(true); // 활성
        state = STATE.PLAY;
             
    }


    // Invoke 방식
    void Cnt_3()
    {
        msgText.text = "3";
        Invoke("Cnt_2", 1);
    }

    void Cnt_2()
    {
        msgText.text = "2";
        Invoke("Cnt_1", 1);
    }
    void Cnt_1()
    {
        msgText.text = "1";
        Invoke("Cnt_End", 1);
    }

    void Cnt_End()
    {
        msgText.text = "";
        player.gameObject.SetActive(true); // 활성
        state = STATE.PLAY;
    }

    // ========================================================================


    public void AddScore()
    {
        ++score;
    }





}
