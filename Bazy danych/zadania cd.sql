#5
select ProductID, UnitPrice*Quantity as kwota_na_zamówieniu from order_details
order by kwota_na_zamówieniu asc
limit 6;

#6
select ProductID from (select ProductID, avg(Quantity) as AVG_Quantity from order_details
group by ProductID) as srednia where AVG_Quantity > 2;

#7
select LastName, OrderID, OrderDate from employees inner join orders
on employees.EmployeeID = orders.EmployeeID
where OrderDate < "1998-01-23";

#8
select customers.CustomerID, orders.OrderDate from customers left outer join orders
on customers.CustomerID=orders.CustomerID;

#9
select * from shippers cross join suppliers
where shippers.CompanyName like "s%"
and suppliers.CompanyName like "s%";

#10
select ProductName, OrderDate from products inner join order_details
on products.ProductID=order_details.ProductID
inner join orders
on order_details.OrderID=orders.OrderID;

#11
select distinct c1.CompanyName,c2.CompanyName, c1.Region from customers as c1 
inner join customers as c2
on c1.Region = c2.Region
where c1.CompanyName < c2.CompanyName
order by c1.Region;


#12
select orders.CustomerID, products.ProductName, sum(order_details.UnitPrice*order_details.Quantity) as Suma
from orders inner join order_details
on orders.OrderID = order_details.OrderID
inner join products
on order_details.ProductID = products.ProductID
group by orders.CustomerID, products.ProductName;


#13
select products.ProductID, min(order_details.Quantity) from products
inner join order_details on products.ProductID = order_details.ProductID
group by products.ProductID;

#14
select customers.CompanyName from customers
where customers.CustomerID in (select orders.CustomerID from orders
where orders.OrderDate not like "1998-05-15%");

#15
create temporary table tymczasowa (select * from customers where customers.CompanyName like "t%");
select * from tymczasowa;

#16
select 