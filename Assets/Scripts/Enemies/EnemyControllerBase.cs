using UnityEngine;
using System.Collections;

public class EnemyControllerBase : MonoBehaviour
{

    public enum Status
    {
        live, dead, reverse
    }

    protected Rigidbody rbody;
    public Status nowStatus { get; set; }

    protected virtual void Start()
    {
        this.rbody = GetComponent<Rigidbody>();
        this.nowStatus = Status.live;
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {

        this.AheadAction();

        if (transform.position.y < -3f)
        {
            Destroy(gameObject);
        }
    }

    protected void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.tag == "Player")
            this.OnAttackPlayer(new Vector3(0, 0, 6000));
        if (coll.gameObject.tag == "Weapon")
            this.OnAttackPlayer(new Vector3(0, 100, 4000));

        if (coll.gameObject.tag == "PlayerGoal")
            this.OnPlayerGoal();

        if (coll.gameObject.tag == "EnemyGoal")
            this.OnEnemyGoal();

        //死んでいる時に敵に当たっても失速しないようにする
        if (nowStatus == Status.dead && coll.gameObject.tag == "Enemy")
            this.rbody.AddForce(new Vector3(0, 0, 4000));

    }

    protected virtual float GetSpeed()
    {
        if (this._Speed <= 0)
            this._Speed = Random.Range(-30f, -5f);

        return this._Speed;
    }

    private float _Speed = 0;

    protected virtual void AheadAction()
    {
        if (nowStatus == Status.live)
        {
            this.rbody.AddForce(new Vector3(0, 0, this.GetSpeed()));
        }
        if (nowStatus == Status.reverse)
        {
            this.rbody.velocity = Vector3.zero;
            this.rbody.AddForce(new Vector3(0, 800, 0));
        }
    }

    /// <summary>
    /// プレイヤーや武器に当たった時
    /// </summary>
    protected void OnAttackPlayer(Vector3 addedVec)
    {
        this.rbody.AddForce(addedVec);
        this.nowStatus = Status.dead;
        this.tag = "Weapon";//自らが武器化
    }

    protected virtual void OnPlayerGoal()
    {
        Destroy(gameObject);
        StageController.GetStartController().increaseEnemyPoint(1);
    }

    protected virtual void OnEnemyGoal()
    {
        Destroy(gameObject);
        StageController.GetStartController().increasePlayerPoint(1);
    }


}
