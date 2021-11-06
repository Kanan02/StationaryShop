using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationariesShopDB
{
    public class TableCreator
    {
        public string ConnectionString { get; set; }

        public TableCreator(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public bool CreateTables()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                try
                {
                    string str1 = @"CREATE TABLE Types (
                                    Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
                                    Name varchar(255),
                                    Quantity int
                                 );";
                    string str2 = @"CREATE TABLE Stationaries (
                                    Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
                                    Name varchar(255),
                                    TypeId int,
                                    Price float,
                                    Color varchar(255),
                                    Quantity int,
                                    FOREIGN KEY (TypeId) REFERENCES Types(Id) ON DELETE CASCADE
                                 );";
                    string str3 = @"CREATE TABLE Managers (
                                    Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
                                    FullName varchar(255)
                     );";
                    string str4 = @"CREATE TABLE Sales (
                                    Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
                                    NameOfCompany varchar(255),
                                    StationaryId int,
                                    ManagerId int,
                                    Date date,
                                    FOREIGN KEY (StationaryId) REFERENCES Stationaries(Id) ON DELETE CASCADE,
                                    FOREIGN KEY (ManagerId) REFERENCES Managers(Id) ON DELETE CASCADE
                                 );";

                    SqlCommand cmd = new SqlCommand(str1, con);
                    SqlCommand cmd2 = new SqlCommand(str2, con);
                    SqlCommand cmd3 = new SqlCommand(str3, con);
                    SqlCommand cmd4 = new SqlCommand(str4, con);
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }
        public void SeedData()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                string str1 = @"INSERT INTO Types (Name, Quantity)
VALUES ('Type1',5);INSERT INTO Types (Name, Quantity)
VALUES ('Type2',10);INSERT INTO Types (Name, Quantity)
VALUES ('Type3',20);";
                string str2 = @"INSERT INTO Stationaries (Name,TypeId,Price,Color,Quantity)VALUES ('Stat1',1,20,'Red',5);
INSERT INTO Stationaries (Name,TypeId,Price,Color,Quantity)VALUES ('Stat2',1,25,'Green',10);
INSERT INTO Stationaries (Name,TypeId,Price,Color,Quantity)VALUES ('Stat3',2,20,'Blue',20);
INSERT INTO Stationaries (Name,TypeId,Price,Color,Quantity)VALUES ('Stat4',2,70,'Yellow',25);
INSERT INTO Stationaries (Name,TypeId,Price,Color,Quantity)VALUES ('Stat5',3,80,'Red',55);";
                string str3 = @"INSERT INTO Managers (FullName)VALUES ('Man1');
INSERT INTO Managers (FullName)VALUES ('Man2');
INSERT INTO Managers (FullName)VALUES ('Man3');";
                string str4 = @"INSERT INTO Sales (NameOfCompany ,StationaryId,ManagerId,Date)VALUES ('CMP1',1,1,'2021-7-20');
INSERT INTO Sales (NameOfCompany ,StationaryId,ManagerId,Date)VALUES ('CMP2',1,2,'2021-7-20');
INSERT INTO Sales (NameOfCompany ,StationaryId,ManagerId,Date)VALUES ('CMP3',2,2,'2021-7-20');
INSERT INTO Sales (NameOfCompany ,StationaryId,ManagerId,Date)VALUES ('CMP4',3,3,'2021-5-20');
INSERT INTO Sales (NameOfCompany ,StationaryId,ManagerId,Date)VALUES ('CMP1',4,1,'2021-5-20');
INSERT INTO Sales (NameOfCompany ,StationaryId,ManagerId,Date)VALUES ('CMP1',5,3,'2021-5-20');
INSERT INTO Sales (NameOfCompany ,StationaryId,ManagerId,Date)VALUES ('CMP1',2,3,'2021-7-20');";
                SqlCommand cmd = new SqlCommand(str1, con);
                SqlCommand cmd2 = new SqlCommand(str2, con);
                SqlCommand cmd3 = new SqlCommand(str3, con);
                SqlCommand cmd4 = new SqlCommand(str4, con);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
            }

        }
    }

}
