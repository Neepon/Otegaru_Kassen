
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

[System.Serializable]
public class UnitData
{
    public string unitType;         // 兵種
    public int count;                   // 人数
    public bool isDeployed;     // 出撃済み判定
}

public class BattleManager : MonoBehaviour
{
    public GameObject AttackConfirmPanel;
    public GameObject AttackResultPanel;
    public Text AttackConfirmText;
    public Text AttackResultText;

    // 自軍兵種の任数
    public Text MySpearCount; // 槍
    public Text MyHorseCount; // 騎馬
    public Text MyBulletCount; // 鉄砲
    public Text MyWinCount;

    // 敵兵種の人数
    public Text EnemySpearCount; // 槍
    public Text EnemyHorseCount; // 騎馬
    public Text EnemyBulletCount; // 鉄砲
    public Text EnemyWinCount; 

    public Button YesButton;
    public Button NoButton;
    public Button OKButtonToResult;
    public Button mySpearButton;
    public Button myHorseButton;
    public Button myBulletButton;

    public GameObject ImageOfSpear;
    public GameObject ImageOfHorse;
    public GameObject ImageOfBullet;
    public GameObject ImageOfSpear_Result;
    public GameObject ImageOfHorse_Result;
    public GameObject ImageOfBullet_Result;

    private string selectedUnitType;
    public List<UnitData> playerUnits = new List<UnitData>();
    public List<UnitData> enemyUnits = new List<UnitData>();


    // string型変換用
    string strEnemySpearCount = "";
    string strEnemyHorseCount = "";
    string strEnemyBulletCount = "";
    // int型変換用
    int intPlayerSpearCount = 0;
    int intPlayerHorseCount = 0;
    int intPlayerBulletCount = 0;
    int intPlayerWinCount = 0;
    int intEnemySpearCount = 0;
    int intEnemyHorseCount = 0;
    int intEnemyBulletCount = 0;
    int intEnemyWinCount = 0;
    int totalDeployCount = 0;

    void Start()
    {
        AttackConfirmPanel.SetActive(false);
        AttackResultPanel.SetActive(false);
        YesButton.onClick.AddListener(OnConfirm);
        NoButton.onClick.AddListener(OnCancel);
        OKButtonToResult.onClick.AddListener(OnOKToResult);
        AttackResultPanel.SetActive(false);
        mySpearButton.onClick.AddListener(OnSpearUnitButtonClicked);
        myHorseButton.onClick.AddListener(OnHorseUnitButtonClicked);
        myBulletButton.onClick.AddListener(OnBulletUnitButtonClicked);
        ImageOfSpear.SetActive(false);
        ImageOfHorse.SetActive(false);
        ImageOfBullet.SetActive(false);
        ImageOfSpear_Result.SetActive(false);
        ImageOfHorse_Result.SetActive(false);
        ImageOfBullet_Result.SetActive (false);

        intPlayerSpearCount = int.Parse(MySpearCount.ToString());
        intPlayerHorseCount = int.Parse(MyHorseCount.ToString());
        intPlayerBulletCount = int.Parse(MyBulletCount.ToString());
        intEnemySpearCount = int.Parse(EnemySpearCount.ToString());
        intEnemyHorseCount = int.Parse(EnemySpearCount.ToString());
        intEnemyBulletCount = int.Parse(EnemyBulletCount.ToString());

        playerUnits.Add(new UnitData { unitType = "槍足軽", count = intPlayerSpearCount, isDeployed = false });
        playerUnits.Add(new UnitData { unitType = "騎馬足軽", count = intPlayerHorseCount, isDeployed = false });
        playerUnits.Add(new UnitData { unitType = "鉄砲足軽", count = intPlayerBulletCount, isDeployed = false });
        enemyUnits.Add(new UnitData { unitType = "槍足軽", count = intEnemySpearCount, isDeployed = false });
        enemyUnits.Add(new UnitData { unitType = "騎馬足軽", count = intEnemyHorseCount, isDeployed = false });
        enemyUnits.Add(new UnitData { unitType = "鉄砲足軽", count = intEnemyBulletCount, isDeployed = false });

    }

