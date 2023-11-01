namespace Internal.WorldBase
{
    public sealed class BiomeBounds
    {
        public float BottomX;
        public float BottomY;
        public float TopX;
        public float TopY;

        public BiomeBounds(float bottomX, float bottomY, float topX, float topY)
        {
            BottomX = bottomX;
            BottomY = bottomY;
            TopX = topX;
            TopY = topY;
        }
    }
}