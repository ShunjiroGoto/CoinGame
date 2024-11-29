using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerationManager : MonoBehaviour
{
    public GameObject coinPrefab;//�Q�[���S�̂�GameObject�̕ϐ�coinPrefab��錾
    public GameObject supercoinPrefab;//������supercoinPrefab��錾
    private int coinCount = 0;//���̃X�N���v�g�݂̂�int�^�ϐ�coinCount��錾�������l��0�ɂ���

    void Update()
    {
        int coinrate = Random.Range(1, 6);//�ԃR�C�����o�����[�g�i1����6�܂ł̐����������_���œ����j
        if (coinCount < 200)//coinCount��200�����Ȃ甭��
        {
            if (coinrate == 1)//coinrate��1(6����1�̊m���Ŕ���)
            {
                Vector3 randomPos = new Vector3(Random.Range(-3f, 3f), Random.Range(2, 4), Random.Range(0, -2));//���W�̕ϐ�randomPos��錾���A�����_���ō��W������

                Instantiate(supercoinPrefab, randomPos, Quaternion.identity);//randomPos�Ɋ�Â��AsupercoinPrefab�𐶐�

            }
            else//6����5�ŉ��R�C�����o���X�N���v�g
            {
                Vector3 randomPos = new Vector3(Random.Range(-3f, 3f), Random.Range(2, 4), Random.Range(0, -4));

                Instantiate(coinPrefab, randomPos, Quaternion.identity);
            }

            coinCount++;//coinCount��ǉ�
        }
    }
}

