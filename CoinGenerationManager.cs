using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerationManager : MonoBehaviour
{
    public GameObject coinPrefab;//ゲーム全体のGameObjectの変数coinPrefabを宣言
    public GameObject supercoinPrefab;//同じくsupercoinPrefabを宣言
    private int coinCount = 0;//このスクリプトのみのint型変数coinCountを宣言し初期値を0にする

    void Update()
    {
        int coinrate = Random.Range(1, 6);//赤コインを出すレート（1から6までの整数をランダムで入れる）
        if (coinCount < 200)//coinCountが200未満なら発動
        {
            if (coinrate == 1)//coinrateが1(6分の1の確率で発動)
            {
                Vector3 randomPos = new Vector3(Random.Range(-3f, 3f), Random.Range(2, 4), Random.Range(0, -2));//座標の変数randomPosを宣言し、ランダムで座標を入れる

                Instantiate(supercoinPrefab, randomPos, Quaternion.identity);//randomPosに基づき、supercoinPrefabを生成

            }
            else//6分の5で黄コインを出すスクリプト
            {
                Vector3 randomPos = new Vector3(Random.Range(-3f, 3f), Random.Range(2, 4), Random.Range(0, -4));

                Instantiate(coinPrefab, randomPos, Quaternion.identity);
            }

            coinCount++;//coinCountを追加
        }
    }
}

