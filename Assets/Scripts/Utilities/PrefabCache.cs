using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class PrefabCache
    {
        private static readonly Dictionary<string, GameObject> Cache = new Dictionary<string, GameObject>();

        public static GameObject Load(string path)
        {
            if (Cache.TryGetValue(path, out var prefab))
                return prefab;

            prefab = Resources.Load<GameObject>(path);
            if (prefab != null)
            {
                Cache[path] = prefab;
            }

            return prefab;
        }
    }
}