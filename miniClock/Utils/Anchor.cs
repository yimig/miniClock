using System.Drawing;

namespace miniClock.Utils
{
    internal class Anchor
    {
        private Point centerPoint, anchorPoint;
        private int width, height;

        public Anchor(int height, int width, Point position, bool isAnchor)
        {
            CenterPoint = centerPoint;
            InitHeightAndWidth(height, width);
            if (isAnchor) InitAnchor(position);
            else
                InitCenter(position);
        }

        public Point CenterPoint
        {
            get => centerPoint;
            set
            {
                centerPoint = value;
                anchorPoint = CalculateAnchor();
            }
        }

        public Point AnchorPoint
        {
            get => anchorPoint;
            set
            {
                anchorPoint = value;
                centerPoint = CalculateCenter();
            }
        }

        public int Width
        {
            get => width;
            set
            {
                width = value;
                anchorPoint = CalculateAnchor();
            }
        }

        public int Height
        {
            get => height;
            set
            {
                height = value;
                anchorPoint = CalculateAnchor();
            }
        }

        public void InitHeightAndWidth(int height, int width)
        {
            Width = width;
            Height = height;
        }

        public void InitAnchor(Point centerPoint)
        {
            CenterPoint = centerPoint;
            AnchorPoint = CalculateAnchor();
        }

        public void InitCenter(Point anchorPoint)
        {
            AnchorPoint = anchorPoint;
            CenterPoint = CalculateCenter();
        }

        private Point CalculateAnchor()
        {
            var x = CenterPoint.X - Width / 2;
            var y = CenterPoint.Y - Height / 2;
            return new Point(x, y);
        }

        private Point CalculateCenter()
        {
            var x = AnchorPoint.X + Width / 2;
            var y = AnchorPoint.Y + Height / 2;
            return new Point(x, y);
        }
    }
}