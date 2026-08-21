using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;
using Imdork.Mysql;
using System;

public class chart : MonoBehaviour
{
    public GameObject sy, dt,sypq;
    void Start()
    {
        //创建数据库类                 IP地址       端口    用户名   密码     数据库项目名称
        var mySqlTools = new SqlHelper(sjkcs.server, sjkcs.port, sjkcs.dbUser, sjkcs.dbPassword, "lab");
        mySqlTools.Open();
        var a = mySqlTools.ExecuteQuery("SELECT  COUNT(*)  FROM  students  WHERE  score  BETWEEN  0  AND  29;");
        var b = mySqlTools.ExecuteQuery("SELECT  COUNT(*)  FROM  students  WHERE  score  BETWEEN  30  AND  59;");
        var c = mySqlTools.ExecuteQuery("SELECT  COUNT(*)  FROM  students  WHERE  score  BETWEEN  60  AND  89;");
        var d = mySqlTools.ExecuteQuery("SELECT  COUNT(*)  FROM  students  WHERE  score  BETWEEN  90  AND  100;");

        String i = (MysqlTools.GetValue(a, "COUNT(*)")).ToString();
        String i1 = (MysqlTools.GetValue(b, "COUNT(*)")).ToString();
        String i2 = (MysqlTools.GetValue(c, "COUNT(*)")).ToString();
        String i3 = (MysqlTools.GetValue(d, "COUNT(*)")).ToString();
        //print(i);
        mySqlTools.Close();
        //代码动态添加图表需要设置尺寸
        var chart = gameObject.GetComponent<PieChart>();
        if (chart == null)
        {
            chart = gameObject.AddComponent<PieChart>();
            chart.SetSize(580, 300);//代码动态添加图表需要设置尺寸
        }

        //设置标题：
        chart.title.show = true;
        chart.title.text = "答题成绩分布";

        //设置提示框和图例是否显示
        chart.tooltip.show = true;
        chart.legend.show = true;

        //设置是否使用双坐标轴和坐标轴类型
        /*chart.xAxes[0].show = true;
        chart.xAxes[1].show = false;
        chart.yAxes[0].show = true;
        chart.yAxes[1].show = false;
        chart.xAxes[0].type = Axis.AxisType.Category;
        chart.yAxes[0].type = Axis.AxisType.Value;

        //设置坐标轴分割线
        chart.xAxes[0].splitNumber = 10;
        chart.xAxes[0].boundaryGap = true;*/

        //清空数据，添加`Line`类型的`Serie`用于接收数据
        //chart.RemoveData();
        //chart.AddSerie(SerieType.Pie);

        //添加10个数据
        /*for (int i = 0; i < 10; i++)
        {
            chart.AddXAxisData("x" + i);
            chart.AddData(0, Random.Range(10, 20));
        }*/

        //修改第3个数据
        chart.UpdateData(0, 0, Convert.ToDouble(i));
        chart.UpdateData(0, 1, Convert.ToDouble(i1));
        chart.UpdateData(0, 2, Convert.ToDouble(i2));
        chart.UpdateData(0, 3, Convert.ToDouble(i3));

    }
    public void dtqiehuan()
    {
        dt.gameObject.SetActive(false);
        sy.gameObject.SetActive(true);
        sypq.gameObject.SetActive(false);
    }
    public void syqiehuan()
    {
        dt.gameObject.SetActive(true);
        sy.gameObject.SetActive(false);
        sypq.gameObject.SetActive(false);
    }
    public void sypqqiehuan()
    {
        dt.gameObject.SetActive(false);
        sy.gameObject.SetActive(false);
        sypq.gameObject.SetActive(true);
    }
}