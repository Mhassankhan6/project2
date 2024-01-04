CREATE DATABASE BankManagementSystem
USE BankManagementSystem

CREATE TABLE [User] (
	UserID INT IDENTITY (1, 1),
	FirstName VARCHAR(100),
	LastName VARCHAR(100),
    Username VARCHAR(50),
    Password VARCHAR(100),
	BirthDate DATE,
	Gender VARCHAR(20),
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20),
    PostalCode VARCHAR(20),
	Address VARCHAR(100),
	City VARCHAR(100),
	State VARCHAR(100),
	Country VARCHAR(50),
	Occupation VARCHAR(100),
	RegistrationDate DATE,
    LastLogin DATETIME,
    AccountStatus VARCHAR(20),
	PRIMARY KEY (UserID)
);

CREATE TABLE Branch (
    BranchID INT IDENTITY (1, 1),
    BranchName VARCHAR(100),
    Location VARCHAR(200),
    ContactNumber VARCHAR(20),
    Email VARCHAR(100)
	PRIMARY KEY (BranchID),
);

CREATE TABLE AccountHolderType (
    HolderTypeID INT IDENTITY (1, 1),
    HolderTypeName VARCHAR(100),
	PRIMARY KEY (HolderTypeID)
);

CREATE TABLE TransactionStatus (
    StatusID INT IDENTITY (1, 1),
    StatusName VARCHAR(100),
	PRIMARY KEY (StatusID)
);

CREATE TABLE InterestRateType (
    RateTypeID INT IDENTITY (1, 1),
    RateTypeName VARCHAR(100),
	PRIMARY KEY (RateTypeID)
);

CREATE TABLE Account (
    AccountID INT IDENTITY (1, 1),
    AccountNumber VARCHAR(20) UNIQUE,
    AccountType VARCHAR(50),
    AccountBalance DECIMAL(15, 2),
    InterestRate DECIMAL(5, 2),
    AccountStatus VARCHAR(20),
    DateOpened DATETIME,
    LastTransactionDate DATETIME,
    UserID INT,
    BranchID INT,
    HolderTypeID INT,
    RateTypeID INT,
	PRIMARY KEY (AccountID),
    FOREIGN KEY (UserID) REFERENCES [User](UserID),
    FOREIGN KEY (BranchID) REFERENCES Branch(BranchID),
    FOREIGN KEY (HolderTypeID) REFERENCES AccountHolderType(HolderTypeID),
    FOREIGN KEY (RateTypeID) REFERENCES InterestRateType(RateTypeID)
);

CREATE TABLE [Transaction] (
    TransactionID INT IDENTITY (1, 1),
    TransactionType VARCHAR(50),
    Amount DECIMAL(15, 2),
    TransactionDate DATETIME,
    Description VARCHAR(200),
    SourceAccountNumber INT,
    DestinationAccountNumber VARCHAR(20),
    UserID INT,
    StatusID INT,
	PRIMARY KEY (TransactionID),
    FOREIGN KEY (SourceAccountNumber) REFERENCES Account(AccountID),
    FOREIGN KEY (UserID) REFERENCES [User](UserID),
    FOREIGN KEY (StatusID) REFERENCES TransactionStatus(StatusID)
);

CREATE TABLE Beneficiary (
    BeneficiaryID INT IDENTITY (1, 1),
    BeneficiaryName VARCHAR(100),
    AccountNumber VARCHAR(20),
    AccountType VARCHAR(50),
    Description VARCHAR(200),
    UserID INT,
	PRIMARY KEY (BeneficiaryID),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

CREATE TABLE Bill (
    BillID INT IDENTITY (1, 1),
    BillerName VARCHAR(100),
    BillType VARCHAR(50),
    Amount DECIMAL(15, 2),
    DueDate DATE,
    UserID INT,
	PRIMARY KEY (BillID),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

CREATE TABLE Loan (
    LoanID INT IDENTITY (1, 1),
    LoanType VARCHAR(100),
    LoanAmount DECIMAL(15, 2),
    InterestRate DECIMAL(5, 2),
    LoanTerm INT,
    StartDate DATE,
    EndDate DATE,
    UserID INT,
	PRIMARY KEY (LoanID),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

CREATE TABLE CreditCard (
    CreditCardID INT IDENTITY (1, 1),
    CreditCardNumber VARCHAR(16) UNIQUE,
    CardholderName VARCHAR(100),
    ExpiryDate DATE,
    CVV VARCHAR(4),
    CreditLimit DECIMAL(15, 2),
    AvailableCredit DECIMAL(15, 2),
    UserID INT,
	PRIMARY KEY (CreditCardID),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

CREATE TABLE Payment (
    PaymentID INT IDENTITY (1, 1),
    PaymentType VARCHAR(50),
    AmountPaid DECIMAL(15, 2),
    PaymentDate DATETIME,
    Description VARCHAR(200),
    CreditCardID INT,
    UserID INT,
	PRIMARY KEY (PaymentID),
    FOREIGN KEY (CreditCardID) REFERENCES CreditCard(CreditCardID),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

CREATE TABLE SecurityQuestion (
    QuestionID INT IDENTITY (1, 1),
    SecurityQuestion VARCHAR(200),
    Answer VARCHAR(100),
    UserID INT,
	PRIMARY KEY (QuestionID),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

CREATE TABLE Notification (
    NotificationID INT IDENTITY (1, 1),
    NotificationType VARCHAR(100),
    Message VARCHAR(500),
    ReadStatus VARCHAR(10),
    Time DATETIME,
    UserID INT,
	PRIMARY KEY (NotificationID),
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);