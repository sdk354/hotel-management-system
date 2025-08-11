-- Admins
CREATE TABLE Admins (
    AdminID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL,
    Role VARCHAR(20) DEFAULT 'Admin'
);

-- Adding SuperAdmin upon initialisation
IF NOT EXISTS (SELECT 1 FROM Admins WHERE Username = 'Owner123')
BEGIN
    INSERT INTO Admins (Username, Password, Role)
    VALUES ('Owner123', 'Password678!', 'SuperAdmin');
END;

-- Customers
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Phone VARCHAR(20)
);

-- Rooms
CREATE TABLE Rooms (
    RoomNumber INT PRIMARY KEY,
    RoomType VARCHAR(50),
    Price DECIMAL(10,2),
    IsAvailable BIT
); 

-- Bookings
CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    RoomNumber INT,
    CheckIn DATE,
    CheckOut DATE,
    Status VARCHAR(20),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber)
);

-- Payments
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT,
    Amount DECIMAL(10,2),
    PaymentDate DATE,
    PaymentMethod VARCHAR(50),
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID)
);
