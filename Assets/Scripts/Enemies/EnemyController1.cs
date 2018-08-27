using UnityEngine;
using System.Collections;

/// <summary>
/// 伸縮する敵
/// </summary>
public class EnemyController1 : EnemyControllerBase
{
    float maxY = 3;
    float minY = 1f;
    private bool isExpand { get; set; }

    protected override void Start()
    {
        base.Start();
        isExpand = true;

    }

    protected override float GetSpeed() {
        if(_Speed <=0)
            this._Speed = Random.Range(-10f, -20f);

        return this._Speed;
    }

    private float _Speed = 0;

    protected override void AheadAction()
    {
        base.AheadAction();

        if (isExpand) {
            transform.localScale += new Vector3(0, 0.6f, 0);
            if (transform.localScale.y > maxY) 
                isExpand = false;
            
        }
        else{
            transform.localScale -= new Vector3(0, 0.2f, 0);
            if (transform.localScale.y < minY)
                isExpand = true;
        }
       
    }



}
