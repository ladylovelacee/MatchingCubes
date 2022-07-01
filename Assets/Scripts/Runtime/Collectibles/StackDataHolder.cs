using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StackDataHolder", menuName = "ScriptableObjects/StackDataHolder", order = 2)]
public class StackDataHolder : ScriptableObject
{
    public List<StackData> StackDatas = new List<StackData>();
    public StackTweenData StackTweenData = new StackTweenData();

    public Color GetColorByID(string ID)
    {
        Color color = Color.black;

        for (int i = 0; i < StackDatas.Count; i++)
        {
            if (StackDatas[i].StackID == ID)
                color = StackDatas[i].StackColor;
        }

        return color;
    }
}

[Serializable]
public class StackData
{
    public string StackID;
    public Color StackColor;
}

[Serializable]
public class StackTweenData
{
    [Header("Punch Tween Values")]
    public float Punch = .2f;
    public float Duration = .5f;

    [Header("Melt Tween Values")]
    public float MeltDuration = 1f;
}