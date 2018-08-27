using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class Player : MonoBehaviour
{
    public  float MaxForwardMoveSpd = 0.2f;
    public  float MaxBackMoveSpd = -0.2f;
    public  float AccelateSpd = 0.01f;


    public float nowSpeed { get; set; }

    private CharacterController playerController;
    private Animator playerAnimator;

    // Use this for initialization
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
        nowSpeed = 0;

    }

    void FixedUpdate()
    {

        //速度値
        //バックのときは速度落ちる
        if (Input.GetAxis("Accel") > 0 && nowSpeed <= MaxForwardMoveSpd)
        {
            nowSpeed += AccelateSpd;
        }
        else if (Input.GetAxis("Accel") < 0 && nowSpeed >= MaxBackMoveSpd)
        {
            nowSpeed -= AccelateSpd;
        }
        else if (Input.GetAxis("Accel") == 0)
        {
            nowSpeed += (nowSpeed > 0) ? -AccelateSpd * 0.8f : AccelateSpd * 0.8f;

            //閾値を決めて0にしないと微妙に動き続ける
            if (Mathf.Abs(nowSpeed) < Mathf.Abs(MaxBackMoveSpd * 0.3f))
            {
                nowSpeed = 0;
            }
        }

      

        //カーブ値
        //前後移動なしでの方向転換不可
        //float dirX = (Input.GetAxis ("Accel") != 0) ? Input.GetAxis ("Horizontal") * TurnSpd : 0;

        //重力値
        float dirY = 0;
        dirY += 8 * Physics.gravity.y * Time.deltaTime;
        

        //方向転換・移動処理
        //transform.Rotate (new Vector3(0,dirX,0));
        playerController.Move(transform.forward * nowSpeed + new Vector3(0, dirY, 0));



        //アニメーション
        float animSpd = 0;
        if (Input.GetAxis("Accel") != 0)
        {
            animSpd = (Input.GetAxis("Accel") > 0) ? 1 : -1;
        }
        playerAnimator.SetFloat("Speed", animSpd);
    }

    /// <summary>
    /// 外から拾う用
    /// </summary>
    /// <returns></returns>
    public static Player GetPlayer()
    {
        GameObject sCon = GameObject.FindGameObjectsWithTag("Player")[0];
        return sCon.GetComponents<Player>()[0];
    }
}
