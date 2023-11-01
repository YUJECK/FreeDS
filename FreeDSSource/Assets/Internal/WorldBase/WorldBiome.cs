using System.Collections.Generic;
using UnityEngine;

namespace Internal.WorldBase
{
    public sealed class WorldBiome
    {
        public BiomeBounds BiomeMaxBounds = new(-5, -5, 5, 5);
        public BiomeBounds BiomeBounds;

        private Dictionary<BiomeVertex, List<BiomeVertex>> _verticesMap = new();
        private List<BiomeVertex> _vertices = new();

        public BiomeVertex[] GetConnectionsOf(BiomeVertex biomeVertex)
        {
            return _verticesMap[biomeVertex].ToArray();
        }

        public BiomeVertex[] GetAllVertexes()
        {
            return _vertices.ToArray();
        }
        
        
        public void AddNew(BiomeVertex biomeVertex)
        {
            _verticesMap.Add(biomeVertex, new List<BiomeVertex>());
            
            UpdateBounds();
            UpdateVertexesList();
        }

        public void AddConnection(BiomeVertex biomeVertex, BiomeVertex[] connections)
        {
            _verticesMap[biomeVertex].AddRange(connections);
        }

        public void UpdateBounds()
        {
            float bestBottomX = Mathf.Infinity;
            float bestBottomY = Mathf.Infinity;
            float bestTopX = -Mathf.Infinity;
            float bestTopY = -Mathf.Infinity;
            
            foreach (var vertexPair in _verticesMap)
            {
                var vertex = vertexPair.Key;

                if (vertex.X < bestBottomX)
                    bestBottomX = vertex.X;

                if (vertex.Y < bestBottomY)
                    bestBottomY = vertex.Y;
                
                if (vertex.X > bestTopX)
                    bestTopX = vertex.X;

                if (vertex.Y > bestTopY)
                    bestTopY = vertex.Y;
            }
            
            BiomeBounds = new BiomeBounds(bestBottomX, bestBottomY, bestTopX, bestTopY);
        }

        private void UpdateVertexesList()
        {
            List<BiomeVertex> vertices = new();

            foreach (var vertexPair in _verticesMap)
            {
                vertices.Add(vertexPair.Key);
            }

            _vertices = vertices;
        }
    }
}