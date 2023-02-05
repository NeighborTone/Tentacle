using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    public float rotaSpeed = 20;
    private Vector2 direction;
    [SerializeField] private Camera cameraMain;
    public float moveSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        direction = transform.position - cameraMain.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var rota = Quaternion.AngleAxis(angle, Vector3.forward);

        //スプライトが上むいているときの処理
        //横向きならいらない
        // var e = rota.eulerAngles;
        // e.z -= 90;
        // rota.eulerAngles = e;

        transform.rotation = Quaternion.Slerp(transform.rotation, rota, rotaSpeed * Time.deltaTime);

        var cursorPos = cameraMain.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position,cursorPos, moveSpeed * Time.deltaTime);
    }
}
