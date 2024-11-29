using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject coinPrefab;//���̃Q�[���S�̂�GameObject�̕ϐ�coinPrefab��錾
    public GameObject SupercoinPrefab;//������SuperCoinPrefab��錾

    GameObject pointText1;//�g�p����Q�[���I�u�W�F�N�gpointText1��錾
    GameObject pointText2;//������pointText2��錾

    int point = 0;//�|�C���g���J�E���g���邽�߂̐����^�̕ϐ�

    int supercoincount = 0;//5��Ɉ��ԃR�C�����o�����߂̕ϐ�
    int supercoincountUI = 0;//�ԃR�C�����o��܂ł̃J�E���gUI�p�̕ϐ�

    void Start()
    {
        this.pointText1 = GameObject.Find("Point");//pointText1��UI�uPoint�v�Ɏw��
        this.pointText2 = GameObject.Find("SuperCoinUI");//������pointText2���uSuperCoinUI�v�Ɏw��
    }

    //�蓮�ŃR�C���𐶐�����R�[�h
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//���N���b�N���ɔ���
        {
            Vector3 mousePosition = Input.mousePosition;// �J�[�\���ʒu���擾
            mousePosition.z = 10;// �J�[�\���ʒu��z���W��10��
            Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);// �J�[�\���ʒu�����[���h���W�ɕϊ�
            Vector3 randomPos = new Vector3(target.x, transform.position.y, transform.position.z + 1);// GameObject��transform.position�ɃJ�[�\���ʒu(���[���h���W)����

            if (target.x<4.6 & target.x>-4.6) //�ϊ��������[���h���W��X�l�����ȓ��Ȃ甭��
            {
                ++supercoincount;//�ԃR�C�����o�����߂̕ϐ����J�E���g

                if (supercoincount > 4)//�ϐ����T�ȏ�Ȃ甭��
                {
                    Instantiate(SupercoinPrefab, randomPos, Quaternion.identity);//�ԃR�C�����o��
                    supercoincount = 0;//�ϐ���0�ɖ߂�
                }
                else
                {
                    Instantiate(coinPrefab, randomPos, Quaternion.identity);//���R�C�����o��
                }
            }
        }
        this.pointText1.GetComponent<TextMeshProUGUI>().text =
            this.point.ToString() + "point";//�|�C���g��UI�ɔ��f

        supercoincountUI = 5 - supercoincount;//�ԃR�C�����o��܂ł̃J�E���gUI�p�̕ϐ�
        this.pointText2.GetComponent<TextMeshProUGUI>().text =
           "Up to red "+this.supercoincountUI.ToString();//�ԃR�C�����o��܂ł̃J�E���g
    }
    public void GetCoin(int a)//�ǂ̃X�N���v�g����ł��Ăяo����|�C���g��ǉ����郁�\�b�h(�֐�)
    {
        this.point += 1 * a;//�Ăяo���ۂɓ��͂��������^�̐��la�ɉ�����point��ǉ�
        Debug.Log(point);//�|�C���g�̒l�����O�ŏo��
    }


    public void RetryButtonDown()//�V�[����ǂݍ��݂Ȃ����{�^��
    {
        //Debug.Log("��");
        SceneManager.LoadScene("SampleScene");
    }



    /*�����ŃR�C���𐶐�����R�[�h
    void Start()
    {
        InvokeRepeating("CoinGeneration", 2, 1);//�Q�[���J�n2�b�ォ��1�b���Ƃ�CoinGeneration�֐����Ăяo��
    }

    void Update()
    {
    }
    private void CoinGeneration()//���̃X�N���v�g�݂̂̊֐�CoinGeneration
    {
        
        Vector3 randomPos = new Vector3(Random.Range(-3, 3), transform.position.y, transform.position.z);

        Instantiate(coinPrefab, randomPos, Quaternion.identity);

    }*///coinPrefab�������_���Ȉʒu�ɐ���


}

