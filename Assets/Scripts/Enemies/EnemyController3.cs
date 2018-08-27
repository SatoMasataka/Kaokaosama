using UnityEngine;
using System.Collections;

/// <summary>
/// 如意棒
/// </summary>
public class EnemyController3 : EnemyControllerBase
{

    protected override void Start()
    {
        base.Start();

    }

    protected override float GetSpeed() {
        if(_Speed <=0)
            this._Speed = Random.Range(-37f, -36f);

        return this._Speed;
    }

    private float _Speed = 0;

    protected override void AheadAction()
    {
        base.AheadAction();

        //死んだら広がる
        if (nowStatus == Status.dead && this.transform.localScale.y < 10)
            this.transform.localScale += new Vector3(0.1f, 0.8f, 0);
       
    }




}
