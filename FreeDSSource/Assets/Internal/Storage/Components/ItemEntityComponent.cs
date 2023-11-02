using System;
using Internal.Storage.Datas;
using UnityEngine;

namespace Internal.Storage.Components
{
    public sealed class ItemEntityComponent : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private ItemContainer _item;
        
        public ItemContainer Item
        {
            get => _item;
            set
            {
                _item = value;
                _spriteRenderer.sprite = _item.Type!.Sprite;
            }
        }

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        
    }
}