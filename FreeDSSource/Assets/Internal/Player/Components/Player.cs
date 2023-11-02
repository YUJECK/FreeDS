using System;
using Internal.EntityBase.Interfaces;
using Internal.Player.Datas;
using UnityEngine;

namespace Internal.Player.Components
{
    public sealed class Player : MonoBehaviour, ILiveable
    {
        private int _health;
        
        public event Action OnDie;
        public event Action<int> OnHealthChange;

        public int Health
        {
            get => _health;
            set
            {
                OnHealthChange?.Invoke(value - _health);

                if (value <= 0)
                {
                    Died = true;
                    OnDie?.Invoke();
                    _health = 0;
                }
                else
                    _health = value;
            }
        }

        public int MaxHealth { get; private set; }
        public bool Died { get; private set; }

        public void SetCharacter(Character character)
        {
            MaxHealth = character.MaxHealth;
            _health = MaxHealth;
        }
    }
}