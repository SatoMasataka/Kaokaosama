using UnityEngine;
using UnityEditor;

public class TimeBookEvent : IBookEvent
{

    public string GetTitle()
    {
        return "HGウェルズ『タイム・マシン』";
    }
    public string GetComment()
    {
        return "♪タイムマシンにお願い --残り時間+10--";
    }
    public float GetTermSec()
    {
        return 3f;
    }
    public string GetImgPath() {
        return "BookImg/time";
    }


    private float BefMaxFor;
    private float BefMaxbac;
    private float BefAcc;

    public void EventStart()
    {
        StageController.GetStartController().LeftTime+=10f;

    }
    public void EventEnd()
    {
     

    }
}