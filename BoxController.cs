using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private Rigidbody rb;//���̃X�N���v�g�݂̂̕����G���W��Rigidbody�̕ϐ�rb�錾
    private Vector3 startPos;//���̃X�N���v�g�݂̂̈ʒu�x�N�g��Vector3�̕ϐ�startPos�錾
    GameObject director;//GameObject�Ƃ���director��錾

    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody�R���|�[�l���g���擾��rb�ɓ����
        startPos = transform.position;//startPos�Ɉʒu�Ɖ�]��\���N���Xtransform.position������
        this.director = GameObject.Find("GameManager");//direcotr��GameManager�Ƃ���

    }

    void Update()//�����藝�Ɋ�Â�Z�̈ʒu��ς���(�R�C���������ǂ̉��p�A���l��ς��đ����Ƌ����𒲐����Ă���)
    {
        rb.MovePosition(new Vector3(
            startPos.x + 3.5f * Mathf.Sin(Time.time * 1f),
            startPos.y,
            startPos.z
            )
            );
    }
    void OnCollisionEnter(Collision other)//�I�u�W�F�N�g���Ԃ������u�Ԃɔ���
    {
        Destroy(other.gameObject);//���������I�u�W�F�N�g��j�󂷂�
        if (other.gameObject.tag == "SuperCoin")//���̃I�u�W�F�N�g�̃^�O��SuperCoin�Ȃ甭��
        {
            GetComponent<AudioSource>().Play();//AudioSource�R���|�[�l���g�ɐݒ肵�������Đ�
            GetComponent<ParticleSystem>().Play();//ParticleSystem�R���|�[�l���g�ɐݒ肵���G�t�F�N�g���Đ�
            //���̓�����͋��ȏ��̎Ԃ̃Q�[���A�G�t�F�N�g�̓C�K�O�����Q�l��
            this.director.GetComponent<GameManager>().GetCoin(750);
            //director(GameManager)�ɐݒ肵���R���|�[�l���g�ł���GameManager�X�N���v�g����GetCoin���\�b�h���Ăяo�������^�̐��l�����
        }

    }
}