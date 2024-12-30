using System;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UI.GridLayoutGroup;

using System.Collections;
public class HexCell : MonoBehaviour
{

    [SerializeField]
    HexCell[] neighbors;//������

    public int elevation;//������
    public const float elevationStep = 5f;//��� ������


    UnityEngine.Color TouchColor = UnityEngine.Color.red;
    public HexCoordinates coordinates;
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetElevation(int elv)
    {
        elevation = elv;
        transform.Translate(0,elevation,0);
        MakeBridge();

    }
    public HexCell GetNeighbor(HexDirection direction)  //�������� �������
    {
        return neighbors[(int)direction];   
    }
 
    public void SetNeighbor(HexDirection direction, HexCell cell)  //������� ������
    {
        neighbors[(int)direction] = cell;
        cell.neighbors[(int)direction.Opposite()] = this; //��� ��������������� ������
    }

    public void TestFunc()
    {
        for(int i = 0; i < 6; i++)
        {

            //neighbors[0];
            Debug.Log(neighbors[0]);
        }


    }

    public void MakeHex() {
        
        Vector3 Center = transform.position;

        MeshCollider collider = GetComponent<MeshCollider>();
        MeshFilter Mesh_Filter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Mesh_Filter.mesh = mesh;
        mesh.Clear();




        //�������
        Vector3[] vert = new Vector3[18] {

            Center, new Vector3(), new Vector3() ,new Vector3() ,new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3()
            ,new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3()
        };
        
        //������������

        int[] tri = new int[18];

        tri[0] = 0; 
        tri[1] = 1; 
        tri[2] = 2; 

        tri[3] = 0;
        tri[4] = 2;
        tri[5] = 3;

        tri[6] = 0;
        tri[7] = 3;
        tri[8] = 4;

        tri[9] = 0;
        tri[10] = 4;
        tri[11] = 5;

        tri[12] = 0;
        tri[13] = 5;
        tri[14] = 6;

        tri[15] = 0;
        tri[16] = 6;
        tri[17] = 1;

        // ����������� ���������

            //......

        for (int i = 1; i < 7; i++) {
            vert[i] = Center+HexMetrics.corners[i]*HexMetrics.solidFactor;
        }


        //�������� ������� 7-18:

        mesh.vertices = vert;
        mesh.triangles = tri;

        //collider.sharedMesh = mesh;

    }


