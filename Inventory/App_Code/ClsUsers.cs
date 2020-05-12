using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Data.SqlClient;
using Inventory.Models;

namespace Inventory.App_Code
{
   
    public class ClsUsers:clsSql
    {
       
        public ModelBooks modelBooks { get; set; }
        public List<ModelBooks> lstUser { get; set; }
        public DataTable tblUsers { get; set; }
        public ClsUsers()
        {
            //allocate memory to the instance
            modelBooks = new ModelBooks();
            lstUser = new List<Models.ModelBooks>();
            tblUsers = new DataTable("tblUsers");
        }
        //obtain required information from the user
        public Int32 Create(ModelBooks _modelBooks)
        {
            try
            {
                Command = new SqlCommand();
                this.modelBooks = _modelBooks;
                if (modelBooks.BookID <= 0)
                    Query = @"Insert into tblInventory(Title, Author,ISBN,Publisher,BYear)Values(@Title, @Author,@ISBN,@Publisher,@BYear);";
                else
                {
                    Query = @"Update tblInventory Set Title = @Title, Author = @Author, 
                               ISBN = @ISBN, Publisher = @Publisher, BYear = @BYear
                                Where BookID = @BookID ";
                    Command.Parameters.Add("@BookID", SqlDbType.Int).Value = modelBooks.BookID;
                }
                   

                Command.Parameters.Add("@Title", SqlDbType.VarChar, 100).Value = modelBooks.Title;
                Command.Parameters.Add("@Author", SqlDbType.VarChar, 100).Value = modelBooks.Author;
                Command.Parameters.Add("@ISBN", SqlDbType.VarChar, 100).Value = modelBooks.ISBN;
                Command.Parameters.Add("@Publisher", SqlDbType.VarChar, 100).Value = modelBooks.Publisher;
                Command.Parameters.Add("@BYear", SqlDbType.VarChar, 100).Value = modelBooks.BYear;
                //Set the Command Text
                Command.CommandText = Query;
                ExecuteNonQuery(Command);
                if (RowsAffected > 0)
                {
                    Message = " User Created ";
                }
                else
                {
                    Message = " User Creation Failed.";
                }
            }
            catch (Exception ex)
            {
                Message = "Error: " + ex.Message.ToString();
            }
            return RowsAffected;
        }
        public List<ModelBooks> Get(String Search)
        {
            try
            {
                Command = new SqlCommand();
                Command.Connection = Connection;
                Query = @"select * from tblInventory Where BookID > 0";
                if (!String.IsNullOrEmpty (Search))
                {
                    Query += " and (Title Like @Search or Author like @Search or ISBN like @Search)";
                    Command.Parameters.Add("@Search", SqlDbType.VarChar, 50).Value = "%" + Search + "%";
                }
                Command.CommandText = Query;
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    lstUser.Add(new ModelBooks
                    {
                        BookID = Convert.ToInt32(Reader["BookID"]),
                       Title = Reader["Title"].ToString(),
                        Author = Reader["Author"].ToString(),
                        ISBN = Reader["ISBN"].ToString(),
                        Publisher = Reader["Publisher"].ToString(),
                        BYear = Reader["BYear"].ToString()
                       
                    });
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message.ToString();
            }
            return lstUser;
        }

        public Int32 Delete(Int32 BookID )
        {
            try
            {
                Command = new SqlCommand();
                Query = " Delete from tblInventory Where BookID = @BookID ";
                Command.Parameters.Add("@BookID", SqlDbType.Int).Value = BookID;
               
                Command.CommandText = Query;
                RowsAffected = ExecuteNonQuery(Command);
                if (RowsAffected > 0)
                {
                    Message = "1004 Success. Your Account has been Removed";
                }
                else
                {
                    Message = "-1004 Error Account Removal Failed";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message.ToString();
            }
            return RowsAffected;
        }
    }
}