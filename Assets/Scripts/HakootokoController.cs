using UnityEngine;
using System.Collections;

/// <summary>
/// 箱男
/// </summary>
public class HakootokoController : MonoBehaviour {
    private float time { get; set; }
    protected  void Start()
    {
        time = 0;

    }
    protected void FixedUpdate()
    {
        time += Time.deltaTime;

        if(time > 2f)
            this.transform.Rotate(new Vector3(0, 1, 0), 20);
        if (time > 6f)
            Destroy(gameObject);
    }




}
