using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItem : Item
{
    /*public enum eNormalType
    {
        NORMAL_TYPE_ONE,
        NORMAL_TYPE_TWO,
        NORMAL_TYPE_THREE,
        NORMAL_TYPE_FOUR,
        NORMAL_TYPE_FIVE,
        NORMAL_TYPE_SIX,
        NORMAL_TYPE_SEVEN
    }

    public eNormalType ItemType;

    public void SetType(eNormalType type)
    {
        ItemType = type;
    }*/

    protected override string GetPrefabName()
    {
        string prefabname = string.Empty;
        switch (ItemType)
        {
            case eItemType.NORMAL_TYPE_ONE:
                prefabname = Constants.PREFAB_NORMAL_TYPE_ONE;
                break;
            case eItemType.NORMAL_TYPE_TWO:
                prefabname = Constants.PREFAB_NORMAL_TYPE_TWO;
                break;
            case eItemType.NORMAL_TYPE_THREE:
                prefabname = Constants.PREFAB_NORMAL_TYPE_THREE;
                break;
            case eItemType.NORMAL_TYPE_FOUR:
                prefabname = Constants.PREFAB_NORMAL_TYPE_FOUR;
                break;
            case eItemType.NORMAL_TYPE_FIVE:
                prefabname = Constants.PREFAB_NORMAL_TYPE_FIVE;
                break;
            case eItemType.NORMAL_TYPE_SIX:
                prefabname = Constants.PREFAB_NORMAL_TYPE_SIX;
                break;
            case eItemType.NORMAL_TYPE_SEVEN:
                prefabname = Constants.PREFAB_NORMAL_TYPE_SEVEN;
                break;
        }

        return prefabname;
    }

    internal override bool IsSameType(Item other)
    {
        NormalItem it = other as NormalItem;

        return it != null && it.ItemType == this.ItemType;
    }
}
