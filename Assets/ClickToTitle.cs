using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClickToTitle : MonoBehaviour
{
    public Button myButton;
    void Start()
    {

        // ボタンがクリックされたときに呼ばれる関数を登録
        myButton.onClick.AddListener(LoadTitle);
    }

    // タイトル → 説明シーンへ
    public void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }

    // （おまけ）非同期ロードで固まりにくくする
    public void LoadTitleAsync()
    {
        StartCoroutine(CoLoad("TitleScene"));
    }

    private System.Collections.IEnumerator CoLoad(string sceneName)
    {
        var op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        // allowSceneActivation = true（デフォルト）なら op.isDone を待つだけ
        while (!op.isDone) yield return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
