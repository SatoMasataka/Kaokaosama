using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartPanelHandler : MonoBehaviour
{
    public UnityEngine.UI.Text ResultText;

    void Start()
    {
       
    }

    void Update()
    {
       
    }

    public void OnStartClick()
    {
        StageController.GetStartController().IsPlaying = true;
        foreach (GameObject strPnl in GameObject.FindGameObjectsWithTag("StartPanel")) {
            Destroy(strPnl);
        } 
            
    }
}