    public void MakeBridge()
    {  // ������� ����� ����� �������� / ������� ������������� �������� �� �-��� ���� � ��������� �������!!!!!!

        Vector3 Center = transform.position;

        MeshCollider collider = GetComponent<MeshCollider>();
        MeshFilter Mesh_Filter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Mesh_Filter.mesh = mesh;
        Bounds bounds = mesh.bounds;

        mesh.Clear();

        //�������
        Vector3[] vert = new Vector3[19] {

            Center, new Vector3(), new Vector3() ,new Vector3() ,new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3()
            ,new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3()
        };

        //������������

        int[] tri = new int[72];

       

        // ����������� ���������

        //......

        for (int i = 1; i < 7; i++)
        {
            vert[i] = Center + HexMetrics.corners[i] * HexMetrics.solidFactor;
        }


        //�������� ������� 7-18:

        //id ������� � corners
        Vector3 NeighborCenter = new Vector3();
        for (int neighbor_id = 0; neighbor_id < 6; neighbor_id++)
        {


            if (neighbors[neighbor_id] == null)
            {

                NeighborCenter = Center*2f;
            }
            else { NeighborCenter = neighbors[neighbor_id].transform.position*2f;}


            switch (neighbor_id)
            {
                case 0:
                    vert[7] = transform.InverseTransformPoint(NeighborCenter + HexMetrics.corners[3]* HexMetrics.solidFactor);
                    vert[8] = transform.InverseTransformPoint(NeighborCenter + HexMetrics.corners[4] * HexMetrics.solidFactor);
                    //vert[7] = transform.InverseTransformPoint(11.23f,-1.6f,8.6f);
                    //vert[8] = transform.InverseTransformPoint(NeighborCenter + HexMetrics.corners[4] * HexMetrics.solidFactor);
                    break;
                case 1:
                    vert[9] = transform.InverseTransformPoint(NeighborCenter + HexMetrics.corners[4]*HexMetrics.solidFactor);
                    vert[10] = transform.InverseTransformPoint(NeighborCenter + HexMetrics.corners[5]* HexMetrics.solidFactor);
                    break;
                case 2:
                    vert[11] = transform.InverseTransformPoint(NeighborCenter + HexMetrics.corners[5] * HexMetrics.solidFactor);
                    vert[12] = transform.InverseTransformPoint(NeighborCenter + HexMetrics.corners[6] * HexMetrics.solidFactor);
                    break;
                case 3:
                    vert[13] = transform.InverseTransformPoint(NeighborCenter + HexMetrics.corners[1] * HexMetrics.solidFactor);
                    vert[14] = transform.InverseTransformPoint(NeighborCenter + HexMetrics.corners[0] * HexMetrics.solidFactor);
                    break;
                case 4:
                    vert[15] = transform.InverseTransformPoint(NeighborCenter + HexMetrics.corners[2]* HexMetrics.solidFactor);
                    vert[16] = transform.InverseTransformPoint(NeighborCenter + HexMetrics.corners[1] * HexMetrics.solidFactor);
                    break;
                case 5:
                    vert[17] = transform.InverseTransformPoint(NeighborCenter + HexMetrics.corners[3] * HexMetrics.solidFactor);
                    vert[18] = transform.InverseTransformPoint(NeighborCenter + HexMetrics.corners[2] * HexMetrics.solidFactor);
                    break;
            }
            //Debug.Log(vert[7 + neighbor_id]);
            //Debug.Log(vert[7 + neighbor_id+1]);

            //Debug.Log(NeighborCenter);
        }

        //�������� ������� 7-18:


        tri[0] = 0; tri[18] = 6; tri[36] = 14; tri[54] = 6;
        tri[1] = 1; tri[19] = 8; tri[37] = 4; tri[55] = 18;
        tri[2] = 2; tri[20] = 7; tri[38] = 3; tri[56] = 8;

        tri[3] = 0; tri[21] = 7; tri[39] = 13; tri[57] = 7;
        tri[4] = 2; tri[22] = 1; tri[40] = 14; tri[58] = 10;
        tri[5] = 3; tri[23] = 6; tri[41] = 3; tri[59] = 1;

        tri[6] = 0; tri[24] = 10; tri[42] = 15; tri[60] = 12;
        tri[7] = 3; tri[25] = 2; tri[43] = 5; tri[61] = 2;
        tri[8] = 4; tri[26] = 1; tri[44] = 4; tri[62] =9;

        tri[9] = 0;  tri[27] = 9; tri[45] = 16; tri[63] = 13;
        tri[10] = 4; tri[28] = 2; tri[46] = 5; tri[64] = 3;
        tri[11] = 5; tri[29] = 10; tri[47] = 15; tri[65] = 11;

        tri[12] = 0; tri[30] = 2; tri[48] = 6; tri[66] = 15;
        tri[13] = 5; tri[31] = 12; tri[49] = 5; tri[67] = 4;
        tri[14] = 6; tri[32] = 11; tri[50] = 18; tri[68] = 14;

        tri[15] = 0; tri[33] = 2; tri[51] = 5; tri[69] = 17;
        tri[16] = 6; tri[34] = 11; tri[52] = 17; tri[70] = 5;
        tri[17] = 1; tri[35] = 3; tri[53] = 18; tri[71] = 16;
       

        mesh.vertices = vert;
        mesh.triangles = tri;
        collider.sharedMesh = mesh;


    }

    public void SwithColor() {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = TouchColor;
        //rend.material.shader = Shader.Find("Specular");
        //rend.material.SetColor("_SpecColor", UnityEngine.Color.red);


    }

}
