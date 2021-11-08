
using UnityEngine;
/// <summary>
/// 遊戲管理器
/// 離開遊戲，重開遊戲等等..
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void Quit()
    {
        print("離開遊戲");
        Application.Quit();
    }

}
