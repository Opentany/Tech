using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public abstract class Shape
    {
        // The shape coordinates
        private int x;
        private int y;

        /**
         * If this object is a CompositeShape, return it. Null otherwise.
         * 
         * @return an compositeShape instance if this is an composite, null
         *         otherwise
         */

        public CompositeShape AsComposite()
        {
            Console.WriteLine();
            if (GetTypeOfShape()!= ShapeType.LINE)
                return (CompositeShape) this;

            else
            {
                return null;
            }
        }

        /**
         * Move a shape in a 2D scale
         * 
         * @param xIncrement
         *            The increment in X axis
         * @param yIncremet
         *            The increment in the Y axis
         */

        public void Move(int xIncrement, int yIncrement)
        {
            this.x += xIncrement;
            this.y += yIncrement;
            // if is composite, delegate to children
            Console.WriteLine();
            if(AsComposite()!=null)
            {
                foreach (var shape in AsComposite().GetShapes())
                {
                    shape.Move(xIncrement, yIncrement);
                }
            }
            //TODO: COmplete
        }

        /**
         * @return the x coordinate
         */

        public int getX()
        {
            return x;
        }

        /**
         * @param x
         *            the x coordinate to set
         */

        public void setX(int x)
        {
            this.x = x;
        }

        /**
         * @return the y coordinate
         */

        public int getY()
        {
            return y;
        }

        /**
         * @param y
         *            the y coordinate to set
         */

        public void setY(int y)
        {
            this.y = y;
        }

        /**
         * Each instance of a Shape must know it's type
         * @return
         */
        public abstract ShapeType GetTypeOfShape();


    }
}
