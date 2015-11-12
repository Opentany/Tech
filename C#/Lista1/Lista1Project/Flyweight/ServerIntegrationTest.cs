//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using UnitTesty.Flyweight.fakes;

//namespace UnitTesty.Flyweight
//{
//    [TestClass]
//    public class ServerIntegrationTest 
//    {
//    protected static Server server;
//    private List<Thread> threads = new List<Thread>(); 

//    @BeforeClass
//    public static void startServer(){
//        server = new Server(8090);
//        server.setHandler(new FakeHTTPHandler());
//        server.start();

//    }

//    @Test
//    public void testServer() throws IOException, InterruptedException {
		
//        //Create some big number of clients
//        System.err.println("Testing 5 Clients....");
//        int numberOfClients = 5;
//        for (int i=0; i< numberOfClients; i++ ) {
//            Thread thread = new Thread(new TestClient());
//            thread.start();
//            thread.join();
//            threads.add(thread);
//        }
		
		
//    }

//    @AfterClass
//    public static void stopServer() throws Exception {
//        server.stop();
//    }

	
//    private class TestClient implements Runnable {

//        /*
//         * (non-Javadoc)
//         * 
//         * @see java.lang.Runnable#run()
//         */
//        @Override
//        public void run() {
//            // create an http client
//            try {
//                URL url = new URL("http://localhost:8090/?city=aveiro&la=1111&lo=9899");
//                URLConnection connection = url.openConnection();
//                BufferedReader in = new BufferedReader(new InputStreamReader(connection.getInputStream()));
//                String inputLine;

//                while ((inputLine = in.readLine()) != null) {
//                    System.out.println(inputLine);
//                }
//                in.close();
//            } catch (MalformedURLException e) {
//                fail("Error");
//                e.printStackTrace();
//            } catch (IOException e) {
//                fail("Error");
//                e.printStackTrace();
//            }

//        }

//    }

//}
//}
