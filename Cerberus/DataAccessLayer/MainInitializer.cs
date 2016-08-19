using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cerberus.DataAccessLayer
{
    public class MainInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MainContext>
    {
        //protected override void Seed(MainContext mainContext)
        //{
        //    Person adminPerson = new Person { Name = "Konrad", Surname = "Janowski", Email = "janowski92@gmail.com" };
        //    Person userPerson = new Person { Name = "Franek", Surname = "Kimono", Email = "konrad.janowski@idealogic.pl" };
        //    Person janKowalskiPerson = new Person { Name = "Jan", Surname = "Kowalski", Email = "janeczek666@dupa.com" };
        //    Person zbigniewWodeckiPerson = new Person { Name = "Zbigniew", Surname = "Wodecki", Email = "zbigniew@zbysiu.com" };
        //    Person paniJadziaPerson = new Person { Name = "Pani", Surname = "Jadzia", Email = "panijadzia@gmail.com" };
        //    mainContext.Persons.Add(adminPerson);
        //    mainContext.Persons.Add(userPerson);
        //    mainContext.SaveChanges();

        //    UserRole adminRole = new UserRole { Name = "Administrator" };
        //    UserRole userRole = new UserRole { Name = "Użytkownik" };
        //    mainContext.UserRoles.Add(adminRole);
        //    mainContext.UserRoles.Add(userRole);
        //    mainContext.SaveChanges();

        //    UserInfo adminUserInfo = new UserInfo { CreateDate = DateTime.Now, Login = "admin", UserName = "Administrator", PersonId = adminPerson.Id, RoleId = adminRole.Id };
        //    UserInfo userUserInfo = new UserInfo { CreateDate = DateTime.Now, Login = "user", UserName = "Użytkownik", PersonId = userPerson.Id, RoleId = userRole.Id };
        //    mainContext.UserInfos.Add(adminUserInfo);
        //    mainContext.UserInfos.Add(userUserInfo);
        //    mainContext.SaveChanges();
        //}
    }
}