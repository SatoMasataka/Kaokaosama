using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;

public class StageController : MonoBehaviour
{
    public UnityEngine.UI.Text PlayerScoreText;
    public UnityEngine.UI.Text TimeText;

    /// <summary>
    /// スタート時点の残り時間
    /// </summary>
    public const float START_TIME = 60;

    private int PlayerPoint = 0;

    /// <summary>
    /// 残り時間
    /// </summary>
    public float LeftTime { get; set; }

    public bool IsPlaying { get; set; }

    // Use this for initialization
    void Start()
    {
        PlayerScoreText.text = "0";
        IsPlaying = false;

        LeftTime = START_TIME;

    }

    // Update is called once per frame
    void Update()
    {
        //スコア更新
        PlayerScoreText.text = PlayerPoint.ToString();

        //時間更新
        if (IsPlaying && LeftTime >= 0)
        {
            LeftTime -= Time.deltaTime;
            TimeText.text = Mathf.Ceil(LeftTime).ToString();
        }
        else if (IsPlaying)
        {
            IsPlaying = false;
            GetResultPrefab();

        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }


    }

    /// <summary>
    /// 結果画面プレハブ表示
    /// </summary>
    /// <returns></returns>
    private void GetResultPrefab()
    {
        GameObject pnl = Instantiate((GameObject)Resources.Load("Prefabs/ResultPanel"));
        foreach (UnityEngine.UI.Text txt in pnl.GetComponentsInChildren<UnityEngine.UI.Text>())
        {
            if (txt.name == "MessageText")
            {
                txt.text = GetResultMsg();
            }
            if (txt.name == "ScoreText")
                txt.text = PlayerPoint.ToString();
        }

    }

    public void increasePlayerPoint(int p)
    {
        if (!IsPlaying)
            return;
        PlayerPoint += p * 2;
    }
    public void increaseEnemyPoint(int p)
    {
        if (!IsPlaying)
            return;
        PlayerPoint -= p;
    }

    /// <summary>
    /// 外からステージコントローラを拾う用
    /// </summary>
    /// <returns></returns>
    public static StageController GetStartController()
    {
        GameObject sCon = GameObject.FindGameObjectsWithTag("StageController")[0];
        return sCon.GetComponents<StageController>()[0];
    }

    /// <summary>
    /// 結果画面メッセージ
    /// </summary>
    /// <returns></returns>
    private string GetResultMsg()
    {
        if (PlayerPoint < 200)
            return "MON☆DAI☆GAI";
        if (PlayerPoint < 300)
            return "スコア低っ（笑）";
        if (PlayerPoint < 400)
            return "可もなく不可もなく";
        if (PlayerPoint < 500)
            return "腕上げたなぁ";
        return "高橋名人の再来！";


    }

    /// <summary>
    /// 本取得後のイベント開始
    /// </summary>
    public void BookEventStart()
    {
        if (!IsPlaying) return;
        BookEventHandler bh = new BookEventHandler(this);
        bh.EventStart();


    }

    /// <summary>
    /// ブックイベントハンドラ
    /// </summary>
    private class BookEventHandler
    {
        /// <summary>
        /// ブックイベントリスト
        /// </summary>
        List<IBookEvent> BEvntList = new List<IBookEvent>() {
            new KumoBookEvent()
           , new HakootokoBookEvent()
           , new HakkoBookEvent()
            ,new DaremoBookEvent()
           ,new IssunBookEvent()
            ,new TimeBookEvent()
            ,new HurinkazanBookEvent()
        };

        IBookEvent BEvnt;
        MonoBehaviour MonoBeh;

        /// <summary>
        /// ランダムでブックイベントインスタンス呼び出し
        /// </summary>
        public BookEventHandler(MonoBehaviour mb)
        {
            BEvnt = BEvntList[UnityEngine.Random.Range(0, BEvntList.Count)];
            MonoBeh = mb;
        }

        public void EventStart()
        {
            //パネル用意
            GameObject pnl = Instantiate((GameObject)Resources.Load("Prefabs/BookEventPanel"));
            foreach (UnityEngine.UI.Text txt in pnl.GetComponentsInChildren<UnityEngine.UI.Text>())
            {
                if (txt.name == "BookTitleText")
                {
                    txt.text = BEvnt.GetTitle();
                }
                if (txt.name == "BookCommentText")
                    txt.text = BEvnt.GetComment();
            }
            pnl.GetComponentsInChildren<UnityEngine.UI.RawImage>()[0].texture = (Texture)Resources.Load(BEvnt.GetImgPath());

            //イベントスタート
            MonoBeh.StartCoroutine(EventTerm(pnl));

        }

        /// <summary>
        /// イベント開始～終了までの挙動
        /// </summary>
        /// <returns></returns>
        private IEnumerator EventTerm(GameObject pnl)
        {
            BEvnt.EventStart();
            yield return new WaitForSeconds(BEvnt.GetTermSec());
            BEvnt.EventEnd();
            Destroy(pnl);
        }

    }


}
