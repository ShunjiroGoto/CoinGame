using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherManager : MonoBehaviour
{
    private Rigidbody rb;//���̃X�N���v�g�݂̂̕����G���W��Rigidbody�̕ϐ�rb�錾
    private Vector3 startPos;//���̃X�N���v�g�݂̂̈ʒu�x�N�g��Vector3�̕ϐ�startPos�錾

    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody�R���|�[�l���g���擾��rb�ɓ����
        startPos = transform.position;//startPos�Ɉʒu�Ɖ�]��\���N���Xtransform.position������
    }

    void Update()
    {
        rb.MovePosition(new Vector3(
            startPos.x,
            startPos.y,
            startPos.z + 1.5f*Mathf.Sin(Time.time * 1.5f)
            )
            );//�����藝�Ɋ�Â�Z�̈ʒu��ς���
    }
}