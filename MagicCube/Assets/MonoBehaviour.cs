using UnityEngine;
using System.Collections;

public class RotateTest : MonoBehaviour
{
    public static Vector3 RotateRound(Vector3 position, Vector3 center, Vector3 axis, float angle)
    {
        Vector3 point = Quaternion.AngleAxis(angle, axis) * (position - center);
        Vector3 resultVec3 = center + point;
        return resultVec3;
    }

    public LineRenderer line1;
    public LineRenderer line2;
    public float angle = 30f;

    private Vector3 v0;
    private Vector3 v1;
    private Vector3 v2;
    private Vector3 v3;
    private Vector3 v4;
    private Vector3 vCenter;
    void Start()
    {
        v0 = new Vector3(3f, 0f, 1f);
        v1 = new Vector3(1f, 0f, 3f);
        v2 = new Vector3(4f, 0f, 6f);
        v3 = new Vector3(6f, 0f, 4f);
        vCenter = new Vector3(2f, 0f, 2f);
    }

    // Use this for initialization
    void Update()
    {
        line1.SetVertexCount(5);
        line1.SetPosition(0, v0);
        line1.SetPosition(1, v1);
        line1.SetPosition(2, v2);
        line1.SetPosition(3, v3);
        line1.SetPosition(4, v0);

        line2.SetVertexCount(5);
        Vector3 v01 = RotateRound(v0, vCenter, Vector3.up, angle);
        Vector3 v11 = RotateRound(v1, vCenter, Vector3.up, angle);
        Vector3 v21 = RotateRound(v2, vCenter, Vector3.up, angle);
        Vector3 v31 = RotateRound(v3, vCenter, Vector3.up, angle);
        Vector3 v41 = RotateRound(v4, vCenter, Vector3.up, angle);
        line2.SetPosition(0, v01);
        line2.SetPosition(1, v11);
        line2.SetPosition(2, v21);
        line2.SetPosition(3, v31);
        line2.SetPosition(4, v01);
    }
}
