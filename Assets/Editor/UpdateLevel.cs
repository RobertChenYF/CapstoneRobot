using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;
using System.IO;
using UnityEditor;


public class UpdateLevel : Editor
{
    private static GameObject scifiFloor;
    public static List<string> PuzzleElementName = new List<string>{"Button", "Gate", "Scanner"};
    public static List<GameObject> PuzzleElementPrefabs = new List<GameObject>();
    [MenuItem("Window/Level/GenerateLevel")]
    // Start is called before the first frame update
     static void LoadData()
    {
        string path = Application.dataPath + "/ExcelSheet/LevelList.xlsx";
        Excel mydata = ExcelHelper.LoadExcel(path);
        int i = 2;
        scifiFloor = Resources.Load("Prefabs/ScifiFloor") as GameObject;

        foreach (string name in PuzzleElementName)
        {
            PuzzleElementPrefabs.Add(Resources.Load("Prefabs/" + name) as GameObject);

        }

        while (mydata.Tables[0].GetValue(i,1).ToString().Length > 0)
        {
            //instantiate empty game object
            int levelNumber =  int.Parse(mydata.Tables[0].GetValue(i, 1).ToString());
            string levelName = mydata.Tables[0].GetValue(i, 2).ToString();
            string[] levelSizeString = mydata.Tables[0].GetValue(i, 3).ToString().Split('x'); 
            GameObject WholeArea = new GameObject(levelNumber.ToString() + " " + levelName);
            //Debug.Log(WholeArea);
            
            if (levelSizeString.Length == 2)
            {
                GameObject Floors =  InstantiateFloor(int.Parse(levelSizeString[0]),int.Parse(levelSizeString[1]));
                Floors.transform.SetParent(WholeArea.transform);
            }
            

            int column = 6;
            GameObject PuzzleElements = new GameObject("PuzzleElements");
            PuzzleElements.transform.SetParent(WholeArea.transform);
            while (mydata.Tables[0].GetValue(i, column).ToString().Length > 0)
            {
                InstantiatePuzzleElements(mydata.Tables[0].GetValue(i, column).ToString()).transform.SetParent(PuzzleElements.transform);
                column++;
            }

            WholeArea.transform.position = new Vector3(0, 0, (i - 2) * 16);
            i++;
        }
       
    }

    public static GameObject InstantiatePuzzleElements(string name)
    {
        GameObject element = null;
        if (PuzzleElementName.IndexOf(name) >=0)
        {
            element = PrefabUtility.InstantiatePrefab(PuzzleElementPrefabs[PuzzleElementName.IndexOf(name)] as GameObject) as GameObject;
        }
        

        return element;
    }

    public static GameObject InstantiateFloor(int x, int y)
    {
        GameObject WholeFloor = new GameObject("Floors");

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j ++)
            {
                GameObject temp = PrefabUtility.InstantiatePrefab(scifiFloor as GameObject) as GameObject;
                temp.transform.SetParent(WholeFloor.transform);
                temp.transform.position = new Vector3(i*4,0,j*4);
            }
        }

        return WholeFloor;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
