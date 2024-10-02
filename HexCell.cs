using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UI.GridLayoutGroup;

public class HexCell : MonoBehaviour
{

    [SerializeField]
    HexCell[] neighbors;//соседи

    public int elevation;//высота
    public const float elevationStep = 5f;//шаг высоты


    UnityEngine.Color TouchColor = UnityEngine.Color.red;
    public HexCoordinates coordinates;
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {
    }

    public HexCell GetNeighbor(HexDirection direction)  //получить соседей
    {
        return neighbors[(int)direction];   
    }
 
    public void SetNeighbor(HexDirection direction, HexCell cell)  //задание соседа
    {
        neighbors[(int)direction] = cell;
        cell.neighbors[(int)direction.Opposite()] = this; //дл€ противоположной клетки
    }



    public void MakeHex() {
        
        Vector3 Center = transform.position;

        MeshCollider collider = GetComponent<MeshCollider>();
        MeshFilter Mesh_Filter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Mesh_Filter.mesh = mesh;

        


        //вершины
        Vector3[] vert = new Vector3[18] {

            Center, new Vector3(), new Vector3() ,new Vector3() ,new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3()
            ,new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3()
        };

        //треугольники

        int[] tri = new int[21];

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

        // отображение текструры

            //......

        for (int i = 1; i < 7; i++) {
            vert[i] = Center+HexMetrics.corners[i]*HexMetrics.solidFactor;

            Debug.Log(vert[i]);
        }


        //получаем вершины 7-18:

        mesh.vertices = vert;
        mesh.triangles = tri;

        collider.sharedMesh = mesh;

    }


    public void MakeBridge() {  // создает мосты между клетками / вынести повтор€юшиес€ элементы из ф-ции выше в отдельныю функцию!!!!!!

        Vector3 Center = transform.position;

        MeshCollider collider = GetComponent<MeshCollider>();
        MeshFilter Mesh_Filter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Mesh_Filter.mesh = mesh;

        mesh.Clear();

        //вершины
        Vector3[] vert = new Vector3[18] {

            Center, new Vector3(), new Vector3() ,new Vector3() ,new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3()
            ,new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3(),new Vector3()
        };

        //треугольники

        int[] tri = new int[21];

        tri[0] = 0; tri[18] = 1;
        tri[1] = 1; tri[19] = 7;
        tri[2] = 2; tri[20] = 18;

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

        // отображение текструры

        //......

        for (int i = 1; i < 7; i++)
        {
            vert[i] = Center + HexMetrics.corners[i] * HexMetrics.solidFactor;

            Debug.Log(vert[i]);
        }


        //получаем вершины 7-18:

        int v1 = 3; //id вершины в corners
        int v2 = 4;

        for (int i = 7; i < 18; i += 2)
        {

            //Vector3 NeighborCenter = new Vector3();
            Vector3 NeighborCenter = neighbors[0].transform.position;

            for (int k = 0; k < 5; k++)
            {

                if (v1 == 5) { v1 = 0; }
                if (v2 == 5) { v2 = 0; }


                vert[i] = NeighborCenter + HexMetrics.corners[v1] * HexMetrics.solidFactor;
                vert[i + 1] = NeighborCenter + HexMetrics.corners[v2] * HexMetrics.solidFactor;

            }
        }

        //получаем вершины 7-18:



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
