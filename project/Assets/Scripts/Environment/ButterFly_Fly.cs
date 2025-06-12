using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;


public class ButterFly_Fly : MonoBehaviour
{

    public PathCreator path;
    public float MoveSpeed;
    [Tooltip("达到终点后的后续移动模式")]
    public EndOfPathInstruction MovementMode = EndOfPathInstruction.Stop;
    [Tooltip("旋转校正")]
    public Vector3 AdjustVector = new Vector3(0, 90, -90);

    protected float _travelled;
    protected Vector3 _oldPostion = new Vector3(-1,-1,-1);



    // Update is called once per frame
    void Update()
    {
        _travelled += MoveSpeed * Time.deltaTime;
        _oldPostion = transform.position;
        transform.position = path.path.GetPointAtDistance(_travelled, MovementMode);

        //如果在这，说明到达了终点
        if (transform.position == _oldPostion)
        {
            Destroy(this.gameObject);
        }

        transform.rotation = path.path.GetRotationAtDistance(_travelled, MovementMode);
        transform.rotation *= Quaternion.AngleAxis(AdjustVector.x, Vector3.up);
        transform.rotation *= Quaternion.AngleAxis(AdjustVector.y, Vector3.left);
        transform.rotation *= Quaternion.AngleAxis(AdjustVector.z, Vector3.forward);
    }
}
