using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딪힌게 플레이어가 맞다면
        // GameManager안의 AddScore() 실행
        if(collision.tag == "Player")
        {
            GameManager.instance.AddScore();
            GetComponent<Collider2D>().enabled = false;
            GetComponent<AudioSource>().Play();

            // 오디오 소스안에 있는 오디오파일 길이만큼
            Destroy(this.gameObject, GetComponent<AudioSource>().clip.length);
            
        }
    }

}
