using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGetter : MonoBehaviour
{
    GameObject director;//GameObject�Ƃ���director��錾


    void Start()
    {
        this.director = GameObject.Find("GameManager");//GameObject��GameDirector�Ƃ���
    }

    void OnCollisionEnter(Collision other)//���̃I�u�W�F�N�g�������������ɔ���
    {
        Destroy(other.gameObject);//���̃I�u�W�F�N�g������
        if (other.gameObject.tag == "SuperCoin")//���̃I�u�W�F�N�g�̃^�O��SuperCoin�̎��ɔ���
        {
            GetComponent<AudioSource>().Play();//AudioSource�R���|�[�l���g�ɐݒ肵�������Đ�
            this.director.GetComponent<GameManager>().GetCoin(200);//GetCoin���\�b�h�ɐ��l200�����čĐ�
        }
    }
}
