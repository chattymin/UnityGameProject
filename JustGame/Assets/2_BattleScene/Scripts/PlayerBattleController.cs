using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBattleController : MonoBehaviour {
    public GameObject selectAttack; //�÷��̾
    public GameObject selectDefense; //������ �ൿ��
    public GameObject selectRecovery; //�̹�����.


    public TextMeshProUGUI attackValueText;
    public TextMeshProUGUI defenseValueText;
    public TextMeshProUGUI recoveryValueText;

    public int maxValue; //�ൿ���� �ִ밪.
    public string playerSelected; //�÷��̾ ������ �ൿ ���� ��ȯ.

    public const string BATTLEST = "BattleST";


    public void Start() { //�⺻ ��� (��� ��Ȱ��ȭ)
        selectAttack.SetActive(false); //�ൿ �̹���
        selectDefense.SetActive(false); //���!!!
        selectRecovery.SetActive(false); //���� ����.

        attackValueText.text = "";
        defenseValueText.text = "";
        recoveryValueText.text = "";

        playerSelected = GameObject.Find("ActionManager") //�ൿ ������
            .GetComponent<ActionSelectController>().Action;
    }

    
    public void ActionSelectRun() { //Ȯ�� ��ư�� ������ �� �޴��� �������� 
        Start();                    //�ൿ ������ ���� �޼ҵ� ����
        if (playerSelected == "Attack") { //������ ������ ���
            SelectAttackImg(); //���� �̹��� ǥ��
            ShowAttackValue(); //���� �ൿ�� ǥ��
            StateSetting.SetStates(BATTLEST);
        }
        else if (playerSelected == "Defense") { //�� ������ ���
            SelectDefenseImg(); //��� �̹��� ǥ��
            ShowDefenseValue(); //��� �ൿ�� ǥ��
            StateSetting.SetStates(BATTLEST);
        }
        else if (playerSelected == "Recovery") { //ȸ���� ������ ���
            SelectRecoveryImg(); //ȸ�� �̹��� ǥ��
            ShowRecoveryValue(); //ȸ�� �ൿ�� ǥ��
            StateSetting.SetStates(BATTLEST);
        }
    }


    public void SelectAttackImg() { //���� �̹��� ǥ��
        selectAttack.SetActive(true); //�̹��� ǥ��
        selectDefense.SetActive(false);
        selectRecovery.SetActive(false);
    }

    public void SelectAttackVal() { //��� ���� �� ���ϱ�
        int attack = PlayerSetting.attackLV; //��� �ɷ�ġ �ҷ����
        maxValue = attack * 2; //�ִ밪� ��� ������ 2��
        int attackValue = Random.Range(attack, maxValue + 1); //����
        attackValueText.text = attackValue.ToString(); //��ݰ�� ���ڿ��� ��ȯ
    }
    public void ShowAttackValue() { //��� �ൿ�� ǥ��
        SelectAttackVal();
        defenseValueText.text = "";
        recoveryValueText.text = "";
    }


    public void SelectDefenseImg() { //��� �̹��� ǥ��
        selectAttack.SetActive(false);
        selectDefense.SetActive(true); //�̹��� ǥ��
        selectRecovery.SetActive(false);
    }

    public void SelectDefenseVal() { //��� ���� �� ���ϱ�
        int defense = PlayerSetting.defenseLV; //��� �ɷ�ġ �ҷ����
        maxValue = defense * 2; //�ִ밪� ��� ������ 2��
        int defenseValue = Random.Range(defense, maxValue + 1); //����
        defenseValueText.text = defenseValue.ToString(); //��� ���ڿ��� ��ȯ
    }
    public void ShowDefenseValue() { //��� �ൿ�� ǥ��
        attackValueText.text = "";
        SelectDefenseVal();
        recoveryValueText.text = "";
    }


    public void SelectRecoveryImg() { //ȸ�� �̹��� ǥ��
        selectAttack.SetActive(false); 
        selectDefense.SetActive(false);
        selectRecovery.SetActive(true); //�̹��� ǥ��
    }
  
    public void SelectRecoveryVal() { //ȸ�� ���� �� ���ϱ�
        int recovery = PlayerSetting.recoveryLV; //ȸ�� �ɷ�ġ �ҷ����
        maxValue = recovery * 2; //�ִ밪� ȸ�� ������ 2��
        int recoveryValue = Random.Range(recovery, maxValue + 1); //����
        recoveryValueText.text = recoveryValue.ToString(); //��ݰ�� ���ڿ��� ��ȯ
    }
    public void ShowRecoveryValue() { //ȸ�� �ൿ�� ǥ��
        attackValueText.text = "";
        defenseValueText.text = "";
        SelectRecoveryVal();
    }
}