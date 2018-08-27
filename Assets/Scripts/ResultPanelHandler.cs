using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResultPanelHandler : MonoBehaviour
{
    public UnityEngine.UI.Text ResultText;
    void Start()
    {
       
    }

    void Update()
    {
       
    }

    public void OnResetClick()
    { 
        SceneManager.LoadScene(0);
    }
}