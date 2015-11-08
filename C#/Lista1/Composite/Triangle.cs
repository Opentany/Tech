namespace Composite
{
    public class Triangle : CompositeShape
    {
        /* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.structural.composite.model.Shape#getType()
	 */

        public override ShapeType GetTypeOfShape()
        {
            // TODO Auto-generated method stub
            return ShapeType.TRIANGLE;
        }
    }
}