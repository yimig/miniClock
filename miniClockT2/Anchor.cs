using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniClockT2
{
    class Anchor
    {
        private Point centerPoint, anchorPoint;
        private int width, height;

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

        public Anchor(int height, int width, Point position, bool isAnchor)
        {
            this.CenterPoint = centerPoint;
            InitHeightAndWidth(height,width);
            if(isAnchor)InitAnchor(position);
            else
            {
                InitCenter(position);
            }
        }

        private Point CalculateAnchor()
        {
            int x = CenterPoint.X - (Width / 2);
            int y = CenterPoint.Y - (Height / 2);
            return new Point(x, y);
        }

        private Point CalculateCenter()
        {
            int x = AnchorPoint.X + (Width / 2);
            int y = AnchorPoint.Y + (Height / 2);
            return new Point(x, y);
        }
    }
}
