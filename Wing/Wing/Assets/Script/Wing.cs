using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing : MonoBehaviour
{
    public int speed = 40;
    public Transform missile; // 미사일 프리팹
    public Transform posR;    // 미사일 생성위치
    public Transform posL;    // 미사일 생성위치


    // 코루틴 제어 플래그
    bool isFire = true;


    // 오디오 클래스
    AudioSource _aud;

    

    
    // 화면상의 길이 값을 실시간으로 받아주는 함수 Screen
    float fw = Screen.width * 0.08f;    // 가로
    float fh = Screen.height * 0.08f;   // 세로


    // Start is called before the first frame update
    void Start()
    {
        // 자신 안에 있는 AudioSource 참조
        _aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 비행기 이동 함수 호출
        //MoveWing();     // PC 용
        //FireStart();    // PC 용
        //Fire1();
        ShootMissileStart();    // 모바일용 Fire
    }

    // 비행기 이동 함수
    void  MoveWing()
    {
        float move = speed * Time.deltaTime;
        float keyF = Input.GetAxis("Vertical");
        float keyS = Input.GetAxis("Horizontal");
        

        //transform.Translate(Vector3.forward * move * keyF);
        //transform.Translate(Vector3.right * move * keyS);
        // 위의 2줄을 아래 한줄로 단, new를 사용 시 새롭게 만들기에 메모리를 많이 사용
        //transform.Translate(new Vector3(keyS, 0, keyF) * move);


        {              
            // 카메라안의 메인 worldToScreenPoint 메인 카메라에서 지정된 오브젝트 위치
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            
            // 조건에 맞게 끔 좌 우 이동 제한
            if( (keyS < 0 && pos.x > fw) || (keyS > 0 && (pos.x < Screen.width - fw)))
            {
                transform.Translate(Vector3.right * move * keyS);
            }
            // 조건에 맞게 끔 상하 이동 제한
            if ((keyF < 0 && pos.y > fh) || (keyF > 0 && (pos.y < Screen.height - fh)))
            {
                transform.Translate(Vector3.forward * move * keyF);
            }
        }
    }

    void FireStart()
    {
        
        if(Input.GetButton("Fire1") && isFire)
        {
            StartCoroutine(MakeMissle());
          
        }
    }

    IEnumerator MakeMissle()
    {
        isFire = false;
        // 미사일 생성
        Transform tr_1 = Instantiate(missile, posR.position, posR.rotation);
        Transform tr_2 = Instantiate(missile, posL.position, posL.rotation);
        tr_1.GetComponent<Rigidbody>().velocity = Vector3.forward * 30;
        tr_2.GetComponent<Rigidbody>().velocity = Vector3.forward * 30;

        yield return new WaitForSeconds(0.1f);

        isFire = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AST")
        {
            other.GetComponent<Ast>().hp = 0;
            other.GetComponent<Ast>().Hit();

            GameManager.instance.hp--;
            
            if(GameManager.instance.hp <= 0)
            {
                //Destroy(this.gameObject);
                transform.position = new Vector3(0, 0, -500);

                GameManager.instance.hp = 0; // -이 표시됨을 방지

                // 오디오 플레이
                _aud.Play();

                // 재시작 버튼 활성화
                GameManager.instance.restartBtn.gameObject.SetActive(true);

                
            }

            GameManager.instance.hpText.text = "HP:" + (GameManager.instance.hp);
        }
    }


    // Mobile 용
    void ShootMissileStart()
    {
        if(GameManager.instance.isFire && this.isFire)
        {
            StartCoroutine(MakeMissle());
        }
    }

   
}
