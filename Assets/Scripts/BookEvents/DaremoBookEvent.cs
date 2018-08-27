using UnityEngine;
using UnityEditor;

public class DaremoBookEvent : IBookEvent
{

    public string GetTitle()
    {
        return "クリスティ『そして誰もいなくなった』";
    }
    public string GetComment()
    {
        return "♪十人の小さな兵隊さん --敵消滅--";
    }
    public float GetTermSec()
    {
        return 3f;
    }
    public string GetImgPath() {
        return "BookImg/daremo";
    }


    public void EventStart()
    {
        foreach (GameObject en in GameObject.FindGameObjectsWithTag("Enemy"))
            Object.Destroy(en);
    }
    public void EventEnd()
    {
       

    }
}