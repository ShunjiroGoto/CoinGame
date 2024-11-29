using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject coinPrefab;//このゲーム全体のGameObjectの変数coinPrefabを宣言
    public GameObject SupercoinPrefab;//同じくSuperCoinPrefabを宣言

    GameObject pointText1;//使用するゲームオブジェクトpointText1を宣言
    GameObject pointText2;//同じくpointText2を宣言

    int point = 0;//ポイントをカウントするための整数型の変数

    int supercoincount = 0;//5回に一回赤コインを出すための変数
    int supercoincountUI = 0;//赤コインが出るまでのカウントUI用の変数

    void Start()
    {
        this.pointText1 = GameObject.Find("Point");//pointText1をUI「Point」に指定
        this.pointText2 = GameObject.Find("SuperCoinUI");//同じくpointText2を「SuperCoinUI」に指定
    }

    //手動でコインを生成するコード
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//左クリック時に発動
        {
            Vector3 mousePosition = Input.mousePosition;// カーソル位置を取得
            mousePosition.z = 10;// カーソル位置のz座標を10に
            Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);// カーソル位置をワールド座標に変換
            Vector3 randomPos = new Vector3(target.x, transform.position.y, transform.position.z + 1);// GameObjectのtransform.positionにカーソル位置(ワールド座標)を代入

            if (target.x<4.6 & target.x>-4.6) //変換したワールド座標のX値が一定以内なら発動
            {
                ++supercoincount;//赤コインを出すための変数をカウント

                if (supercoincount > 4)//変数が５以上なら発動
                {
                    Instantiate(SupercoinPrefab, randomPos, Quaternion.identity);//赤コインを出す
                    supercoincount = 0;//変数を0に戻す
                }
                else
                {
                    Instantiate(coinPrefab, randomPos, Quaternion.identity);//黄コインを出す
                }
            }
        }
        this.pointText1.GetComponent<TextMeshProUGUI>().text =
            this.point.ToString() + "point";//ポイントをUIに反映

        supercoincountUI = 5 - supercoincount;//赤コインが出るまでのカウントUI用の変数
        this.pointText2.GetComponent<TextMeshProUGUI>().text =
           "Up to red "+this.supercoincountUI.ToString();//赤コインが出るまでのカウント
    }
    public void GetCoin(int a)//どのスクリプトからでも呼び出せるポイントを追加するメソッド(関数)
    {
        this.point += 1 * a;//呼び出す際に入力した整数型の数値aに応じてpointを追加
        Debug.Log(point);//ポイントの値をログで出す
    }


    public void RetryButtonDown()//シーンを読み込みなおすボタン
    {
        //Debug.Log("あ");
        SceneManager.LoadScene("SampleScene");
    }



    /*自動でコインを生成するコード
    void Start()
    {
        InvokeRepeating("CoinGeneration", 2, 1);//ゲーム開始2秒後から1秒ごとにCoinGeneration関数を呼び出す
    }

    void Update()
    {
    }
    private void CoinGeneration()//このスクリプトのみの関数CoinGeneration
    {
        
        Vector3 randomPos = new Vector3(Random.Range(-3, 3), transform.position.y, transform.position.z);

        Instantiate(coinPrefab, randomPos, Quaternion.identity);

    }*///coinPrefabをランダムな位置に生成


}

