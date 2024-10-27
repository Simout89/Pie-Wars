using System.Linq;
using UnityEngine;
 

public class Hex : MonoBehaviour
{

    public int width = 6;
    public int height = 6;

    public HexCell cellPrefab;

    public HexCell[] cells;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            //Debug.Log("1");
            TouchCell(hit.point);
        }
    }

    void TouchCell(Vector3 position)
    {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        Debug.Log("touched at " + coordinates.ToString());
        int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
        HexCell cell = cells[index];
        cell.SwithColor();
    }

    void Awake()
    {
        cells = new HexCell[height * width];

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
        }

        for(int i = 0; i < cells.Count();i++) { 
            cells[i].MakeBridge();
        }

        cells[9].SetElevation(4);
        cells[3].SetElevation(-2);
    }

    void CreateCell(int x, int z, int i)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius );
        position.y = 0f;
        //position.z = z * (HexMetrics.outerRadius);
        position.z = z * (HexMetrics.innerRadius * 1f-HexMetrics.innerRadius/7.4f);//костыль, доработать.(клетки не в плотную по y)
        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.MakeHex();
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
        //создаем связи между клетками
        if (x > 0)
        {
            cell.SetNeighbor(HexDirection.W, cells[i - 1]);
        }
        if (z > 0)
        {
            if ((z & 1) == 0)
            {
                cell.SetNeighbor(HexDirection.SE, cells[i - width]);
                if (x > 0)
                {
                    cell.SetNeighbor(HexDirection.SW, cells[i - width - 1]);
                }
            }
            else
            {
                cell.SetNeighbor(HexDirection.SW, cells[i - width]);
                if (x < width - 1)
                {
                    cell.SetNeighbor(HexDirection.SE, cells[i - width + 1]);
                }
            }
        }



        //cell.TestFunc();
        
        //
    }
}
