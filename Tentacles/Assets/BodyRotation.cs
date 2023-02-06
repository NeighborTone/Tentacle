using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    public float speed = 10;

    private Vector2 direction;

    public Transform target;

    [SerializeField] private bool isUp = false;

    // Update is called once per frame
    void Update()
    {
        direction = target.position - transform.position;
        var angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
        var rota = Quaternion.AngleAxis(angle,Vector3.forward);

        //スプライトが上むいているときの処理
        //横向きならいらない
        if (isUp)
        {
            var e = rota.eulerAngles;
            e.z -= 90;
            rota.eulerAngles = e;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, rota, speed * Time.deltaTime);   
    }
}
