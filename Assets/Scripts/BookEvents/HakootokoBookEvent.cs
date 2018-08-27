using UnityEngine;
using UnityEditor;

public class HakootokoBookEvent : IBookEvent
{
    private MonoBehaviour Mb;


    public string GetTitle()
    {
        return "安部公房『箱男』";
    }
    public string GetComment()
    {
        return "箱男参上！(安部先生ご乱心)";
    }
    public float GetTermSec()
    {
        return 3f;
    }
    public string GetImgPath()
    {
        return "BookImg/hako";
    }


    public void EventStart()
    {
        GameObject rs = (GameObject)Resources.Load("Prefabs/Hakootoko");
        MonoBehaviour.Instantiate(rs,new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0.33f, UnityEngine.Random.Range(5.0f, 70.0f)),rs.transform.rotation);
    }
    public void EventEnd()
    {


    }
}