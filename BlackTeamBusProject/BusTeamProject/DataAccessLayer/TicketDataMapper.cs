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
    public class TicketDataMapper : IDataMapper<Ticket, int>
    {
        SqlCommand _command;

        public TicketDataMapper()
        {
            _command = SqlHelper.createSqlCommand();
        }

        public Ticket Get(int key)
        {
            /*             
                create proc sp_GetTicketByID
                @id int
                as
                select ID,PassengerID,RouteMapID,TravelID,EmployeeID,BusSeatID,CreateTicketDate,PaymentID from Ticket where ID=@id                       
             */
            _command.CommandText = "sp_GetTicketByID";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", key);
            Ticket ticket = new Ticket();
            List<Ticket> ticketList = new List<Ticket>();
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
                            
                        ticket.ID = Convert.ToInt32(reader["ID"]);
                        ticket.PassangerID = Convert.ToInt32(reader["PassengerID"]);
                        ticket.RouteMapID = Convert.ToInt32(reader["RouteMapID"]);
                        ticket.TravelID = Convert.ToInt32(reader["TravelID"]);
                        ticket.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                        ticket.BusSeatID = Convert.ToInt32(reader["BusSeatID"]);
                        ticket.CreateTicketDate = Convert.ToDateTime(reader["CreateTicketDate"]);
                        ticket.PaymentID = Convert.ToInt32(reader["PaymentID"]);

                        ticketList.Add(ticket);
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Ticketları getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }


            return ticket;
        }

        public List<Ticket> GetAll()
        {
            /*             
                create proc sp_GetAllTicket
                as
                select ID,PassengerID,RouteMapID,TravelID,EmployeeID,BusSeatID,CreateTicketDate,PaymentID from Ticket                        
             */

            List<Ticket> ticketList = new List<Ticket>();
            _command.CommandText = "sp_GetAllTicket";
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
                        Ticket ticket = new Ticket();
                        ticket.ID = Convert.ToInt32(reader["ID"]);
                        ticket.PassangerID = Convert.ToInt32(reader["PassengerID"]);
                        ticket.RouteMapID = Convert.ToInt32(reader["RouteMapID"]);
                        ticket.TravelID = Convert.ToInt32(reader["TravelID"]);
                        ticket.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                        ticket.BusSeatID = Convert.ToInt32(reader["BusSeatID"]);
                        ticket.CreateTicketDate = Convert.ToDateTime(reader["CreateTicketDate"]);
                        ticket.PaymentID = Convert.ToInt32(reader["PaymentID"]);

                        ticketList.Add(ticket);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ticket listesinde getirirken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }
            return ticketList;
        }

        public int Insert(Ticket item)
        {
            int affectedRows = 0;
            /*  
                create proc sp_AddTicket
                @passengerId int,
                @routeMapId int,
                @travelId int,
                @employeeId int,
                @busSeatId int,
                @createTicketDate datetime,
                @paymentId int
                as
                begin
                Insert into Ticket(PassengerID,RouteMapID,TravelID,EmployeeID,BusSeatID,CreateTicketDate,PaymentID) values(@passengerId,@routeMapId,@travelId,@employeeId,@busSeatId,@createTicketDate,@paymentId)
                end             
             */
            _command.CommandText = "sp_AddTicket";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@passengerId", item.PassangerID);
            _command.Parameters.AddWithValue("@routeMapId", item.RouteMapID);
            _command.Parameters.AddWithValue("@travelId", item.TravelID);
            _command.Parameters.AddWithValue("@employeeId", item.EmployeeID);
            _command.Parameters.AddWithValue("@busSeatId", item.BusSeatID);
            _command.Parameters.AddWithValue("@createTicketDate", item.CreateTicketDate);
            _command.Parameters.AddWithValue("@paymentId", item.PaymentID);


            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Ticket Insert yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Update(Ticket item)
        {
            /*
                create proc sp_UpdateTicket
                @id int,
                @passengerId int,
                @routeMapId int,
                @travelId int,
                @employeeId int,
                @busSeatId int,
                @createTicketDate datetime,
                @paymentId int
                as
                begin
                Update Ticket set  PassengerID=@passengerId,RouteMapID=@routeMapId,TravelID=@travelId,EmployeeID=@employeeId,BusSeatID=@busSeatId,CreateTicketDate=@createTicketDate,PaymentID=@paymentId where ID=@id
                end
           */

            
            _command.CommandText = "sp_UpdateTicket";
            _command.CommandType = CommandType.StoredProcedure;

            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("@id", item.ID);
            _command.Parameters.AddWithValue("@passengerId", item.PassangerID);
            _command.Parameters.AddWithValue("@routeMapId", item.RouteMapID);
            _command.Parameters.AddWithValue("@travelId", item.TravelID);
            _command.Parameters.AddWithValue("@employeeId", item.EmployeeID);
            _command.Parameters.AddWithValue("@busSeatId", item.BusSeatID);
            _command.Parameters.AddWithValue("@createTicketDate", item.CreateTicketDate);
            _command.Parameters.AddWithValue("@paymentId", item.PaymentID);
            int affectedRows = 0;

            try
            {
                if (_command.Connection.State == System.Data.ConnectionState.Closed)
                    _command.Connection.Open();


                affectedRows = _command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Ticket Update yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }

        public int Delete(Ticket item)
        {
            /*
                create proc sp_DeleteTicket
                @id int
                as
                begin
                Delete from Ticket where ID=@id
                end
          */


            int affectedRows = 0;

            _command.CommandText = "sp_DeleteTicket";
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
                throw new Exception("Ticket Delete yaparken bir sorun oluştu" + ex.Message);
            }
            finally
            {
                _command.Connection.Close();
            }

            return affectedRows;
        }
    }
}
