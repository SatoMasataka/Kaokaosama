using UnityEngine;
using System.Collections;

/// <summary>
/// 回転する敵
/// </summary>
public class EnemyController2 : EnemyControllerBase
{

    protected override void Start()
    {
        base.Start();

    }

    protected override float GetSpeed()
    {
        if (_Speed <= 0)
            this._Speed = Random.Range(-30f, -35f);

        return this._Speed;
    }

    private float _Speed = 0;

    protected override void AheadAction()
    {
        base.AheadAction();


        this.transform.Rotate(new Vector3(0, 1, 0), 20);

    }



}
