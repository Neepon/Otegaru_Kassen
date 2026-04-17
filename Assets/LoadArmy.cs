using UnityEngine;
using UnityEngine.UI;

public class LoadArmy : MonoBehaviour
{
    public Text MySpearCount;
    public Text MyHorseCount;
    public Text MyBulletCount;
    public Text EnemySpearCount;
    public Text EnemyHorseCount;
    public Text EnemyBulletCount;


    void Start()
    {
        int mySpear = ArmyData.Instance.playerSpear;
        int myHorse = ArmyData.Instance.playerHorse;
        int myBullet = ArmyData.Instance.playerBullet;
        int eneSpear = ArmyData.Instance.enemySpear;
        int eneHorse = ArmyData.Instance.enemyHorse;
        int eneBullet = ArmyData.Instance.enemyBullet;
        // UI‚É•\¦‚È‚Ç
        MySpearCount.text = $"‘„‘«Œy: {mySpear}l"; ;
        MyHorseCount.text   = $"‹R”n‘«Œy: {myHorse}l"; ;
        MyBulletCount.text = $"‘„“S–C‘«Œy: {myBullet}l";
        EnemySpearCount.text = $"‘„‘«Œy: {eneSpear}l"; 
        EnemyHorseCount.text  = $"‹R”n‘«Œy: {eneHorse}l";
        EnemyBulletCount.text = $"“S–C‘«Œy: {eneBullet}l";
    }

}
