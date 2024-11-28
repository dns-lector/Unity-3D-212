
using System;
using System.Collections.Generic;

public class GameState
{
    public static bool isDay { get; set; }
    public static bool isFpv { get; set; }

    public static float effectsVolume { get; set; } = 1f;

    #region Change Notifier
    private static Dictionary<String, List<Action<string>>> changeListeners = new();
    public static void AddChangeListener(Action<string> listener, String name)
    {
        if ( ! changeListeners.ContainsKey(name))
        {
            changeListeners[name] = new List<Action<string>>();
        }
        changeListeners[name].Add(listener);
    }
    public static void RemoveChangeListener(Action<string> listener, String name)
    {
        if (changeListeners.ContainsKey(name))
        {
            changeListeners[name].Remove(listener);
        }
    }
    private static void NotifyListeners(String name)
    {
        if (changeListeners.ContainsKey(name))
        {
            foreach (var action in changeListeners[name])
            {
                action(name);
            }
        }
    }
    #endregion

    #region collectSubscribers
    private static List<Action<String>> collectSubscribers = new List<Action<String>>();
    public static void AddCollectListener(Action<String> subscriber)
    {
        collectSubscribers.Add(subscriber);
    }
    public static void RemoveCollectListener(Action<String> subscriber)
    {
        collectSubscribers.Remove(subscriber);
    }
    public static void Collect(String itemName)
    {
        collectSubscribers.ForEach(s => s(itemName));
    }
    #endregion
}