    /// <summary>
    /// 槍ボタンクリック時
    /// </summary>
    public void OnSpearUnitButtonClicked()
    {
        selectedUnitType = "槍足軽";
        OnUnitButtonClicked(selectedUnitType);
    }

    /// <summary>
    /// 騎馬ボタンクリック時
    /// </summary>
    public void OnHorseUnitButtonClicked()
    {
        selectedUnitType = "騎馬足軽";
        OnUnitButtonClicked(selectedUnitType);
    }

    /// <summary>
    /// 鉄砲ボタンクリック時
    /// </summary>
    public void OnBulletUnitButtonClicked()
    {
        selectedUnitType = "鉄砲足軽";
        OnUnitButtonClicked(selectedUnitType);
    }

    /// <summary>
    /// 上記の各兵種ボタンクリック時の処理
    /// 押したボタンに応じたアイコンやメッセージを表示する。
    /// 出撃確認のパネル（ウィンドウ）を表示し、
    /// </summary>
    /// <param name="unitType"></param>
    public void OnUnitButtonClicked(string unitType)
    {
        ImageOfSpear.SetActive(false);
        ImageOfHorse.SetActive(false);
        ImageOfBullet.SetActive(false);
        ImageOfSpear_Result.SetActive(false);
        ImageOfHorse_Result.SetActive(false);
        ImageOfBullet_Result.SetActive(false);

        AttackConfirmPanel.SetActive(true);
        AttackConfirmText.text = $"{unitType}で出撃しますか？";
        if("槍足軽".Equals(unitType))
        {
            ImageOfSpear.SetActive(true);
        }
        else if("騎馬足軽".Equals(unitType))
        {
            ImageOfHorse.SetActive(true);
        }
        else if ("鉄砲足軽".Equals(unitType))
        {
            ImageOfBullet.SetActive(true);
        }
    }

    /// <summary>
    /// 出撃確認で「はい」を選択時
    /// 敵部隊の出撃部隊選出、相性判定、それを基に勝敗判定を行う。
    /// </summary>
    void OnConfirm()
    {
        ImageOfSpear.SetActive(false);
        ImageOfHorse.SetActive(false);
        ImageOfBullet.SetActive(false);
        ImageOfSpear_Result.SetActive(false);
        ImageOfHorse_Result.SetActive(false);
        ImageOfBullet_Result.SetActive(false);
        AttackConfirmPanel.SetActive(false);

        string DeployEnemyUnitType = "テスト足軽"; 
        int PlayerUnitCount = 0; // 自軍の出撃人数
        int EnemyUnitCount = 0; // 敵軍の出撃人数
        string resultMessage = "";

        int WinJudge = 0;

        // 敵部隊の出撃部隊選出、相性判定、勝敗判定を行う。
        switch (selectedUnitType)
        {
            case "槍足軽":
                ImageOfSpear_Result.SetActive(true);
                break;
            case "騎馬足軽":
                ImageOfHorse_Result.SetActive(true);
                break;
            case "鉄砲足軽":
                ImageOfBullet_Result.SetActive(true);
                break;
        }

        // 出撃する敵の兵種を決める
        DeployEnemyUnitType = DeployEnemyUnit();

        // 戦闘判定を行う。
        WinJudge = JudgeBattle(selectedUnitType, PlayerUnitCount, DeployEnemyUnitType, EnemyUnitCount);

        // 自軍勝利時
        if(WinJudge == 1)
        {
            intPlayerWinCount += 1;
            MyWinCount.text = intPlayerWinCount.ToString();
            resultMessage = $"自軍の{selectedUnitType}の勝ち！";
        }
        // 敵軍勝利時
        else if(WinJudge == 2)
        {
            intEnemyWinCount += 1;
            EnemyWinCount.text = intEnemyWinCount.ToString();
            resultMessage = $"自軍の{selectedUnitType}の負け・・・";
        }
        else
        {
            resultMessage = $"引き分け・・・";
        }
        totalDeployCount += 1;

        AttackResultText.text = $"自軍は{selectedUnitType}を出撃した！相手は{DeployEnemyUnitType}を繰り出した！" + resultMessage.ToString();
        AttackResultPanel.SetActive(true);

        //ShowSelectedUnitImage(selectedUnitType);
    }

