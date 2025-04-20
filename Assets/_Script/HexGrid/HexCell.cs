using System;
using UnityEngine;



public class HexCell : MonoBehaviour
{


    public int elevation;
    public HexCoordinates coordinates;

    
    void Awake()
    {
        MakeCHex();
    }







    private void MakeCHex()   //создание гекса
    {
        Vector3 Center = transform.InverseTransformPoint(transform.position);
        Console.Write(Center);
        //Console.WriteLine("1234421");
        //Console.WriteLine(Center.x);
        MeshCollider collider = GetComponent<MeshCollider>();
        MeshFilter Mesh_Filter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Mesh_Filter.mesh = mesh;
        mesh.Clear();

        Vector3[] vert = new Vector3[8] {
            Center, new Vector3(), new Vector3() ,new Vector3() ,new Vector3(),new Vector3(),new Vector3(),new Vector3(),
        };
        
        
        int[] tri = new int[18];

        tri[0] = 0;     tri[9] = 0;
        tri[1] = 1;     tri[10] = 4;
        tri[2] = 2;     tri[11] = 5;

        tri[3] = 0;     tri[12] = 0;
        tri[4] = 2;     tri[13] = 5;
        tri[5] = 3;     tri[14] = 6;

        tri[6] = 0;     tri[15] = 0;
        tri[7] = 3;     tri[16] = 6;
        tri[8] = 4;     tri[17] = 1;
      

        for (int i = 1; i < 7; i++) {
            vert[i] = Center+HexMetrics.corners[i];
        }


        

        mesh.vertices = vert;
        mesh.triangles = tri;
        Console.WriteLine(Center);
        //collider.sharedMesh = mesh;

    }

    void Update()
    {
       
    }


}

