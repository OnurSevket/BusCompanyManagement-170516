using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
  public  class PaymentDataMapper : IDataMapper<Payment, int>
    {
        SqlCommand _command;

        public PaymentDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }

        public Payment Get(int key)
        {

            /*
                create proc sp_GetPaymentByID
                @id int
                as
                select ID,TotalPrice,PaymentTypeID,CreatePaymentDate from Payment where ID=@id
             */

            _command.CommandText = "sp_GetPaymentByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", key);
            
           
            try
            {
                Payment payment = new Payment();

                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    _command.Connection.Open();
                }
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        payment.ID = (int)reader[0];
                        payment.TotalPrice = (decimal)reader[1];
                        payment.PaymentTypeID = (int)reader[2];
                        payment.CreatePaymentDate = Convert.ToDateTime(reader[3]);

                        
                    }
                }
                return payment;

            }
            catch (Exception ex)
            {

                throw new Exception("Payment getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }


           
        }

        public List<Payment> GetAll()
        {
            /*             
                create proc sp_GetAllPayment
                as
                select ID,TotalPrice,PaymentTypeID,CreatePaymentDate from Payment                      
             */

            List<Payment> paymentList = new List<Payment>();
            _command.CommandText = "sp_GetAllPayment";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();

            try
            {

                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                {
                    _command.Connection.Open();
                }
                SqlDataReader reader = _command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Payment payment = new Payment();
                        payment.ID = (int)reader[0];
                        payment.TotalPrice = (decimal)reader[1];
                        payment.PaymentTypeID = (int)reader[2];
                        payment.CreatePaymentDate = Convert.ToDateTime(reader[3]);

                        paymentList.Add(payment);
                    }
                }
                return paymentList;
                
            }
            catch (Exception ex)
            {

                throw new Exception("Payment listesinde getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            
        }

        public int Insert(Payment item)
        {
           
            /*  
                create proc sp_InsertPayment
                @totalPrice decimal,
                @paymentTypeID int,
                @createPaymentDate datetime
                as
                begin
                Insert into Payment(TotalPrice,PaymentTypeID,CreatePaymentDate) values(@totalPrice,@paymentTypeID,@createPaymentDate)
                end    
                         
             */
            _command.CommandText = "sp_InsertPayment";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@totalPrice", item.TotalPrice);
            _command.Parameters.AddWithValue("@paymentTypeID", item.PaymentTypeID);
            _command.Parameters.AddWithValue("@createPaymentDate", item.CreatePaymentDate);
            int affectedRows = 0;
            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Payment Insert yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Update(Payment item)
        {
            /*
              
                create proc sp_UpdatePayment
                @id int,
                @totalPrice decimal,
                @paymentTypeID int,
                @createPaymentDate datetime
                as
                begin
                Update Payment set TotalPrice=@totalPrice,PaymentTypeID=@paymentTypeID,CreatePaymentDate=@createPaymentDate where ID=@id
                end

             */

            int affectedRows = 0;
            _command.CommandText = "sp_UpdatePayment";
            _command.CommandType = CommandType.StoredProcedure;

            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", item.ID);
            _command.Parameters.AddWithValue("@totalPrice", item.TotalPrice);
            _command.Parameters.AddWithValue("@paymentTypeID", item.PaymentTypeID);
            _command.Parameters.AddWithValue("@createPaymentDate", item.CreatePaymentDate);


            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Payment Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Delete(Payment item)
        {
            /*
                create proc sp_DeletePayment
                @id int
                as
                begin
                Delete from Payment where ID=@id
                end
            */


            int affectedRows = 0;

            _command.CommandText = "sp_DeletePayment";
            _command.CommandType = CommandType.StoredProcedure;


            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", item.ID);

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Payment Delete yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;

        }
    }
}
