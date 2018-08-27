using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RokusukeBallHutch : MonoBehaviour
{
    List<ILoader> LList { get; set; }

    // Use this for initialization
    void Start()
    {
        LList = new List<ILoader>()
        {
            new EnemyLoader("Prefabs/SukekiyoBall",1.1f),
            new EnemyLoader("Prefabs/RokusukeBall",0.4f),
            new EnemyLoader("Prefabs/NosakaBall",1.1f),
            new EnemyLoader("Prefabs/TaroBall",0.1f),
            new ItemLoader("Prefabs/ItemBook",0.7f)
        };
    }

    void FixedUpdate()
    {
        StageController sc = StageController.GetStartController();
        if (!sc.IsPlaying)
            return;

        foreach (EnemyLoader el in LList)
        {
            if (el.IsGo())
                Instantiate(el.Resource, el.GetLocalPosition() + transform.position, el.GetRotation());
        }


    }

    public interface ILoader
    {
        Quaternion GetRotation();
        bool IsGo();
        Vector3 GetLocalPosition();

    }

    /// <summary>
    /// 敵出現率分母を倍加
    /// </summary>
    /// <param name="ff"></param>
    public void AccelEnemyDropDenomi(float ff) {
        foreach (ILoader l in LList) {
            if (typeof(EnemyLoader) == l.GetType())
                ((EnemyLoader)l).DropDenomi *=ff;
        }

    }

    /// <summary>
    /// 外から拾うよう
    /// </summary>
    /// <returns></returns>
    public static RokusukeBallHutch GetEnemyHatch() {
        GameObject sCon = GameObject.FindGameObjectsWithTag("EnemyHatch")[0];
        return sCon.GetComponents<RokusukeBallHutch>()[0];
    }

    /// <summary>
    /// 敵召喚ローダー
    /// </summary>
    private class EnemyLoader : ILoader
    {
        /// <summary>
        /// ドロップ率分母
        /// </summary>
        public virtual float DropDenomi
        {
            get
            {
                if (StageController.GetStartController().LeftTime < StageController.START_TIME / 6f)
                {
                    return Mathf.RoundToInt(this._baseDenomi * 0.3f);
                }
                return this._baseDenomi;
            }
            set { this._baseDenomi = value; }
        }
        private float _baseDenomi = 10000f;

        public GameObject Resource { get; private set; }

        /// <summary>
        /// ドロップ率分子
        /// </summary>
        float Percentage { get; set; }

        public EnemyLoader(string preabPath, float percentage)
        {
            Resource = (GameObject)Resources.Load(preabPath);
            Percentage = percentage;
        }

        public virtual Vector3 GetLocalPosition()
        {
            return new Vector3(UnityEngine.Random.Range(-15.0f, 15.0f), 0, 0);
        }

        /// <summary>
        /// 初期時のローテーション
        /// </summary>
        /// <returns></returns>
        public Quaternion GetRotation()
        {
            return Resource.transform.rotation;
        }

        /// <summary>
        /// 出現すべきタイミングかどうか
        /// </summary>
        /// <returns></returns>
        public bool IsGo()
        {
            float ranNum = UnityEngine.Random.Range(0f, DropDenomi);
            return ranNum < Percentage * 100;
        }


    }

    /// <summary>
    /// アイテム召還ローダー
    /// </summary>
    private class ItemLoader : EnemyLoader
    {
        public override float DropDenomi { get { return 10000; } }

        public ItemLoader(string preabPath, float percentage) : base(preabPath, percentage)
        {
        }
        public override Vector3 GetLocalPosition()
        {
            return new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, 0);
        }

    }
}
