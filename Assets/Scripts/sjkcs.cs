using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sjkcs : MonoBehaviour
{
    public static readonly String dbUser = Environment.GetEnvironmentVariable("LAB_DB_USER") ?? "";
    public static readonly String dbPassword = Environment.GetEnvironmentVariable("LAB_DB_PASSWORD") ?? "";
    public static String dbstr = $"Server=127.0.0.1;port=3306;Database=lab;charset=utf8mb3;user={dbUser};password={dbPassword};SslMode=None;";
    public static String server = "127.0.0.1";
    public static String port = "3306";
}
