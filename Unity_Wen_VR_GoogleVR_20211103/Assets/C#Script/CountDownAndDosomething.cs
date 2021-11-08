using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// �˼ƭp��
/// �åB���� [�Y��Ʊ�]
/// �C�p: ���}�C���A���}�C���A��ܿ��
/// </summary>
public class CountDownAndDosomething : MonoBehaviour
{
    #region     ���M�ݩ�
    [Header("�˼Ʈɶ�"), Range(0, 5)]
    public float timeCountDown = 3;
    [Header("�˼ƫ�ƥ�")]
    public UnityEvent onTimeUP;
    [Header("����")]
    public Image imgBar;
    private float timeMax;
    ///<summary>
    /// �}�l�˼�:true �}�l �Afalse ����
    /// Unity Event �i�H�s��
    /// 1. ���骫�� �s�����󤺪�API
    /// 2.�s����k�ȭ� : �L�Ϊ̤@�ӰѼơA����������(������)
    /// 3.�s�����}�ݩ� : ������������� (������)
    ///</summary>
    public bool startCountDown { get; set; }
    #endregion
    #region
    // ����ƥ� : �b Start �e����@��
    private void Awake()
    {
        timeMax = timeCountDown;
    }
    private void Update()
    {
        CountDown();
    }
    ///<summary>
    ///�p�ɾ�
    ///</summary>
    private float timer;
    private void CountDown()
    {
        if (startCountDown)                 //�p�G �}�l�˼�
        {   
            if (timer < timeCountDown)      //�p�G�p�ɾ��p��˼Ʈɶ�
            {
                timer += Time.deltaTime;    //�֥[�ɶ�(�� Updata ���I�s)
            }
            else
            {
                onTimeUP.Invoke();          //�_�h �p�ɾ��j�󵥩� �q�Ʈɶ� �N �I�s�ƥ�
            }
            imgBar.fillAmount = timer / timeMax;  //���� = ��e�ɶ� / �̤j�ɶ�
        }
        else                                    //�_�h �S���ݨ���s �N����
        {
            timer = 0;                          //�p�ɾ��k�s
            imgBar.fillAmount = 0;              //�����k�s
        }
    }
    #endregion
}
