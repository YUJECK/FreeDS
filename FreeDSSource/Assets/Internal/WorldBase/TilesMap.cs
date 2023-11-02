using System.Collections.Generic;
using UnityEngine;

namespace Internal.WorldBase
{
    public class TilesMap
    {
        private readonly Dictionary<Point, Tile> _tiles = new();

        public readonly Point MapSize;

        public TilesMap(Point mapSize)
        {
            MapSize = mapSize;

            for (int x = 0; x <= MapSize.X; x++)
            {
                for (int y = 0; y <= MapSize.Y; y++)
                {
                    _tiles.Add(new Point(x, y), null);
                }
            }
        }
        
        public bool ContainsTileAt(Point atPoint)
            => _tiles[atPoint] == null;
        
        public Tile GetTileAt(Point atPoint)
            => _tiles[atPoint];

        public void ClearMap()
        {
            foreach (var tilePair in _tiles)
            {
                GameObject.Destroy(tilePair.Value);
                _tiles[tilePair.Key] = null;
            }
        }
        public bool AddTileAt(Point toPoint, Tile tile)
        {
            if (_tiles[toPoint] != null)
                return false;

            SpawnNewTile(toPoint, tile);
            _tiles[toPoint] = tile;
            return true;
        }
        public void ReplaceTileAt(Point toPoint, Tile tile)
        {
            if(IsPointBoundsInMap(toPoint, true))
               return;
            
            if(_tiles[toPoint] == null) 
                Debug.LogWarning("You replaced null tile");

            GameObject.Destroy(tile.gameObject);
            _tiles[toPoint] = SpawnNewTile(toPoint, tile);
        }
        public bool IsPointBoundsInMap(Point point, bool printWarning = false)
        {
            if (_tiles.ContainsKey(point))
            {
                return true;               
            }

            if (printWarning)
            {
                Debug.LogWarning($"Point ({point.X}; {point.Y}) not bound in map");                
            }
                
            return false;
        }

        private static Tile SpawnNewTile(Point toPoint, Tile tile)
        {
            return GameObject.Instantiate(tile, toPoint.ToVector2(), Quaternion.identity);
        }
    }
}