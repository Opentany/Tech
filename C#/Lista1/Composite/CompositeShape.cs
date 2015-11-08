using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    public abstract class CompositeShape : Shape
    {
        private List<Shape> shapes;

        protected CompositeShape()
        {
            shapes = createShapesList();
        }

        /**
	 * Remove a shape from this shape childrens
	 * 
	 * @param shape
	 *            the shape to remove
	 * @return true if the shape was present and was removed, false if the shape
	 *         was not present
	 */

        public bool removeShape(Shape shape)
        {
            if (GetShapes().IndexOf(shape)>=0)
            {
                GetShapes().RemoveAt(GetShapes().IndexOf(shape));
                return true;
            }
            return false;
        }

        /**
	 * Return the total shapes count in case this is a composite
	 * 
	 * @return the total count of shapes if the shape is composite. -1 otherwise
	 */

        public int GetShapeCount()
        {
            if (AsComposite() != null)
            {
                return AsComposite().shapes.Count;
            }
            return -1;
        }

        /**
	 * Add a shape to this shape.
	 * 
	 * @param shape
	 *            The shape to add
	 * @throws ShapeDoesNotSupportChildren
	 *             if this shape is not a composite
	 */

        public void AddShape(Shape shape)
        {
            // TODO: Implement
            if (AsComposite() != null)
            {
                AsComposite().shapes.Add(shape);
            }
            else
            {
                throw new ShapeDoesNotSupportChildren();
            }
        }

        public List<Shape> GetShapes()
        {
            // TODO: Implement
            return AsComposite() != null ? AsComposite().shapes : null;
        }

        /**
	 * @param circle
	 * @return
	 */

        public List<Shape> GetShapesByType(ShapeType circle)
        {
            // TODO: Implement
            return shapes.Where(shape => shape.GetTypeOfShape() == circle).ToList();
        }

        /**
	 * Return all shapes that are leafs in the tree
	 * 
	 * @return
	 */

        public List<Shape> getLeafShapes()
        {
            List<Shape> leafsShapes = new List<Shape>();
            if (AsComposite() !=null)
            {
                foreach (var leafs in shapes)
                {
                    leafsShapes.Add(leafs);
                }
            }
            else
            {
                leafsShapes.Add(this);
            }
            return leafsShapes;
        }

        /**
	 * Factory method for the list of children of this shape
	 * 
	 * @return
	 */

        protected List<Shape> createShapesList()
        {
            return new List<Shape>();
        }
    }
}