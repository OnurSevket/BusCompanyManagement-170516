using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntitiesLayer;

namespace BusinessLogicLayer
{
    public class EmployeeBussiness : IBussinessLayer<Employee, int>
    {

        EmployeeDataMapper _employeeMapper = new EmployeeDataMapper();

        public bool DeleteBLL(Employee item)
        {
            int affectedRows = 0;
            bool result = false;

            if (item != null)
            {
                affectedRows = _employeeMapper.Delete(item);
                if (affectedRows > 0)
                {
                    result = affectedRows > 0;
                    return result;
                }
            }
            else throw new Exception("lütfen seçim yapınız |Employee #Delete +002");
            return result;
        }

        public List<Employee> GetAllBLL()
        {
            List<Employee> employeeList = _employeeMapper.GetAll();
            if (employeeList.Count > -1)
                return employeeList;

            else
                throw new Exception("lütfen seçim yapınız |ListEmploye #GetAll +002");
        }

        public Employee GetBLL(int key)
        {
            Employee _employee;
            if (key > 0)
            {
                return _employee = _employeeMapper.Get(key);
            }
            else
                throw new Exception("Hatalı id Degeri +002 ");
        }

        public bool SaveBLL(Employee item)
        {
            
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (string.IsNullOrWhiteSpace(item.Email))  //Email
                {
                    throw new Exception("Email boş geçilemez |Employee #Save +002");
                }
                if (string.IsNullOrWhiteSpace(item.FirstName))
                {
                    throw new Exception("isim alanı boş geçilemez |Employe #Save +002");
                }
                if (string.IsNullOrWhiteSpace(item.LastName))
                {
                    throw new Exception("Soyisim Boş geçilemez |Employee #Save +002");
                }
                if (item.Gender == null)   
                {
                    throw new Exception("Gender Boş geçilemez |Employee #Save +002");
                }
                if (string.IsNullOrWhiteSpace(item.SocialNumber))
                {
                    throw new Exception("tc.no boş geçilemez |Employee #Save +002");
                }
                if (item.StartWorkDate == null)
                {
                    throw new Exception("DateTime Boş geçilemez |Employee #Save +002");
                }
                if (item.FinishWorkDate < item.StartWorkDate)
                {
                    throw new Exception("Bitiş degeri başlangıç degerinden küçük olamaz |Employee #Save +002 ");
                }
                if (item.RoleID <= 0|| item.RoleID == null )   
                {
                    throw new Exception("Role Id Boş geçilemez |Employee #Save +002");
                }
                if(string.IsNullOrWhiteSpace(item.Telephone))
                {
                    throw new Exception("Telefona Boşgeçilemez  |Employee #Save +002 ");
                }
                if (item.IsAvaible == null)   
                {
                    throw new Exception("Çalışma durumu  |Employee #Save +002");
                }

                affectedRows = _employeeMapper.Insert(item);  //degerleri Insert et

                if (affectedRows > 0)
                    result = affectedRows > 0;
                else
                    throw new Exception("Kayıt Başarısız |Employee #Save +002 ");
            }
                
            
            
            return result ; // bunu kontrol et
        }

        public bool UpdateBLL(Employee item)
        {
            int affectedRows = 0;
            bool result = false;
            if (item != null)
            {
                if (string.IsNullOrWhiteSpace(item.Email))  //Email
                {
                    throw new Exception("Email boş geçilemez |Employee #Update +002");
                }
                if (string.IsNullOrWhiteSpace(item.FirstName))
                {
                    throw new Exception("isim alanı boş geçilemez |Employe #Update +002");
                }
                if (string.IsNullOrWhiteSpace(item.LastName))
                {
                    throw new Exception("Soyisim Boş geçilemez |Employee #Update +002");
                }
                if (item.Gender == null)
                {
                    throw new Exception("Gender Boş geçilemez |Employee #Update +002");
                }
                if (string.IsNullOrWhiteSpace(item.SocialNumber))
                {
                    throw new Exception("tc.no boş geçilemez |Employee #Update +002");
                }
                if (item.StartWorkDate == null)
                {
                    throw new Exception("DateTime Boş geçilemez |Employee #Update +002");
                }
                if (item.FinishWorkDate < item.StartWorkDate)
                {
                    throw new Exception("Bitiş degeri başlangıç degerinden küçük olamaz |Employee #Update +002 ");
                }
                if (item.CreatedEmployeeID <= 0 || item.CreatedEmployeeID == null)
                {
                    throw new Exception("Bir employee Id verilmelidir |Employee #Update +002");
                }
                if (item.RoleID <= 0 || item.RoleID == null)
                {
                    throw new Exception("Role Id Boş geçilemez |Employee #Update +002");
                }
                if (string.IsNullOrWhiteSpace(item.Telephone))
                {
                    throw new Exception("Telefona Boşgeçilemez  |Employee #Update +002 ");
                }
                if (item.IsAvaible == null)
                {
                    throw new Exception("Çalışma durumu  |Employee #Update +002");
                }

                affectedRows = _employeeMapper.Update(item);  //degerleri Insert et

                if (affectedRows > 0)
                    result = affectedRows > 0;
                else
                    throw new Exception("Güncelleme Başarısız |Employee #Update +002 ");
            }



            return result; // bunu kontrol et
        }
    }
}
