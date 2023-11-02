using System;

namespace Internal.EntityBase.Interfaces
{
    public interface ILiveable
    {
        event Action OnDie;
        // передает изменение здоровья
        event Action<int> OnHealthChange;
        
        int Health { get; set; }
        int MaxHealth { get; }
        bool Died { get; } 
    }
}