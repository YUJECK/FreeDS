namespace Internal.Storage.Datas
{
    public sealed class ItemContainer
    {
        public ItemType? Type;
        public uint Count { get; private set; }

        public bool TryMoveTo(ItemContainer to)
        {
            if (to.Type != null && to.Type != Type)
                return false;

            Count = to.Add(Count);

            if (Count == 0)
                Type = null;

            return true;
        }

        // Возвращает сколько было добавлено
        public uint Add(uint count)
        {
            var newCount = count + Count;
            uint extra = 0;

            if (newCount > Type!.StackSize)
            {
                extra = newCount - Type!.StackSize;
                newCount = Type!.StackSize;
            }

            count = newCount;
            
            return count - extra;
        }

        public bool TryGet(uint count)
        {
            if (Count < count)
                return false;

            Count -= count;

            if (Count == 0)
                Type = null;

            return true;
        }
    }
}