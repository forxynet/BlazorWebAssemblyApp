using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary {
    public class PeopleData : IPeopleData {
        private readonly ISqlDataAccess _db;
        public PeopleData(ISqlDataAccess db) {
            _db = db;
        }
        public Task<List<PersonModel>> GetPeople() {
            string sql = "select * from dbo.People";

            return _db.LoadData<PersonModel, dynamic>(sql, new { });
        }
        public Task InsertPerson(PersonModel person) {
            string sql = @"insert into dbo.People(FirstName,LastName,EmailAddress)" +
                                          "values(@FirstName,@LastName,@EmailAddress)";
            return _db.SaveData(sql, person);
        }
        public Task UpdatePerson(PersonModel person) {
            string sql = @"update dbo.People set FirstName=@FirstName, LastName=@LastName,EmailAddress=qEmailAddress WHERE Id=@Id";
            return _db.UpdateData(sql, person);
        }
        public Task DeletePerson(PersonModel person) {
            string sql = "delete dbo.Person where Id=@Id";
            return _db.DeletePerson(sql, person);
        }
    }
}
