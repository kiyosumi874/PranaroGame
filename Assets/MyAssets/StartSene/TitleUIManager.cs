using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour
{
    //ボタン類
    [SerializeField] GameObject TitleUIStart, TitleUIOperation, TitleUICredit;

    //パネル類
    [SerializeField] GameObject TitleOperationPanel, TitleCreditPanel;

    private void Awake()
    {
        //パネルは初期から非表示
        TitleOperationPanel.SetActive(false);
        TitleCreditPanel.SetActive(false);
    }

    //ゲームスタートボタン
    public void GoGame()
    {
        SceneManager.LoadScene("");
    }

    //ボタン制御用
    public void SetButton(bool onoff)
    {
        TitleUIStart.SetActive(onoff);
        TitleUIOperation.SetActive(onoff);
        TitleUICredit.SetActive(onoff);
    }

    //パネル表示
    public void OnPanel(GameObject panels)
    {
        panels.SetActive(true);
    }

}
