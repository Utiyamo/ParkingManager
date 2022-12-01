using Dapper;
using ParkingMaganer.Data.Interface;
using ParkingMaganer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMaganer.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSession _session;

        public UserRepository(DbSession session)
        {
            _session = session;
        }

        public List<UserModels> Get()
        {
            return _session.Connection.Query<UserModels>("SELECT * FROM [dbo].[Users]", null, _session.Transaction).ToList();
        }

        public UserModels Get(string name)
        {
            return _session.Connection.Query<UserModels>("SELECT * FROM [dbo].[Users] WHERE Name = @Name", name, _session.Transaction).FirstOrDefault();
        }

        public UserModels GetById(int id)
        {
            return _session.Connection.Query<UserModels>("SELECT * FROM [dbo].[Users] WHERE Id = @Id", id, _session.Transaction).FirstOrDefault();
        }

        public List<UserModels> GetByRole(string role)
        {
            return _session.Connection.Query<UserModels>("SELECT * FROM [dbo].[Users] WHERE Roles = @Roles", role, _session.Transaction).ToList();
        }

        public List<UserModels> GetByRoles(string[] roles)
        {
            return _session.Connection.Query<UserModels>("SELECT * FROM [dbo].[Users] WHERE Roles IN @Roles", roles, _session.Transaction).ToList();
        }

        public void Add(UserModels model)
        {
            _session.Connection.Execute($@"
                INSERT INTO [dbo].[Users] (Name, Password, Roles)
                VALUES (@Name, @Password, @Roles);", model, _session.Transaction);
        }

        public void Delete(int id)
        {
            _session.Connection.Execute($@"DELETE FROM [dbo].[Users] WHERE Id = @Id", id, _session.Transaction);
        }

        public UserModels Update(UserModels model)
        {
            _session.Connection.Execute($@"
                UPDATE [dbo].[Users] 
                    SET
                        Name = @Name,
                        Password = @Password,
                        Roles = @Roles
                WHERE
                    Id = @Id
            ", model, _session.Transaction);

            return _session.Connection.Query<UserModels>("SELECT * FROM [dbo].[Users] WHERE Id = @Id", model.Id, _session.Transaction).FirstOrDefault();
        }
    }
}
