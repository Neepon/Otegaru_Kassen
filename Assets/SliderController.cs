using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider VerticalSliderSpear;
    public Slider VerticalSliderHorse;
    public Text MySpearCount;
    public Text MyHorseCount;
    public Text MyBulletCount;
    public int Battle_Kaisu;

    void Start()
    {
        VerticalSliderSpear.onValueChanged.AddListener(OnSliderChanged);
        VerticalSliderHorse.onValueChanged.AddListener(OnSliderChanged);
        UpdateValues();
    }
    void OnSliderChanged(float _)
    {
        float a = VerticalSliderSpear.value;
        float b = VerticalSliderHorse.value;

        // A + B が 1 を超えないように制限
        if (a + b > 1f)
        {
            float excess = (a + b) - 1f;

            // Bを優先して減らす（必要に応じてロジック変更可能）
            if (b >= excess)
                VerticalSliderHorse.value = b - excess;
            else
                VerticalSliderSpear.value = a - (excess - b);
        }

        UpdateValues();
    }

    void UpdateValues()
    {
        float a = VerticalSliderSpear.value;
        float b = VerticalSliderHorse.value;
        float c = Mathf.Clamp01(1f - a - b);

        MySpearCount.text = $"槍足軽: {(a * 100f):F0}人";
        MyHorseCount.text = $"騎馬足軽: {(b * 100f):F0}人";
        MyBulletCount.text = $"鉄砲足軽: {(c * 100f):F0}人";
    }

}
