using System;
using System.Collections.Generic;

namespace Internal.WorldBase
{
    public class World
    {
        private readonly List<Biome> _biomes;
        public readonly TilesMap Map = new(WorldSize);

        public static readonly Point WorldSize = new(300, 300);

        public void AddBiome(Biome biome)
        {
            _biomes.Add(biome);
        }

        public bool ContainsBiomeOfType(Type TBiome)
        {
            var biome = _biomes.Find((Biome biome) => biome.GetType() == TBiome);
            return biome != null;
        }
        
        public bool ContainsBiomeOfType(Type TBiome, out Biome biome)
        {
            biome = _biomes.Find((Biome biome) => biome.GetType() == TBiome);
            
            return biome != null;
        }
    }
}