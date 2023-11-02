

using UnityEngine;

namespace Internal.WorldBase
{
    public class BiomeGenerator
    {
        public Tile TestTile;

        private const int StepsCount = 100;
        
        public BiomeGenerator(Tile testTile)
        {
            TestTile = testTile;
        }

        public virtual void StartGenerate(World world)
        {
            Point current = new Point(0, 0);

            for (int i = 0; i < StepsCount; i++)
            {
                world.Map.AddTileAt(current, TestTile);
                current += GetRandomDirection(current, world);
            }
        }

        private Point GetRandomDirection(Point current, World world)
        {
            int pattern = Random.Range(0, 5);

            var point = pattern switch
            {
                0 => new Point(1, 0),
                1 => new Point(0, 1),
                2 => new Point(-1, 0),
                3 => new Point(0, -1),
                _ => new Point(0, 0)
            };

            if (world.Map.ContainsTileAt(current + point))
                return GetRandomDirection(current, world);
            
            return point;
        }
    }
}