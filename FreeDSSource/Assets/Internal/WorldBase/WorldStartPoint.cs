using UnityEngine;

namespace Internal.WorldBase
{
	public class WorldStartPoint : MonoBehaviour
	{
		public Tile TestTile;
		
		public World World { get; private set; }

		private void Start()
		{
			World = new World();

			World.Map.AddTileAt(new Point(5, 5), TestTile);
		}
	}
}