    /// <summary>
    /// 出撃確認で「いいえ」を選択時
    /// </summary>
    void OnCancel()
    {
        ImageOfSpear.SetActive(false);
        ImageOfHorse.SetActive(false);
        ImageOfBullet.SetActive(false);
        ImageOfSpear_Result.SetActive(false);
        ImageOfHorse_Result.SetActive(false);
        ImageOfBullet_Result.SetActive(false);
        AttackConfirmPanel.SetActive(false);
        AttackResultPanel.SetActive(false);
    }

    /// <summary>
    /// 敵の出撃兵種を決める
    /// </summary>
    /// <returns></returns>
    string DeployEnemyUnit()
    {
        string deployUnit = "";
        System.Random r = new System.Random();
        int randNum = r.Next();

        // 乱数を3で割って1の場合は騎馬
        if (randNum % 3 == 1)
        {
            return "騎馬足軽";
        }
        // 乱数を3で割って2の場合は鉄砲
        else if (randNum % 3 == 2)
        {
            return "鉄砲足軽";
        }

        // それ以外は槍
        return "槍足軽";
    }

    /// <summary>
    /// 結果表示画面でOKを押した場合
    /// </summary>
    void OnOKToResult()
    {
        ImageOfSpear.SetActive(false);
        ImageOfHorse.SetActive(false);
        ImageOfBullet.SetActive(false);
        ImageOfSpear_Result.SetActive(false);
        ImageOfHorse_Result.SetActive(false);
        ImageOfBullet_Result.SetActive(false);
        AttackConfirmPanel.SetActive(false);
        AttackResultPanel.SetActive(false);

        intPlayerWinCount = int.Parse(MyWinCount.ToString());
        intEnemyWinCount = int.Parse(EnemyWinCount.ToString());

        if (intPlayerWinCount >= 2)
        {
            AttackResultText.text = $"自軍の勝利！";
            AttackResultPanel.SetActive(true);
        }
        else if (intEnemyWinCount >= 2)
        {
            AttackResultText.text = $"自軍の敗北・・・";
            AttackResultPanel.SetActive(true);
        }
    }



        /// <summary>
        /// 戦闘判定
        /// 基本的に兵力が多いチームを勝利させる。
        /// 勝利した方に勝利ポイントを+1する。
        /// </summary>
        /// <param name="playerUnit"></param>
        /// <param name="playerCount"></param>
        /// <param name="enemyUnit"></param>
        /// <param name="enemyCount"></param>
        /// <returns>
        ///  0：引き分け
        ///  1：プレイヤー勝利
        ///  2：敵勝利
        /// </returns>
        int JudgeBattle(string playerUnit, int playerCount, string enemyUnit, int enemyCount)
    {
        // プレイヤー側が相性有利の場合、敵の出撃部隊兵数を半減する
        if (IsAdvantage(playerUnit, enemyUnit))
        {
            enemyCount /= 2;
        }
        // 敵側が相性有利の場合、プレイヤーの出撃部隊兵数を半減する
        else if (IsAdvantage(enemyUnit, playerUnit))
        {
            playerCount /= 2;
        }

        // 最終的に兵数の多かった軍を勝利として扱う。
        if (playerCount > enemyCount)
        {
            Debug.Log("自軍の勝利！");
            return 1;
        }
        else if (enemyCount > playerCount)
        {
            Debug.Log("敵軍の勝利！");
            return 2;
        }

        Debug.Log("引き分け！");
        return 0;
    }

    /// <summary>
    /// 相性の優劣判定を返す
    /// </summary>
    /// <param name="advantageous">有利兵種</param>
    /// <param name="disadvantage">不利兵種</param>
    /// <returns></returns>
    bool IsAdvantage(string advantageous, string disadvantage)
    {
        return (advantageous == "槍足軽" && disadvantage == "騎馬足軽") ||
               (advantageous == "騎馬足軽" && disadvantage == "鉄砲足軽") ||
               (advantageous == "鉄砲足軽" && disadvantage == "槍足軽");
    }
}
