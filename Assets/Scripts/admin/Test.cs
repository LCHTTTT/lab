using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.TableUI;

public class Test : MonoBehaviour
{
    public Button Button_PageUp;
    public Button Button_PageDown;
    public TableUI TableUIs;

    //从数据库读取的数据
    private DataTable DT;
    //每页的行数
    private int RowsOfPage = 5;
    //总页数
    private int TotalPages = 0;
    //当前的页数
    private int Page = 1;
    //最后一页会空多少行
    private int Remainder;

    void Start()
    {
        Button_PageUp.onClick.AddListener(OnClick_PageUp);
        Button_PageDown.onClick.AddListener(OnClick_PageDown);

        string sql = "SELECT id as 序号,number as 用户名,score as 答题成绩,syscore as 排水法实验成绩,syscorepq as 排气法实验成绩  FROM students ";
        DataSet dataSet = MySqlHelper.GetDataSet(sql);
        DT = dataSet.Tables[0];
        if (DT.Rows.Count > 0)
        {
            Debug.Log("总长度：" + DT.Rows.Count);

            TotalPages = (DT.Rows.Count + RowsOfPage - 1) / RowsOfPage;
            Debug.Log("总页数：" + TotalPages);

            Remainder = DT.Rows.Count % RowsOfPage;
            if (Remainder > 0) Remainder -= 1;
            Debug.Log("余数：" + Remainder);

            //显示列名
            for (int i = 0; i < DT.Columns.Count; i++)
            {
                string title = DT.Columns[i].ColumnName;
                TableUIs.GetCell(0, i).text = title;
            }

            ShowTable(DT, Page);
        }
    }


    private void OnClick_PageUp()
    {
        if (Page - 1 <= 0) return;

        Page--;
        ShowTable(DT, Page);
    }


    private void OnClick_PageDown()
    {
        try { 
        if (Page + 1 > TotalPages) return;

        Page++;
        ShowTable(DT, Page);
        }
        catch
        {

        }
    }


    private void ShowTable(DataTable dt, int page)
    {
        if (dt == null)
        {
            Debug.Log("DataTable 不能为空");
            return;
        }
        if (page <= 0 || page > TotalPages)
        {
            Debug.Log("页数超出了范围");
            return;
        }

        //清空表格
        for (int i = 1; i <= RowsOfPage; i++)
        {
            for (int j = 0; j < RowsOfPage-1; j++)
            {
                //Debug.Log(TableUIs.GetCell(i, j).text);
                TableUIs.GetCell(i, j).text = string.Empty;
            }
        }

        int end = page * RowsOfPage;
        int start = end - RowsOfPage;

        if (page == TotalPages)
            end = end - Remainder;

        int row = 0;
        for (int i = start; i < end; i++)
        {
            DataRow dr = DT.Rows[i];
            row++;
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                TableUIs.GetCell(row, j).text = dr[j].ToString();
            }
        }
    }


    private void OnDestroy()
    {
        Button_PageUp.onClick.RemoveAllListeners();
        Button_PageDown.onClick.RemoveAllListeners();
    }

}