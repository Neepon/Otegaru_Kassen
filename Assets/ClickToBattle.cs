using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ClickToBattle : MonoBehaviour
{
    public Button myButton;

    public Text MySpearCount;
    public Text MyHorseCount;
    public Text MyBulletCount;
    public Text EnemySpearCount;
    public Text EnemyHorseCount;
    public Text EnemyBulletCount;

    void Start()
    {

        // ボタンがクリックされたときに呼ばれる関数を登録
        myButton.onClick.AddListener(LoadButtle);
    }

    public void LoadButtle()
    {
        //SceneManager.LoadScene("ButtleScene", LoadSceneMode.Single);
        OnDeployButtonPressed();
    }
    public void OnDeployButtonPressed()
    {
        ArmyData.Instance.playerSpear = ParseUnitCount(MySpearCount.text);
        ArmyData.Instance.playerHorse = ParseUnitCount(MyHorseCount.text);
        ArmyData.Instance.playerBullet = ParseUnitCount(MyBulletCount.text);

        ArmyData.Instance.enemySpear =ParseUnitCount(EnemySpearCount.text);
        ArmyData.Instance.enemyHorse =ParseUnitCount(EnemyHorseCount.text);
        ArmyData.Instance.enemyBullet = ParseUnitCount(EnemyBulletCount.text);

        SceneManager.LoadScene("BattleScene"); // 次のシーン名に変更
    }

    int ParseUnitCount(string text)
    {
        // 例: "兵力A: 30%" → 数字部分だけ抽出
        string digits = System.Text.RegularExpressions.Regex.Match(text, @"\d+").Value;
        return int.TryParse(digits, out int result) ? result : 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
