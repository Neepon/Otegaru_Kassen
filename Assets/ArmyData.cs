using UnityEngine;

public class ArmyData : MonoBehaviour
{
    public static ArmyData Instance;

    public int playerSpear;
    public int playerHorse;
    public int playerBullet;

    public int enemySpear;
    public int enemyHorse;
    public int enemyBullet;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ƒV[ƒ“‚ğ‚Ü‚½‚¢‚Å‚à”jŠü‚³‚ê‚È‚¢
        }
        else
        {
            Destroy(gameObject); // d•¡–h~
        }
    }
}
