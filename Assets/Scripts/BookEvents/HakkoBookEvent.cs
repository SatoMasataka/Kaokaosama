using UnityEngine;
using UnityEditor;

public class HakkoBookEvent : IBookEvent
{

    public string GetTitle()
    {
        return "新田次郎『八甲田山死の彷徨』";
    }
    public string GetComment()
    {
        return "天は我々を見放した！！！ --敵大量増殖--";
    }
    public float GetTermSec()
    {
        return 2f;
    }
    public string GetImgPath() {
        return "BookImg/hakko";
    }


    private float BefMaxFor;
    private float BefMaxbac;
    private float BefAcc;

    public void EventStart()
    {
        RokusukeBallHutch.GetEnemyHatch().AccelEnemyDropDenomi(0.1f);
    }
    public void EventEnd()
    {
        RokusukeBallHutch.GetEnemyHatch().AccelEnemyDropDenomi(10f);
    }
}