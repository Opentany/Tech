using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Facade.model;
using Facade.service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTesty.FacadeTest.service.fake
{
    [TestClass]
    public class FakeCustomerNotificationService : CustomerNotificationService {

	
	private List<Order> notifiedOrders = new List<Order>();
	private List<DispatchReceipt> notifiedDispatchReceipts = new List<DispatchReceipt>();
	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.structural.facade.service.CustomerNotificationService#notifyClient(eu.jpereira.trainings.designpatterns.structural.facade.model.Order)
	 */

	public void notifyClient(Order order) {
		this.notifiedOrders.Add(order);
		
	}

	/* (non-Javadoc)
	 * @see eu.jpereira.trainings.designpatterns.structural.facade.service.CustomerNotificationService#notifyClient(eu.jpereira.trainings.designpatterns.structural.facade.model.DispatchReceipt)
	 */
	public void notifyClient(DispatchReceipt dispatchReceipt)
	{
	    notifiedDispatchReceipts.Add(dispatchReceipt);

	}

        //Spy
	public List<Order> getNotifiedOrders() {
		return this.notifiedOrders;
	}
	
	public List<DispatchReceipt> getNotifiedDisptachReceipts() {
		return this.notifiedDispatchReceipts;
	}

}
}
