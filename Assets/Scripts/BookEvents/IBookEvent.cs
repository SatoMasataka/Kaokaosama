using UnityEngine;
using UnityEditor;

public interface IBookEvent
{

    string GetTitle();

    string GetComment();
    float GetTermSec();
    string GetImgPath();
    void EventStart();
    void EventEnd();
}