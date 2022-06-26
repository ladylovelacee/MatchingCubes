using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class StackIDHolder
{
    public static string Blue = "Blue";
    public static string Yellow = "Yellow";
    public static string Orange = "Orange";

    public static Dictionary<string, Color> HCBPanels = new Dictionary<string, Color>();

    private static string[] stackIDs = new string[]
    {
        "None",
        Blue,
        Yellow,
        Orange
    };

    public static List<string> StackIDs { get { return stackIDs.ToList(); } }
}
