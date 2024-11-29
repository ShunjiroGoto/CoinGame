using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherManager : MonoBehaviour
{
    private Rigidbody rb;//このスクリプトのみの物理エンジンRigidbodyの変数rb宣言
    private Vector3 startPos;//このスクリプトのみの位置ベクトルVector3の変数startPos宣言

    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbodyコンポーネントを取得しrbに入れる
        startPos = transform.position;//startPosに位置と回転を表すクラスtransform.positionを入れる
    }

    void Update()
    {
        rb.MovePosition(new Vector3(
            startPos.x,
            startPos.y,
            startPos.z + 1.5f*Mathf.Sin(Time.time * 1.5f)
            )
            );//正弦定理に基づきZの位置を変える
    }
}