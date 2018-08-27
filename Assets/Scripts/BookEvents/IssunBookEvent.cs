using UnityEngine;
using UnityEditor;

public class IssunBookEvent : IBookEvent
{

    public string GetTitle()
    {
        return "江戸川乱歩『踊る一寸法師』";
    }
    public string GetComment()
    {
        return "小さくなっちゃった！ --プレイヤー縮小--";
    }
    public float GetTermSec()
    {
        return 5f;
    }
    public string GetImgPath() {
        return "BookImg/issun";
    }


    private float BefMaxFor;
    private float BefMaxbac;
    private float BefAcc;

    public void EventStart()
    {
        Player.GetPlayer().transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
    }
    public void EventEnd()
    {
        Player.GetPlayer().transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);

    }
}