using UnityEngine;

namespace Internal.Storage.Datas
{
    public sealed class ItemType : ScriptableObject
    {
        public Sprite Sprite;
        public uint StackSize;
        public string Name;
    }
}