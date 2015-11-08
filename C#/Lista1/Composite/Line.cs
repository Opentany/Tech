namespace Composite
{
    public class Line : LeafShape
    {
        /* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.structural.composite.model.Shape#getType()
	 */

        public override ShapeType GetTypeOfShape()
        {
            return ShapeType.LINE;
        }
    }
}