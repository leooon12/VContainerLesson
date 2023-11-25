using UnityEngine;

namespace App
{
    public sealed class SaveManager
    {
        public void SaveValue(string key, object value)
        {
            Debug.Log($"{key}: {value} was saved!");
        }
    }
}