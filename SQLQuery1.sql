SELECT P.ProductName As [Ürün Adı], 
ROUND(SUM((1-OD.Discount)* OD.UnitPrice * OD.Quantity), 2)  As [Kazanılan Toplam Miktar]
from Orders
INNER JOIN OrderDetails on Orders.OrderID = [OrderDetails].OrderID
INNER JOIN Products On OrderDetails.ProductID = P.ProductID group by ProductName order by ProductName


SELECT ModelName As [Araç Modeli], CarImages.ImagePath from Cars
LEFT JOIN CarImages on Cars.Id = CarImages.CarId


INSERT INTO CarImages (CarId, ImagePath, Date)
VALUES
    (1, 'images/1a.jpg', '2022-01-01 08:00:00'),
    (1, 'images/1b.jpg', '2022-01-02 10:30:00'),
    (2, 'images/2a.jpg', '2022-01-03 12:45:00'),
    (3, 'images/3a.jpg', '2022-01-04 15:15:00'),
    (4, 'images/4a.jpg', '2022-01-05 17:30:00'),
    (4, 'images/4b.jpg', '2022-01-06 19:45:00'),
    (5, 'images/5a.jpg', '2022-01-07 21:00:00'),
    (6, 'images/6a.jpg', '2022-01-08 23:15:00'),
    (7, 'images/7a.jpg', '2022-01-09 01:30:00'),
    (8, 'images/8a.jpg', '2022-01-10 03:45:00'),
    (8, 'images/8b.jpg', '2022-01-11 06:00:00'),
    (9, 'images/9a.jpg', '2022-01-12 08:15:00'),
    (9, 'images/9b.jpg', '2022-01-13 10:30:00'),
    (10, 'images/10a.jpg', '2022-01-14 12:45:00'),
    (11, 'images/11a.jpg', '2022-01-15 15:00:00'),
    (11, 'images/11b.jpg', '2022-01-16 17:15:00'),
    (12, 'images/12a.jpg', '2022-01-17 19:30:00'),
    (12, 'images/12b.jpg', '2022-01-18 21:45:00'),
    (13, 'images/13a.jpg', '2022-01-19 00:00:00'),
    (14, 'images/14a.jpg', '2022-01-20 02:15:00');
