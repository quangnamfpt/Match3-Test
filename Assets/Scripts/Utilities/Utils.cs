using System;
using System.Collections.Generic;
using System.Linq;
using URandom = UnityEngine.Random;

namespace Utilities
{
    public class Utils
    {
        public static List<Item.eItemType> GetAllNormalTypes()
        {
            return Enum.GetValues(typeof(Item.eItemType))
                .Cast<Item.eItemType>()
                .Where(t => t.ToString().StartsWith("NORMAL_TYPE"))
                .ToList();
        }

        public static Item.eItemType GetRandomNormalType()
        {
            var normalTypes = GetAllNormalTypes();
            var index = URandom.Range(0, normalTypes.Count);
            return normalTypes[index];
        }

        public static Item.eItemType GetRandomNormalTypeExcept(Item.eItemType[] excludedTypes)
        {
            var normalTypes = GetAllNormalTypes()
                .Except(excludedTypes)
                .ToList();

            if (normalTypes.Count == 0)
            {
                return GetRandomNormalType();
            }

            var index = URandom.Range(0, normalTypes.Count);
            return normalTypes[index];
        }
    }
}
