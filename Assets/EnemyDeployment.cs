using System.Collections.Generic;
using UnityEngine;

public class EnemyDeployment : MonoBehaviour
{
    public static EnemyDeployment Instance;

    private List<UnitType> availableUnits = new List<UnitType> { UnitType.Spear, UnitType.Horse, UnitType.Bullet };

    void Awake()
    {
        Instance = this;
    }

    public void DeployEnemyUnit(UnitType playerUnit, int playerCount)
    {
        BattleJudge judge = new BattleJudge();
        if (availableUnits.Count == 0)
        {
            Debug.Log("敵軍：全兵種出撃済み");
            return;
        }

        int index = Random.Range(0, availableUnits.Count);
        UnitType enemyUnit = availableUnits[index];
        availableUnits.RemoveAt(index); // 出撃済み兵種を除外

        int enemyCount = GetEnemyCount(enemyUnit);

        // 戦闘判定へ
        WinnerTeamJudge winnerTeam = judge.JudgeBattle(playerUnit, playerCount, enemyUnit, enemyCount);

    }

    int GetEnemyCount(UnitType unit)
    {
        switch (unit)
        {
            case UnitType.Spear: return ArmyData.Instance.enemySpear;
            case UnitType.Horse: return ArmyData.Instance.enemyHorse;
            case UnitType.Bullet: return ArmyData.Instance.enemyBullet;
            default: return 0;
        }
    }
}

