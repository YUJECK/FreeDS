using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Internal.WorldBase
{
    public sealed class WorldGenerator : MonoBehaviour
    {
        public SpriteRenderer PointPrefab;
        
        private const int VertexcesCount = 6;

        private readonly List<WorldBiome> _biomes = new();

        private Dictionary<int, Color> _colors = new()
        {
            {0, Color.black},
            {1, Color.green},
            {2, Color.cyan},
            {3, Color.yellow},
            {4, Color.red},
        };
        
        private void Awake()
        {
            Generate();
            CreatePoints();
        }

        private void OnDrawGizmos()
        {
            BiomeVertex previos = _biomes[0].GetAllVertexes()[0];
            for(int i = 0; i < _biomes.Count; i++)
            {
                foreach (var vertex in _biomes[i].GetAllVertexes())
                {
                    Gizmos.color = _colors[i];
                    Gizmos.DrawLine(new Vector3(previos.X, previos.Y, 0), new Vector3(vertex.X, vertex.Y, 0));
                    previos = vertex;
                }

                Gizmos.DrawLine(new Vector3(previos.X, previos.Y, 0), new Vector3(_biomes[i].GetAllVertexes().First().X, _biomes[i].GetAllVertexes().First().Y, 0));
            }
        }

        private void Generate()
        {
            for (int i = 0; i < 4; i++)
            {
                var biome = new WorldBiome();

                for (int j = 0; j < VertexcesCount; j++)
                {
                    biome.AddNew(GetRandomVertex(biome, _biomes.ToArray()));                
                }
            
                _biomes.Add(biome);    
            }
        }

        private void CreatePoints()
        {
            for(int i = 0; i < _biomes.Count; i++)
            {
                foreach (var vertex in _biomes[i].GetAllVertexes())
                {
                    SpriteRenderer spriteRenderer = Instantiate(PointPrefab, new Vector3(vertex.X, vertex.Y), quaternion.identity);
                    spriteRenderer.color = _colors[i];
                }
            }
        }

        public BiomeVertex GetRandomVertex(WorldBiome forBiome, WorldBiome[] biomes)
        {
            BiomeVertex vertex = new(Random.Range(World.MinX, World.MaxX), Random.Range(World.MinY, World.MaxY));

            foreach (var biome in biomes)
            {
                if (
                    !(vertex.X > biome.BiomeBounds.BottomX && vertex.X < biome.BiomeBounds.TopX
                    && vertex.Y > biome.BiomeBounds.BottomY && vertex.Y < biome.BiomeBounds.TopY))
                {
                    continue;
                }

                return GetRandomVertex(forBiome, biomes);
            }

            return vertex;
        }
    }
}