using UnityEngine;

namespace App
{
    public static class SaveManager
    {
        public static void SaveValue(string key, object value)
        {
            Debug.Log($"{key}: {value} was saved!");
        }
    }
}