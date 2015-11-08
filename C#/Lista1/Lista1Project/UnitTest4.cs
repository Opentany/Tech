/*using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton;

namespace UnitTesty
{
    [TestClass]
    public class UnitTest4
    {
        @Before
	public void cleanUpSingletonReference() {
		ReportBuilder.resetInstance();
	}

	/**
	 * Test for multhithreading
	 * 
	 * @throws InterruptedException
	 */
	/*@Test
	public void testMultiThreading() throws InterruptedException {

		List<Thread> threads = new ArrayList<Thread>();
		// Save the references
		List<ReportBuilder> references = Collections.synchronizedList(new ArrayList<ReportBuilder>());
		// Create n treads
		for (int i = 0; i < 10; i++) {
			Thread worker = new Thread(new Worker(i, references));
			threads.add(worker);
			worker.start();
			// worker.join();

		}

		// Don't go away until all childs have finished

		for (Thread thread : threads) {
			while (thread.isAlive()) {
				// just wait it to die
			}
			System.out.println("Thread " + thread.getId() + " died!");

		}
		// assert all references are for the same object
		for (int i = 0; i < references.size(); i++) {
			ReportBuilder expected = references.get(i);
			for (int j = i; j < references.size(); j++) {
				assertEquals(expected, references.get(j));
			}
		}

	}

	@Test
	public void testGetSingleton() {
		ReportBuilder builder = ReportBuilder.getInstance();
		assertNotNull(builder);
	}

	/**
	 * Will measure init type for the lazy singleton.
	 */
	/*@Test
	public void measureInitializeTime() {
		long startTime = System.currentTimeMillis();
		ReportBuilder.getInstance();
		System.out.println("First call took: " + (System.currentTimeMillis() - startTime) + " ms");

		startTime = System.currentTimeMillis();
		ReportBuilder.getInstance();
		System.out.println("Second call took: " + (System.currentTimeMillis() - startTime) + " ms");

	}

	class Worker implements Runnable {

		private int number;
		private List<ReportBuilder> myReferences;

		public Worker(int number, List<ReportBuilder> references) {
			this.setNumber(number);
			this.myReferences = references;

		}

		/*
		 * (non-Javadoc)
		 * 
		 * @see java.lang.Runnable#run()
		 */
		/*@Override
		public void run() {
			// Dummy call
			this.myReferences.add(ReportBuilder.getInstance());

		}

		/**
		 * @return the number
		 */
		/*public int getNumber() {
			return number;
		}

		/**
		 * @param number
		 *            the number to set
		 */
		/*public void setNumber(int number) {
			this.number = number;
		}

	}
    }
}
*/