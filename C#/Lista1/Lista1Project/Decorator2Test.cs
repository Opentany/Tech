using System;
using Decorator2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesty
{
    [TestClass]
    public class Decorator2Test
    {
        Book book = new Book("Worley", "Inside ASP.NET", 10);

 
      // Create video
      Video video = new Video("Spielberg", "Jaws", 23, 92);

        [TestMethod]
        public void DecoTest()
        {
            book.Display();
            video.Display();
            // Make video borrowable, then borrow and display
      Console.WriteLine("\nMaking video borrowable:");
 
      Borrowable borrowvideo = new Borrowable(video);
      borrowvideo.BorrowItem("Customer #1");
      borrowvideo.BorrowItem("Customer #2");
 
      borrowvideo.Display();
        }
      
    }
}
