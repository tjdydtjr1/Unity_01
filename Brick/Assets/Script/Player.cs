using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 초속 10미터
    int speed = 10; 
    // 초속 120도
    int rotSpeed = 120;

    // public -> 직렬화
    // 눈에 보이는 모든것은 GameObject 사용
    public GameObject bullet;
    // 총알 발사 속도
    public float bulletSpeed = 50;

    // 위치에 관한것
    public Transform spPoint;
    
    // 코루틴 제어 플래그
    bool isFire = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UserMove();     // 이동 함수 호출
        //UserFire();     // 총알 생성 함수 호출

        /* 버튼 입력시 동작 방법
         * 
        // 누르고 있는 동안 계속 GetButton
        if(Input.GetButton("Fire1"))
        {
            Debug.Log("동작");
        }
        // 누르고 떼어질 때 동작 GetButtonUp
        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("동작");
        }
        // 누를 시 동작 GetButtonDown
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("동작");
        }
        *
        */
        if(Input.GetButton("Fire1"))
        {
            // 일반 함수 호출 방식
            //UserFire();
            
            // 코루틴 함수 호출 방식
            StartCoroutine(FireStart());      // 코루틴 함수 호출 (시작점)
            //StopCoroutine(FireStart());     // 코루틴 함수 정지 함수호출방식으로는 멈추지 않음
            // 코루틴 문자열 호출 방식
            //StartCoroutine("FireStart");
            //StopCoroutine("FireStart");     // 코루틴 함수 정지는 문자열 방식으로 호출할 것

        }

    }

    // 이동 함수 정의
    void UserMove()
    {
        // Time.deltaTime : 현재 시간
        float move  = speed * Time.deltaTime;
        float rot   = rotSpeed * Time.deltaTime;


        // 좌우 동작
        float keyS = Input.GetAxis("Horizontal");
        // 상하 동작
        float keyF = Input.GetAxis("Vertical");

        // Unity 이동 함수 호출
        this.transform.Translate(Vector3.forward * move * keyF);
        
        // Unity 회전 함수 호출
        this.transform.Rotate(Vector3.down * rot * keyS);

    }

    // 총알 생성 함수
    void UserFire()
    {
        // 유니티 생성 함수 호출
        // 인스턴스 (객체, 위치, 회전)
        GameObject obj = Instantiate(bullet, spPoint.position, spPoint.rotation);
        
        obj.GetComponent<Rigidbody>().velocity = spPoint.forward * bulletSpeed;

       
    }

    // 코루틴 함수 정의
    
    IEnumerator FireStart()
    {
        // 코루틴 기본 로직
        if(!isFire)
        {
            isFire = true;
            UserFire();
            yield return new WaitForSeconds(0.1f);
            isFire = false;

        }

        //yield return new WaitForEndOfFrame();      // 프레임단위(약 0.02초) 마다 수행
        //yield return new WaitForFixedUpdate();     // 프레임단위(정확한 0.02초) 마다 수행
        //yield return new WaitForSeconds(0.1f);        // 지정한 시간 마다 수행

    }



}
