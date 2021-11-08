using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// 倒數計時
/// 並且執行 [某件事情]
/// 列如: 離開遊戲，重開遊戲，顯示選單
/// </summary>
public class CountDownAndDosomething : MonoBehaviour
{
    #region     欄位和屬性
    [Header("倒數時間"), Range(0, 5)]
    public float timeCountDown = 3;
    [Header("倒數後事件")]
    public UnityEvent onTimeUP;
    [Header("介面")]
    public Image imgBar;
    private float timeMax;
    ///<summary>
    /// 開始倒數:true 開始 ，false 停止
    /// Unity Event 可以存取
    /// 1. 實體物件 存取元件內的API
    /// 2.存取方法僅限 : 無或者一個參數，有類型限制(基本類型)
    /// 3.存取公開屬性 : 有資料類型限制 (基本類型)
    ///</summary>
    public bool startCountDown { get; set; }
    #endregion
    #region
    // 喚醒事件 : 在 Start 前執行一次
    private void Awake()
    {
        timeMax = timeCountDown;
    }
    private void Update()
    {
        CountDown();
    }
    ///<summary>
    ///計時器
    ///</summary>
    private float timer;
    private void CountDown()
    {
        if (startCountDown)                 //如果 開始倒數
        {   
            if (timer < timeCountDown)      //如果計時器小於倒數時間
            {
                timer += Time.deltaTime;    //累加時間(於 Updata 內呼叫)
            }
            else
            {
                onTimeUP.Invoke();          //否則 計時器大於等於 島數時間 就 呼叫事件
            }
            imgBar.fillAmount = timer / timeMax;  //長度 = 當前時間 / 最大時間
        }
        else                                    //否則 沒有看到按鈕 就停止
        {
            timer = 0;                          //計時器歸零
            imgBar.fillAmount = 0;              //長度歸零
        }
    }
    #endregion
}
