using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    [System.Serializable]
    public struct SpriteEntry
    {
        public Item.eItemType type;
        public Sprite sprite;
    }

    public List<SpriteEntry> items;

    private Dictionary<Item.eItemType, Sprite> _lookup;

    public Sprite GetSprite(Item.eItemType type)
    {
        if (_lookup == null)
        {
            _lookup = new Dictionary<Item.eItemType, Sprite>();
            foreach (var entry in items)
            {
                _lookup[entry.type] = entry.sprite;
            }
        }

        return _lookup.TryGetValue(type, out var sprite) ? sprite : null;
    }
}