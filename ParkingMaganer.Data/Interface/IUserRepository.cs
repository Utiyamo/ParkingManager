using ParkingMaganer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMaganer.Data.Interface
{
    public interface IUserRepository
    {
        public List<UserModels> Get();
        public UserModels Get(string name);
        public UserModels GetById(int id);
        public List<UserModels> GetByRole(string role);
        public List<UserModels> GetByRoles(string[] roles);
        public void Add(UserModels model);
        public UserModels Update(UserModels model);
        public void Delete(int id);
    }
}
