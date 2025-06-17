CREATE TABLE tblUser (
    User_ID INT IDENTITY(1,1) PRIMARY KEY,
    User_Name TEXT NOT NULL,
    Password TEXT NOT NULL,
    Email TEXT NOT NULL,
);


CREATE TABLE tblRoles (
    Role_ID INT IDENTITY(1,1) PRIMARY KEY,
    Role_Name TEXT NOT NULL
);


CREATE TABLE tblRecordLabel (
    RecordLabel_ID INT IDENTITY(1,1) PRIMARY KEY,
    RecordLabel_Name TEXT NOT NULL
);

CREATE TABLE tblArtist (
    Artist_ID INT IDENTITY(1,1) PRIMARY KEY,
    RecordLabel_ID INTEGER NOT NULL,
    Artist_Name TEXT NOT NULL,
    FOREIGN KEY (RecordLabel_ID) REFERENCES tblRecordLabel(RecordLabel_ID) ON DELETE CASCADE
);

CREATE TABLE tblVinyl (
    Vinyl_ID INT IDENTITY(1,1) PRIMARY KEY,
    Artist_ID INTEGER NOT NULL,
    Vinyl_Name TEXT NOT NULL,
    Date_Of_Release DATE NOT NULL,
    FOREIGN KEY (Artist_ID) REFERENCES tblArtist(Artist_ID) ON DELETE CASCADE
);

CREATE TABLE tblGenre (
    Genre_ID INT IDENTITY(1,1) PRIMARY KEY,
    Genre_Name TEXT NOT NULL,
    Description TEXT NOT NULL
);

CREATE TABLE tblReviews (
    Review_ID INT IDENTITY(1,1) PRIMARY KEY,
    Vinyl_ID INTEGER NOT NULL,
    Reviewer_Name TEXT NOT NULL,
    Out_Of_5 DECIMAL(3,1) NOT NULL CHECK (Out_Of_5 BETWEEN 0.0 AND 5.0),
    FOREIGN KEY (Vinyl_ID) REFERENCES tblVinyl(Vinyl_ID) ON DELETE CASCADE
);

CREATE TABLE tblReviewComments (
    ReviewComment_ID INT IDENTITY(1,1) PRIMARY KEY,
    Review_ID INTEGER NOT NULL,
    Short_Review TEXT NOT NULL,
    Review_Date DATE NOT NULL,
    FOREIGN KEY (Review_ID) REFERENCES tblReviews(Review_ID) ON DELETE CASCADE
);
