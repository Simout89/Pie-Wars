using UnityEngine;

public static class HexMetrics
{

    public const float elevationStep = 5f;//��� ������

    public const float outerRadius = 10f;
    public const float innerRadius = outerRadius * 0.866025404f;

    public const float solidFactor = 0.75f;//��������(��������)/���� �������� �������
    public const float blendFactor = 1f - solidFactor;//� ����� ����� 1

    public static Vector3[] corners = {
        new Vector3(0f, 0f, outerRadius),
        new Vector3(innerRadius, 0f, 0.5f* outerRadius),
        new Vector3(innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(0f, 0f, -outerRadius),
        new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(0f, 0f, outerRadius)
    };

    public static Vector3[] NeighborCenter = {
        new Vector3(innerRadius, 0f, outerRadius+0.5f*innerRadius),                //ne+
        new Vector3(2*innerRadius, 0f, 0),//e+
        new Vector3(innerRadius, 0f, (outerRadius+0.5f*innerRadius)*-1f),//se+
        new Vector3(innerRadius*-1, 0f, (outerRadius+0.5f*innerRadius)*-1),                  //sw+
        new Vector3(-2*innerRadius, 0f, 0),//w+
        new Vector3(innerRadius*-1, 0f, outerRadius+0.5f*innerRadius),//nw+
    };

    public static Vector3 GetFirstSolidCorner(HexDirection direction)
    {
        return corners[(int)direction] * solidFactor;
    }

    public static Vector3 GetSecondSolidCorner(HexDirection direction)
    {
        return corners[(int)direction + 1] * solidFactor;
    }

    

}