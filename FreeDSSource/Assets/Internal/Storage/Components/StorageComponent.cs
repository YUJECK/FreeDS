using System;
using Internal.Storage.Datas;
using UnityEngine;

namespace Internal.Storage.Components
{
    public sealed class StorageComponent : MonoBehaviour
    {
        public ItemContainer[] Items { get; private set; }

        public void SetSize(int newSize)
        {
            var items = Items;
            Array.Resize(ref items, newSize);
            Items = items;
        }

        public void Add(ItemContainer item)
        {
            foreach (var itemContainer in Items)
            {
                itemContainer.TryMoveTo(itemContainer);
            }
        }
    }
}