using UnityEngine;
using UnityEditor;

public class KumoBookEvent : IBookEvent
{

    public string GetTitle()
    {
        return "芥川龍之介『蜘蛛の糸』";
    }
    public string GetComment()
    {
        return "カンダタ達が蜘蛛の糸を登ってゆく…";
    }
    public float GetTermSec()
    {
        return 3f;
    }
    public string GetImgPath() {
        return "BookImg/kumo";
    }

    public void EventStart()
    {
        foreach (GameObject en in GameObject.FindGameObjectsWithTag("Enemy")) {
            en.GetComponent<EnemyControllerBase>().nowStatus = EnemyControllerBase.Status.reverse;
        }
            
    }





public void EventEnd()
    {
        foreach (GameObject en in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            en.GetComponent<EnemyControllerBase>().nowStatus = EnemyControllerBase.Status.live;
        }

    }
}