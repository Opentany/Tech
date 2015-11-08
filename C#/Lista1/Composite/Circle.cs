namespace Composite
{
    public class Circle : CompositeShape
    {
        /* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.structural.composite.model.Shape#getType()
	 */

        public override ShapeType GetTypeOfShape()
        {
            return ShapeType.CIRCLE;
        }
    }
}