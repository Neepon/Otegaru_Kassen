using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UnitType
{
    Spear,   // ‘„‘«Œy
    Horse,   // ‹R”n‘«Œy
    Bullet   // “S–C‘«Œy
}

public enum WinnerTeamJudge
{
    Player,     // ƒvƒŒƒCƒ„[
    Enemy,       // “G
    Draw        // ˆø‚«•ª‚¯
}

public class PlayerDeployment : MonoBehaviour
{
    public Button MySpearButton;
    public Button MyHorseButton;
    public Button MyBulletButton;
    void Start()
    {

        // ƒ{ƒ^ƒ“‚ªƒNƒŠƒbƒN‚³‚ê‚½‚Æ‚«‚ÉŒÄ‚Î‚ê‚éŠÖ”‚ğ“o˜^
        MySpearButton.onClick.AddListener(OnClickDeploySpear);
        MyHorseButton.onClick.AddListener(OnClickDeployHorse);
        MyBulletButton.onClick.AddListener(OnClickDeployBullet);
    }

    public void OnClickDeploySpear()
    {
        int playerCount = ArmyData.Instance.playerSpear;
        UnitType playerUnit = UnitType.Spear;

        EnemyDeployment.Instance.DeployEnemyUnit(playerUnit, playerCount);
    }

    public void OnClickDeployHorse()
    {
        int playerCount = ArmyData.Instance.playerHorse;
        UnitType playerUnit = UnitType.Horse;

        EnemyDeployment.Instance.DeployEnemyUnit(playerUnit, playerCount);
    }

    public void OnClickDeployBullet()
    {
        int playerCount = ArmyData.Instance.playerBullet;
        UnitType playerUnit = UnitType.Bullet;

        EnemyDeployment.Instance.DeployEnemyUnit(playerUnit, playerCount);
    }

}
