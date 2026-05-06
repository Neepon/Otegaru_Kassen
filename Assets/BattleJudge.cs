using UnityEngine;
using UnityEngine.UI;

public class BattleJudge : MonoBehaviour
{
    public WinnerTeamJudge JudgeBattle(UnitType playerUnit, int playerCount, UnitType enemyUnit, int enemyCount)
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
            return WinnerTeamJudge.Player;
        }
        else if (enemyCount > playerCount)
        {
            Debug.Log("敵軍の勝利！");
            return WinnerTeamJudge.Enemy;
        }
        else
        { 
            Debug.Log("引き分け！");
            return WinnerTeamJudge.Draw;
        }
    }

    /// <summary>
    /// 相性の優劣判定を返す
    /// </summary>
    /// <param name="advantageous">有利兵種</param>
    /// <param name="disadvantage">不利兵種</param>
    /// <returns></returns>
    bool IsAdvantage(UnitType advantageous, UnitType disadvantage)
    {
        return (advantageous == UnitType.Spear && disadvantage == UnitType.Horse) ||
               (advantageous == UnitType.Horse && disadvantage == UnitType.Bullet) ||
               (advantageous == UnitType.Bullet && disadvantage == UnitType.Spear);
    }
}

