using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator _ani;


    float speed      = 1.2f;
    float rotSpeed   = 300f;
    float inputV;
    float inputH;

    bool isRun = false;


    // Start is called before the first frame update
    void Start()
    {
        // 자신 안에 있는 Animator 참조
        _ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1 ~ 5 번을 눌러 애니메이션 모션 시작
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _ani.Play("WAIT01");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _ani.Play("WAIT02");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _ani.Play("WAIT03");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _ani.Play("WAIT04");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _ani.Play("WAIT00");
        }

        // 캐릭터 이동 함수
        MoveStart();
        
        // 왼쪽 쉬프트를 눌렀을 때 isRun 활성화 : 달리기 모션
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }

        // 스페이스바를 눌렀을 때 isJump 활성화 : 점프 모션
       if(Input.GetKeyDown(KeyCode.Space))
        {
            _ani.SetBool("isJump", true);
        }
        else
        {
            _ani.SetBool("isJump", false);
        }
       
       // 슬라이드 모션, 서브트랜지션 활용
       if(Input.GetKeyDown(KeyCode.K))
        {
            _ani.SetTrigger("slider");
        }

       // test 모션
       if(Input.GetKeyDown(KeyCode.T))
        {
            _ani.SetTrigger("test");
        }


    }



    // 캐릭터 이동 함수 정의
    void MoveStart()
    {
        if (isRun) speed = 3.0f;
        else speed = 1.2f;

        float move   = speed * Time.deltaTime;
        float rot    = rotSpeed * Time.deltaTime;

        inputV = Input.GetAxis("Vertical");
        inputH = Input.GetAxis("Horizontal");

        // 이동
        transform.Translate(Vector3.forward * move * inputV);
        // 회전 
        transform.Rotate(Vector3.up * rot * inputH);


        _ani.SetFloat("inputV", inputV);
        _ani.SetFloat("inputH", inputH);

        _ani.SetBool("isRun", isRun);
        

    }



}
