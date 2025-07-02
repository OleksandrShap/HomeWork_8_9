using System;
using UnityEngine;

public static class ViewManagerBas
{
    public static Action<int> OpenCanvas; 

    public static void CnangeNumberCanvas(int id)
    {
        OpenCanvas?.Invoke(id);
    }
}
