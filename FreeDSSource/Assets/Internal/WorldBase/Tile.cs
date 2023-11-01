using System.Collections.Generic;
using UnityEngine;

namespace Internal.WorldBase
{
    public class Tile : MonoBehaviour
    {
        public Tile[] ConnectedTiles => _connectedTiles.ToArray();
        private readonly List<Tile> _connectedTiles = new();

        private void OnDestroy()
        {
            foreach (var tile in _connectedTiles)
            {
                tile.RemoveConnection(this);
            }
        }

        public void AddConnection(Tile tile)
        {
            if (tile == null)
            {
                Debug.LogError("TILE NULL");
                return;
            }
            
            _connectedTiles.Add(tile);
        }

        public void RemoveConnection(Tile tile)
        {
            if (tile == null)
            {
                Debug.LogError("TILE NULL");
                return;
            }
            
            _connectedTiles.Remove(tile);
        }
    }
}