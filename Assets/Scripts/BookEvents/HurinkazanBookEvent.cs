using UnityEngine;
using UnityEditor;

public class HurinkazanBookEvent : IBookEvent
{

    public string GetTitle()
    {
        return "井上靖『風林火山』";
    }
    public string GetComment()
    {
        return "疾きこと風の如し --プレイヤースピードアップ--";
    }
    public float GetTermSec()
    {
        return 5f;
    }
    public string GetImgPath() {
        return "BookImg/hurin";
    }


    private float BefMaxFor;
    private float BefMaxbac;
    private float BefAcc;

    public void EventStart()
    {
/*        Debug.Log("START");
        Debug.Log(Player.GetPlayer().MaxForwardMoveSpd);
        Debug.Log(BefMaxbac = Player.GetPlayer().MaxBackMoveSpd);
        Debug.Log(BefAcc = Player.GetPlayer().AccelateSpd);*/
        Player.GetPlayer().MaxForwardMoveSpd *= 3f;
        Player.GetPlayer().MaxBackMoveSpd *= 3f;
        Player.GetPlayer().AccelateSpd *= 2f;

    }
    public void EventEnd()
    {
        Player.GetPlayer().MaxForwardMoveSpd /= 3f;
        Player.GetPlayer().MaxBackMoveSpd /= 3f;
        Player.GetPlayer().AccelateSpd /= 2f;
      /*  Debug.Log("END");
        Debug.Log(Player.GetPlayer().MaxForwardMoveSpd);
        Debug.Log(BefMaxbac = Player.GetPlayer().MaxBackMoveSpd);
        Debug.Log(BefAcc = Player.GetPlayer().AccelateSpd);*/

    }
}