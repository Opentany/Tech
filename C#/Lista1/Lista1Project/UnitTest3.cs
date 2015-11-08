

using System;
using System.Collections.Generic;
using System.Linq;
using Composite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesty
{
    [TestClass]
    public class UnitTest3
    {
        public Shape circle = new Circle();
        // Create a line
        public Shape line = new Line();
        public Shape rectangle = new Rectangle();
        public Shape triangle = new Triangle();

	[TestMethod]
	public void testAddShape() {

		// Add a line to the circle
		circle.AsComposite().AddShape(line);
		// add a rectangle to a circle
		circle.AsComposite().AddShape(rectangle);
		circle.AsComposite().AddShape(triangle);

		// assert circle has three children
		Assert.AreEqual(3, circle.AsComposite().GetShapeCount());

	}

        [TestMethod]
        public void testGetShapesByType()
        {
            Shape shape = createCompositeShapeFixture();
            // Assert it contains RECTANGLE (well, I know that fixture...)
            Assert.IsNotNull(shape.AsComposite().GetShapesByType(ShapeType.RECTANGLE));
            Assert.AreEqual(1, shape.AsComposite().GetShapesByType(ShapeType.RECTANGLE).Count);
        }

        [TestMethod]
        public void testRemoveShape()
        {
            Shape shape = createCompositeShapeFixture();
            // Assert it contains RECTANGLE (well, I know that fixture...)
            Assert.AreEqual(1, shape.AsComposite().GetShapesByType(ShapeType.RECTANGLE).Count);

            // Now remove it
            Assert.IsTrue(
                shape.AsComposite().removeShape(shape.AsComposite().GetShapesByType(ShapeType.RECTANGLE).ElementAt(0)));
            Assert.AreEqual(0, shape.AsComposite().GetShapesByType(ShapeType.RECTANGLE).Count);
        }

        [TestMethod]
        public void testMoveShape()
        {
            Shape testShape = createCompositeShapeFixture();
            //Move a the shape
            testShape.Move(2, 2);
            Assert.AreEqual(2, testShape.getX());
            Assert.AreEqual(2, testShape.getY());

            //each shape in the tree has to move also
            foreach (var aShape in testShape.AsComposite().GetShapes())
            {
                Assert.AreEqual(2, aShape.getX());
                Assert.AreEqual(2, aShape.getY());
            }
        }

        [TestMethod]
        public void testMoveLeafsShapes()
        {
            Shape testShape = createCompositeShapeFixture();

            Assert.AreEqual(0, testShape.getX());
            Assert.AreEqual(0, testShape.getY());
            //Get all primitives
            List<Shape> leafs = testShape.AsComposite().getLeafShapes();

            foreach (var leaf in leafs)
            {
                leaf.Move(2, 2);
                Assert.AreEqual(2, leaf.getX());
                Assert.AreEqual(2, leaf.getY());
            }
            Assert.AreEqual(0, testShape.getX());
            Assert.AreEqual(0, testShape.getY());
        }

        [TestMethod]
        public void moveHierarchyIndependently()
        {
            Shape rectangle = new Rectangle();
            //inside the rectangle, has a circle and another rectangle
            Shape innerRectangle = new Rectangle();
            Shape innerCircle = new Circle();
            rectangle.AsComposite().AddShape(innerCircle);
            rectangle.AsComposite().AddShape(innerRectangle);
            //inside the innerRectangle, add  two lines
            Shape innerInnerlineA = new Line();
            Shape innerInnerlineB = new Line();
            innerRectangle.AsComposite().AddShape(innerInnerlineA);
            innerRectangle.AsComposite().AddShape(innerInnerlineB);
            //inside the innerCircle add a triangle
            Shape innerInnerTriangle = new Triangle();
            innerCircle.AsComposite().AddShape(innerInnerTriangle);
            //inside the innerInnerTriagle let's add a line
            Shape innerInnerInnerLine = new Line();
            innerInnerTriangle.AsComposite().AddShape(innerInnerInnerLine);


            //Move the rectangle all together
            rectangle.Move(3, 3);
            //rectangle still have the same position
            Assert.AreEqual(3, rectangle.getX());
            Assert.AreEqual(3, rectangle.getY());

            foreach (var aShape in rectangle.AsComposite().GetShapes())
            {
                Assert.AreEqual(3, aShape.getX());
                Assert.AreEqual(3, aShape.getY());
            }


            //Move only the innerCircle
            innerCircle.Move(1, 1);
            //innerRectangle still have the same position
            Assert.AreEqual(3, innerRectangle.getX());
            Assert.AreEqual(3, innerRectangle.getY());

            //innerCircle and all children must have moved
            Assert.AreEqual(4, innerCircle.getX());
            Assert.AreEqual(4, innerCircle.getY());
            //all children has to move
            Assert.AreEqual(4, innerInnerTriangle.getX());
            Assert.AreEqual(4, innerInnerTriangle.getY());

            Assert.AreEqual(4, innerInnerInnerLine.getY());
            Assert.AreEqual(4, innerInnerInnerLine.getX());
        }

        /**
	 * Factory method for composite fixture
	 * @return
	 */

        protected Shape createCompositeShapeFixture()
        {
            // Create a circle
            

            // Add a line to the circle
            try
            {
                circle.AsComposite().AddShape(line);
            }
            catch (NullReferenceException)
            {
                
                Console.WriteLine("mamy null");
            }
            
            // add a rectangle to a circle
            circle.AsComposite().AddShape(rectangle);
            circle.AsComposite().AddShape(triangle);
            return circle;
        }
    }
}

