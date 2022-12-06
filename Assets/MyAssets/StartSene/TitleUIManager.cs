using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour
{
    //?{?^????
    [SerializeField] GameObject TitleUIStart, TitleUIOperation, TitleUICredit;

    //?p?l????
    [SerializeField] GameObject TitleOperationPanel, TitleCreditPanel;

    private void Awake()
    {
        //?p?l???????????????\??
        TitleOperationPanel.SetActive(false);
        TitleCreditPanel.SetActive(false);
    }

    //?Q?[???X?^?[?g?{?^??
    public void GoGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    //?{?^???????p
    public void SetButton(bool onoff)
    {
        TitleUIStart.SetActive(onoff);
        TitleUIOperation.SetActive(onoff);
        TitleUICredit.SetActive(onoff);
    }

    //?p?l???\??
    public void OnPanel(GameObject panels)
    {
        panels.SetActive(true);
    }

}
