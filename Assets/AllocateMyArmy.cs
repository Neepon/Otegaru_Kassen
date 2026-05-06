
using UnityEngine;
using UnityEngine.UI;

public class MyArmyGenerator : MonoBehaviour
{
    public Text spearText;
    public Text horseText;
    public Text bulletText;

    public int MySpearCount { get; private set; }
    public int MyHorseCount { get; private set; }
    public int MyBulletCount { get; private set; }

    void Start()
    {
        GenerateMyArmy();
        UpdateMyUIText();
    }

    void GenerateMyArmy()
    {
        int total = 100;
        int minPerUnit = 10; // 各兵種の最低人数

        // 残りの人数（最低人数を引いた後）
        int remaining = total - (minPerUnit * 3);

        // 0〜残りの範囲でランダムに割り振る
        int extraSpear = Random.Range(0, remaining + 1);
        int extraHorse = Random.Range(0, remaining - extraSpear + 1);
        int extraBullet = remaining - extraSpear - extraHorse;

        // 最終的な人数
        MySpearCount = minPerUnit + extraSpear;
        MyHorseCount = minPerUnit + extraHorse;
        MyBulletCount = minPerUnit + extraBullet;
    }

    void UpdateMyUIText()
    {
        spearText.text = $"槍足軽: {MySpearCount}人";
        horseText.text = $"騎馬足軽: {MyHorseCount}人";
        bulletText.text = $"鉄砲足軽: {MyBulletCount}人";
    }
}
