using InterfaceAbstractDemo.Abstract;
using InterfaceAbstractDemo.Adapters;
using InterfaceAbstractDemo.Concrete;
using InterfaceAbstractDemo.Entities;
using System;

namespace InterfaceAbstractDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseCustomerManager customerManager = new StarbucksCustomerManager(new MernisServiceAdapter());
            customerManager.Save(new Customer
            {
                FirstName = "Yasemin",
                DateOfBirth = new DateTime(1999, 3, 2),
                ID = 1,
                NationalityId = "11111111111",
                SecondName = "Gerboğa"
            });
        }
    }
}
