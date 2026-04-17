
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public GameObject AttackConfirmPanel;
    public GameObject AttackResultPanel;
    public Text AttackConfirmText;
    public Text AttackResultText;
    public Button YesButton;
    public Button NoButton;
    public Button OKButton;
    public Image UnitImage;
    public Button mySpearButton;
    public Button myHorseButton;
    public Button myBulletButton;

    public GameObject ImageOfSpear;
    public GameObject ImageOfHorse;
    public GameObject ImageOfBullet;


    private string selectedUnitType;


    void Start()
    {
        AttackConfirmPanel.SetActive(false);
        YesButton.onClick.AddListener(OnConfirm);
        NoButton.onClick.AddListener(OnCancel);
        AttackResultPanel.SetActive(false);
        YesButton.onClick.AddListener(OnOKButton);
        mySpearButton.onClick.AddListener(OnSpearUnitButtonClicked);
        myHorseButton.onClick.AddListener(OnHorseUnitButtonClicked);
        myBulletButton.onClick.AddListener(OnBulletUnitButtonClicked);

    }

    public void OnSpearUnitButtonClicked()
    {
        OnUnitButtonClicked("槍足軽");
    }

    public void OnHorseUnitButtonClicked()
    {
        OnUnitButtonClicked("騎馬足軽");
    }

    public void OnBulletUnitButtonClicked()
    {
        OnUnitButtonClicked("鉄砲足軽");
    }


    public void OnUnitButtonClicked(string unitType)
    {
        selectedUnitType = unitType;
        AttackConfirmText.text = $"{unitType}で出撃しますか？";
        AttackConfirmPanel.SetActive(true);
       ShowSelectedUnitImage(selectedUnitType);
    }

    /// <summary>
    /// 出撃確認で「はい」を選択時
    /// 敵部隊の出撃部隊選出、相性判定、勝敗判定を行う。
    /// </summary>
    void OnConfirm()
    {
        // AttackConfirmPanel.SetActive(false);
        AttackConfirmPanel.SetActive(true);

        // 敵部隊の出撃部隊選出、相性判定、勝敗判定を行う。
        switch(selectedUnitType)
        {
            case "槍足軽":
                ImageOfSpear.SetActive(true);
                break;
            case "騎馬足軽":
                ImageOfHorse.SetActive(true);
                break;
            case "鉄砲足軽":
                ImageOfBullet.SetActive(true);
                break;
        }

    DeployUnit(selectedUnitType);
    ShowSelectedUnitImage(selectedUnitType);
    }

    /// <summary>
    /// 出撃確認で「いいえ」を選択時
    /// </summary>
    void OnCancel()
    {
        AttackConfirmPanel.SetActive(false);
    }

    /// <summary>
    /// 出撃結果画面で「OK」を選択時
    /// </summary>
    void OnOKButton()
    {
        AttackConfirmPanel.SetActive(false);
    }

    void DeployUnit(string unitType)
    {
        Debug.Log($"{unitType}を出撃させました！");
        AttackConfirmText.text = $"{unitType}を出撃させました！";
        // 出撃処理（敵の兵種選択、兵数比較など）をここに記述
    }

    void ShowSelectedUnitImage(string unitType)
    {

        // 選ばれた兵種だけ表示
        switch (unitType)
        {
            case "槍足軽":
                ImageOfSpear.SetActive(true);
                break;
            case "騎馬足軽":
                ImageOfHorse.SetActive(true);
                break;
            case "鉄砲足軽":
                ImageOfBullet.SetActive(true);
                break;
        }

    }

}
