
using UnityEngine;
using UnityEngine.UI;

public class EnemyArmyGenerator : MonoBehaviour
{
    public Text enemySpearText;
    public Text enemyHorseText;
    public Text enemyBulletText;

    public int EnemySpearCount { get; private set; }
    public int EnemyHorseCount { get; private set; }
    public int EnemyBulletCount { get; private set; }

    void Start()
    {
        GenerateEnemyArmy();
        UpdateEnemyUIText();
        Debug.Log($"槍: {EnemySpearCount}, 騎馬: {EnemyHorseCount}, 鉄砲: {EnemyBulletCount}");

        //if (enemySpearText == null)
        //    Debug.LogWarning("enemySpearText が未設定です");
        //if (enemyHorseText == null)
        //    Debug.LogWarning("enemyHorseText が未設定です");
        //if(enemyBulletText == null)
        //    Debug.LogWarning("enemyBulletText が未設定です");

    }

    void GenerateEnemyArmy()
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
        EnemySpearCount = minPerUnit + extraSpear;
        EnemyHorseCount = minPerUnit + extraHorse;
        EnemyBulletCount = minPerUnit + extraBullet;

    }

    void UpdateEnemyUIText()
    {
        enemySpearText.text = $"槍足軽: {EnemySpearCount}人";
        enemyHorseText.text = $"騎馬足軽: {EnemyHorseCount}人";
        enemyBulletText.text = $"鉄砲足軽: {EnemyBulletCount}人";

        if (enemyHorseText == null)
            Debug.LogError("enemyHorseText が null です。Inspectorで正しくアサインされているか確認してください。");
        else
            enemyHorseText.text = $"騎馬足軽: {EnemyHorseCount}人";

        if (enemyBulletText == null)
            Debug.LogError("enemyBulletText が null です。Inspectorで正しくアサインされているか確認してください。");
        else
            enemyBulletText.text = $"鉄砲足軽: {EnemyBulletCount}人";

        Debug.Log($"槍足軽: {EnemySpearCount}人");
        Debug.Log($"騎馬足軽: {EnemyHorseCount}人");
        Debug.Log($"鉄砲足軽: {EnemyBulletCount}人");
        Debug.Log($"enemySpearText.text: {enemySpearText.text}");
        Debug.Log($"enemyHorseText.text: {enemyHorseText.text}");
        Debug.Log($"enemyBulletText.text: {enemyBulletText.text}");
    }
}
