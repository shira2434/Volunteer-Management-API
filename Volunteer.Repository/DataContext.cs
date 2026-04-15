using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Entities;

namespace Volunteer.Repository
{
    public static class DataContext
    {
        public static List<MyVolunteer> Volunteers { get; set; }=new List<MyVolunteer>() { 
        new MyVolunteer(){ Id=1,FirstName="Yael",LastName="Gutman" },
        new MyVolunteer(){ Id=2,FirstName="Yehudit",LastName="Vaiss"} };
    }
}
