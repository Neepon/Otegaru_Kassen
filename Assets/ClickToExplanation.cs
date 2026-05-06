using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClickToExplanation : MonoBehaviour 
{

    [SerializeField] string sceneName = "ExplanationScene";
    [SerializeField] bool useAsync = false;

    public Button myButton;

    void Awake()
    {
        // 同じ GameObject の Button を自動で拾う
        myButton = GetComponent<Button>();
        if (myButton == null)
            Debug.LogError("[ClickToExplanation] Button コンポーネントが見つかりません。");
    }


    void OnEnable()
    {
        // 実行時にロード可能かをチェック（未登録/名前不一致の早期検出）
        if (!Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.LogError($"[ClickToExplanation] Scene '{sceneName}' は Build Settings に登録されていないか、名前が一致していません。");
        }
        // リスナー登録
        if (useAsync)
            myButton.onClick.AddListener(LoadExplanationAsync);
        else
            myButton.onClick.AddListener(LoadExplanation);
    }

    void OnDisable()
    {
        // リスナー解除（重複登録を防止）
        if (useAsync)
            myButton.onClick.RemoveListener(LoadExplanationAsync);
        else
            myButton.onClick.RemoveListener(LoadExplanation);
    }

    public void LoadExplanation()
    {
        Debug.Log($"[ClickToExplanation] LoadScene: {sceneName}");
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void LoadExplanationAsync()
    {
        Debug.Log($"[ClickToExplanation] LoadSceneAsync: {sceneName}");
        StartCoroutine(CoLoad(sceneName));
    }

    IEnumerator CoLoad(string name)
    {
        var op = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
        while (!op.isDone) yield return null;
    }


    //void Start()
    //{

    //    // ボタンがクリックされたときに呼ばれる関数を登録
    //    myButton.onClick.AddListener(LoadExplanation);
    //}

    // タイトル → 説明シーンへ
    //public void LoadExplanation()
    //{
    //    SceneManager.LoadScene("ExplanationScene", LoadSceneMode.Single);
    //}

    //// （おまけ）非同期ロードで固まりにくくする
    //public void LoadExplanationAsync()
    //{
    //    StartCoroutine(CoLoad("ExplanationScene"));
    //}

    //private System.Collections.IEnumerator CoLoad(string sceneName)
    //{
    //    var op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    //    // allowSceneActivation = true（デフォルト）なら op.isDone を待つだけ
    //    while (!op.isDone) yield return null;
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Debug.Log("[TEST] F5でロード実行");
            UnityEngine.SceneManagement.SceneManager.LoadScene("ExplanationScene");
        }

    }
}
