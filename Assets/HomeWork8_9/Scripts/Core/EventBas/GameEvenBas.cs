using System;
using UnityEngine;

public static class GameEvenBas
{
    public static event Action<int> OnDistanceChange;
    public static event Action<int> OnCoinCountChanged;

    public static void ChangeDistance(int newDistance)
    {
        OnDistanceChange?.Invoke(newDistance);
    }

    public static void ChangeCoinCount(int newCoinValue)
    {
        OnCoinCountChanged?.Invoke(newCoinValue);
    }
}
