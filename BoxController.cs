using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private Rigidbody rb;//このスクリプトのみの物理エンジンRigidbodyの変数rb宣言
    private Vector3 startPos;//このスクリプトのみの位置ベクトルVector3の変数startPos宣言
    GameObject director;//GameObjectとしてdirectorを宣言

    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbodyコンポーネントを取得しrbに入れる
        startPos = transform.position;//startPosに位置と回転を表すクラスtransform.positionを入れる
        this.director = GameObject.Find("GameManager");//direcotrをGameManagerとする

    }

    void Update()//正弦定理に基づきZの位置を変える(コインを押す壁の応用、数値を変えて速さと距離を調整している)
    {
        rb.MovePosition(new Vector3(
            startPos.x + 3.5f * Mathf.Sin(Time.time * 1f),
            startPos.y,
            startPos.z
            )
            );
    }
    void OnCollisionEnter(Collision other)//オブジェクトがぶつかった瞬間に発動
    {
        Destroy(other.gameObject);//当たったオブジェクトを破壊する
        if (other.gameObject.tag == "SuperCoin")//そのオブジェクトのタグがSuperCoinなら発動
        {
            GetComponent<AudioSource>().Play();//AudioSourceコンポーネントに設定した音を再生
            GetComponent<ParticleSystem>().Play();//ParticleSystemコンポーネントに設定したエフェクトを再生
            //音の入れ方は教科書の車のゲーム、エフェクトはイガグリを参考に
            this.director.GetComponent<GameManager>().GetCoin(750);
            //director(GameManager)に設定したコンポーネントであるGameManagerスクリプトからGetCoinメソッドを呼び出し整数型の数値を入力
        }

    }
}