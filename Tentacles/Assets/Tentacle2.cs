using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle2 : MonoBehaviour
{
    public int length;
    public LineRenderer line;
    private Vector3[] segmentPoses;
    private Vector3[] segmentV;
    public Transform targetDir;
    public float targetDist; //点と点の間隔。小さいほど短い線になる
    public float smoothSpeed;//移動が止まったときにどれくらい動かすか

    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;

    //public Transform tailEnd;

    public Transform[] bodyParts;

    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    // Update is called once per frame
    void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPoses[0] = targetDir.position;
        for(int i = 1; i < segmentPoses.Length; ++i)
        {
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);

            if (bodyParts[i - 1] != null)
            {
                bodyParts[i - 1].position = segmentPoses[i];
            }
        }
        line.SetPositions(segmentPoses);

        //tailEnd.position = segmentPoses[segmentPoses.Length - 1];
    }
}
