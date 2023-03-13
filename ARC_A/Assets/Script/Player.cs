using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AudioSource 컴포넌트가 같이 잡힘
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    public AudioClip jumpVc;
    public AudioClip damageVc;
    AudioSource _aud;

    // 통합적인 콜라이더 제거법
    Collider2D sCollider2D;


    // GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        _aud = GetComponent<AudioSource>();

        // 통합적인 콜라이더 제거법
        sCollider2D = GetComponent<Collider2D>();

        // 싱글패턴이 아닌 Find로 찾는 법
        // 메모리 비효율적인 방법이다
        //gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        ///////////////////////////////////////////////////////////////////
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Jump()
    {
        // audio 재생
        _aud.PlayOneShot(jumpVc);
    }

    void OnDamage()
    {
        // 부딪혔을때 박스콜라이더만 제거해서 밑으로 떨어짐
        GetComponent<BoxCollider2D>().enabled = false;

        // 통합적인 콜라이더 제거법
        //sCollider2D.enabled = false;


        // 중복 오디오 정지 후 재생
        _aud.Stop();
        _aud.PlayOneShot(damageVc);


        // 게임 상태 변경
        GameManager.instance.state = GameManager.STATE.GAMEOVER;

       
    }
}
