using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class TicketBussiness : IBussinessLayer<Ticket, int>
    {
        TicketDataMapper _ticketDataMapper = new TicketDataMapper();

        public List<Ticket> GetAllBLL()
        {
            List<Ticket> allTicket = _ticketDataMapper.GetAll();
            if (allTicket.Count > -1)
            {
                return allTicket;
            }
            else
            {
                throw new Exception("allTicket listesi boş geliyor ");
            }
        }

        public Ticket GetBLL(int key)
        {
            if (key > 0)
            {
                Ticket ticket = _ticketDataMapper.Get(key);
                return ticket;
            }
            else
            {
                throw new Exception("lütfen seçim yapınız");
            }
        }

        public bool SaveBLL(Ticket item)
        {
            int affecttedRows;
            if (item != null)
            {

               

                if (item.RouteMapID <= 0 || item.RouteMapID == null)
                {
                    throw new Exception("Ticket RouteMapID Save yapılamadı + 002 ");
                }

                if (item.TravelID <= 0 || item.TravelID == null)
                {
                    throw new Exception("Ticket TravelID Save yapılamadı + 002 ");
                }

                if (item.EmployeeID <= 0 || item.EmployeeID == null)
                {
                    throw new Exception("Ticket EmployeeID Save yapılamadı + 002 ");
                }

                if (item.BusSeatID <= 0 || item.BusSeatID == null)
                {
                    throw new Exception("Ticket BusSeatID Save yapılamadı + 002 ");
                }

                if (item.PaymentID <= 0 || item.PaymentID == null)
                {
                    throw new Exception("Ticket PaymentID Save yapılamadı + 002 ");
                }

                affecttedRows = _ticketDataMapper.Insert(item);
                if (affecttedRows > 0)
                    return affecttedRows > 0;
                else
                    throw new Exception("Ticket veri tabanında Hiçbir kayıt etkilenmedi #Insert");
            }
            else
            {
                throw new Exception("Ticket'da item boş geliyor,Save yapılamadı  + 002 ");
            }
        }

        public bool UpdateBLL(Ticket item)
        {
            int affecttedRows;
            if (item != null)
            {
                if (item.ID <= 0 || item.ID == null)
                {
                    throw new Exception("Ticket ID Save yapılamadı + 002 ");
                }

                if (item.PassangerID <= 0 || item.PassangerID == null)
                {
                    throw new Exception("Ticket PassangerID Save yapılamadı + 002 ");
                }

                if (item.RouteMapID <= 0 || item.RouteMapID == null)
                {
                    throw new Exception("Ticket RouteMapID Save yapılamadı + 002 ");
                }

                if (item.TravelID <= 0 || item.TravelID == null)
                {
                    throw new Exception("Ticket TravelID Save yapılamadı + 002 ");
                }

                if (item.EmployeeID <= 0 || item.EmployeeID == null)
                {
                    throw new Exception("Ticket EmployeeID Save yapılamadı + 002 ");
                }

                if (item.BusSeatID <= 0 || item.BusSeatID == null)
                {
                    throw new Exception("Ticket BusSeatID Save yapılamadı + 002 ");
                }

                if (item.PaymentID <= 0 || item.PaymentID == null)
                {
                    throw new Exception("Ticket PaymentID Save yapılamadı + 002 ");
                }

                affecttedRows = _ticketDataMapper.Update(item);
                if (affecttedRows > -1)
                    return affecttedRows > -1;
                else
                    throw new Exception("Ticket veri tabanında Hiçbir kayıt etkilenmedi #Update");

            }
            else
            {
                throw new Exception("Ticket'da item boş geliyor,Save yapılamadı  + 002 ");
            }
        }

        public bool DeleteBLL(Ticket item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                affectedRows = _ticketDataMapper.Delete(item);
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                    return result;
                }

            }
            else
                throw new Exception("lütfen seçim yapınız");
            return result;
        }


    }
}
