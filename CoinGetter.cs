using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGetter : MonoBehaviour
{
    GameObject director;//GameObjectとしてdirectorを宣言


    void Start()
    {
        this.director = GameObject.Find("GameManager");//GameObjectをGameDirectorとする
    }

    void OnCollisionEnter(Collision other)//他のオブジェクトが当たった時に発動
    {
        Destroy(other.gameObject);//他のオブジェクトを消す
        if (other.gameObject.tag == "SuperCoin")//そのオブジェクトのタグがSuperCoinの時に発動
        {
            GetComponent<AudioSource>().Play();//AudioSourceコンポーネントに設定した音を再生
            this.director.GetComponent<GameManager>().GetCoin(200);//GetCoinメソッドに数値200を入れて再生
        }
    }
}
