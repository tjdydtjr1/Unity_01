using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform ast; // 운석 프리팹
    public bool isSpawn = false;

    // 파티클
    public Transform expHit;        // 히트 파티클
    public Transform expDestroy;    // 폭파 파티클

    // GameManager에 다 접근할 수 있게 싱글턴 패턴
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // 싱글턴 패턴

    public int score = 0;
    public int hp;

    // UI
    public Button restartBtn;
    public Text hpText;
    public Text scoreText;
    
    // UI Button 제어
    public bool isFire = false;
    bool isRight = false;
    bool isLeft = false;

    // 게임 종료 메시지
    public GameObject quitImg;

    // 전투기 방향 조작
    public Transform wing;

    // Start is called before the first frame update
    void Start()
    {
        // 게임 종료 메시지 비활성화
        quitImg.SetActive(false);

        // 재시작 버튼 비활성화로 시작
        restartBtn.gameObject.SetActive(false);

        hpText.text         = "HP:" + hp;
        scoreText.text      = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        MakeAst();
        MoveM();

        // 특정 플랫폼 검사
        if(Application.platform == RuntimePlatform.Android)
        {

        }

        //if(Input.GetKeyDown(KeyCode.Home))
        //if (Input.GetKeyDown(KeyCode.Backspace))
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitImg.SetActive(true);
        }




    }

    // 운석 생성 (랜덤 확률)
    void MakeAst()
    {
        // 랜덤 값을 통해 일정 이상 수 에서만 생성
        if( Random.Range(0, 1000) > 980)
        {
            StartCoroutine(MakeAstroid());   // 코루틴 운석 프리팹 생성
        }
    }

    IEnumerator MakeAstroid()
    {
        if(!isSpawn)
        {
            isSpawn = true;
            Instantiate(ast);
            yield return new WaitForSeconds(Random.Range(0 , 3)); // 0 ~ 2의 랜덤

            isSpawn = false;

        }
    }


    // 재시작버튼과 연결되는 함수

    public void Restart()
    {
        // 동기화 방식 Scene 호출
        SceneManager.LoadScene("Main");
    }

    
    
    /*  ===================================================================
     *                              모바일 조작
     *  ===================================================================
     */
    // UI FireButton 조작
    public void FireStart()
    {
        isFire = true;
    }

    public void FireStop()
    {
        isFire = false;
    }

    // 모바일용 이동함수
    void MoveM()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(wing.position);
        
        // 스크린 왼쪽 막기
        if(isLeft && pos.x > Screen.width * 0.08)
        {
            Vector3 dir = Vector3.zero;
            dir.x = -20;

            wing.transform.Translate(dir * Time.deltaTime);
        }

        // 스크린 오른쪽 막기
        if(isRight && pos.x < Screen.width - Screen.width * 0.08)
        {
            Vector3 dir = Vector3.zero;
            dir.x = 20;

            wing.transform.Translate(dir * Time.deltaTime);
        }
        
    }

    // 이동 버튼 조작 함수
    public void RightBtn()
    {
        isRight = true;
    }

    public void LeftBtn()
    {
        isLeft = true;
    }

    public void MoveStop()
    {
        isRight = false;
        isLeft = false;
    }

    // 종료 메시지 박스
    public void Quit()
    {
        Application.Quit();
        Debug.Log("종료");
    }
    public void Cancle()
    {
        quitImg.SetActive(false);
        Debug.Log("취소");
    }

    public void QuitBtn()
    {
        quitImg.SetActive(true);
    }
}
