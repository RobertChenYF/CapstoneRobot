using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;
using System.IO;
using UnityEditor;


public class UpdateLevel : Editor
{

    [MenuItem("Window/Level/UpdateLevel")]
    // Start is called before the first frame update
    static void LoadData()
    {
        string path = Application.dataPath + "/ExcelSheet/LevelList.xlsx";
        Excel mydata = ExcelHelper.LoadExcel(path);
        int i = 2;
        while (mydata.Tables[0].GetValue(i,1).ToString().Length > 0)
        {
            //instantiate empty game object
            int levelNumber =  int.Parse(mydata.Tables[0].GetValue(i, 1).ToString());
            string levelName = mydata.Tables[0].GetValue(i, 2).ToString();
            string[] levelSizeString = mydata.Tables[0].GetValue(i, 2).ToString().Split('x'); 
            GameObject WholeArea = new GameObject(levelNumber.ToString() + " " + levelName);
            
            if (levelSizeString.Length > 0)
            {
                 InstantiateFloor(1,1);
            }
            

            i++;
        }
        Debug.Log(mydata.Tables[0].GetValue(1, 1));
    }

    public static GameObject InstantiateFloor(int x, int y)
    {


        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
