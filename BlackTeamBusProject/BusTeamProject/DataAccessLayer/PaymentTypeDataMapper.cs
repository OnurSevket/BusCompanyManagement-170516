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
    public class PaymentTypeDataMapper : IDataMapper<PaymentType, int>
    {
        SqlCommand _command;

        public PaymentTypeDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }

        public PaymentType Get(int key)
        {
            /*             
                create proc sp_GetPaymentTypeByID
                @id int
                as
                select ID,PaymentyTypeName from PaymentType where ID=@id  
                                     
             */
            _command.CommandText = "sp_GetPaymentTypeByID";
            _command.CommandType = CommandType.StoredProcedure;

            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", key);
            PaymentType paymentType = new PaymentType();
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

                        paymentType.ID = (int)reader["ID"];
                        paymentType.PaymentTypeName = reader.GetString(1);
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("PaymentTypeları getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }


            return paymentType;
        }

        public List<PaymentType> GetAll()
        {
            /*             
                    create proc sp_GetAllPaymentType
                    as
                    select ID,PaymentyTypeName from PaymentType                       
              */

            List<PaymentType> paymentTypeList = new List<PaymentType>();
            _command.CommandText = "sp_GetAllPaymentType";
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
                        PaymentType paymentType = new PaymentType();
                        paymentType.ID = (int)reader["ID"];
                        paymentType.PaymentTypeName = reader.GetString(1);

                        paymentTypeList.Add(paymentType);
                    }
                }
              
            }
            catch (Exception ex)
            {

                throw new Exception("PaymentType listesinde getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return paymentTypeList;
        }

        public int Insert(PaymentType item)
        {
            int affectedRows = 0;
            /*  
                create proc sp_InsertPaymentType
                @paymentTypeName nvarchar(50)
                as
                begin
                Insert into PaymentType(PaymentyTypeName) values(@paymentTypeName)
                end             
             */
            _command.CommandText = "sp_InsertPaymentType";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@paymentTypeName", item.PaymentTypeName);

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("PaymentType Insert yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Update(PaymentType item)
        {

            /*              
                create proc sp_UpdatePaymentType
                @id int,
                @paymentTypeName nvarchar(50)
                as
                begin
                Update PaymentType set PaymentyTypeName=@paymentTypeName where ID=@id
                end
            */

            int affectedRows = 0;
            _command.CommandText = "sp_UpdatePaymentType";
            _command.CommandType = CommandType.StoredProcedure;

            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@paymentTypeName", item.PaymentTypeName);
            _command.Parameters.AddWithValue("@id", item.ID);


            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("PaymentType Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Delete(PaymentType item)
        {
            /*
                create proc sp_DeletePaymentType
                @id int
                as
                begin
                Delete from PaymentType where ID=@id
                end
           */


            int affectedRows = 0;

            _command.CommandText = "sp_DeletePaymentType";
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
                throw new Exception("PaymentType Delete yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }


    }
}
