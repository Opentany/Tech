using System;
using System.Linq.Expressions;
using Facade;
using Facade.model;
using Facade.service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTesty.FacadeTest.client
{
    [TestClass]
    public class BookStoreFacadeTest : AbstractClientTest {

	[TestMethod]
	public void testPlaceOrder() {
		// Dummy literals
		String isbn = "123";
		String customerId = "wall-e";
		Book dummyBook = new Book(isbn);
		Customer dummyCustomer = new Customer(customerId);
		Order dummyOrder = new Order();
		DispatchReceipt dummyDispatchReceipt = new DispatchReceipt();

		// prepate SUT
		BookstoreFacade facade = createFacade();

		// Prepare stubs
        //Mock<BookDBService> mock = new Mock<BookDBService>();
        //mock.When(bookService.findBookByISBN(isbn).GetType() == typeof(Book))
            dummyBook = bookService.findBookByISBN(isbn);
		//when(bookService.findBookByISBN(isbn)).thenReturn(dummyBook);
	    dummyCustomer = customerService.findCustomerById(customerId);
		//when(customerService.findCustomerById(customerId)).thenReturn(dummyCustomer);
	    dummyOrder = orderingService.createOrder(dummyCustomer, dummyBook);
		//when(orderingService.createOrder(dummyCustomer, dummyBook)).thenReturn(dummyOrder);
	    //dummyDispatchReceipt = wharehouseService.dispatch(dummyOrder);
		//when(warehouseService.dispatch(dummyOrder)).thenReturn(dummyDispatchReceipt);

		// Exercise SUT
		facade.placeOrder(customerId, isbn);
        //mockSomeClass.Verify(v => v.DoSomething(It.IsAny<string>()));
		// Verify behavior
        Mock<WharehouseService> mock = new Mock<WharehouseService>();
        Mock<CustomerNotificationService> mockk = new Mock<CustomerNotificationService>();
        //verify(warehouseService).dispatch(dummyOrder);
	    mock.Verify(wharehouseService.dispatch(dummyOrder));
		//verify(customerNotificationService).notifyClient(dummyDispatchReceipt);
        mockk.Verify(customerNotificationService.notifyClient(dummyDispatchReceipt));

	}

	/**
	 * @return
	 */
	protected BookstoreFacade createFacade() {
		// TODO: Implement the interface bookstoreFacade and set the
		// dependencies. We're using mocks, so you'll have to set the mocks as
		// dependencies of the facade
		// Example:
        DefaultBookstoreFacade impl = new DefaultBookstoreFacade();
	    impl.setCustomerService(customerService);
	    impl.setWharehouseService(wharehouseService);
		impl.setCustomerNotificationService(customerNotificationService);
        impl.setOrderinService(orderingService);
	    return impl;
		// Return an instance of your facade implementation
	}
    
}
}
