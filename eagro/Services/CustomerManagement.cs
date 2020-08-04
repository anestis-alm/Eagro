using eagro.Models;
using eagro.Options;
using eagro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eagro.Services
{
    public class CustomerManagement : ICustomerManager
    {

        private EagroDbContext db;

        public CustomerManagement(EagroDbContext _db)
        {
            db = _db;
        }
        public Customer CreateCustomer(CustomerOption custOption)
        {
            Customer customer = new Customer
            {
                FirstName = custOption.FirstName,
                LastName = custOption.LastName,
                Username = custOption.Username,
                Password = custOption.Password,
                Email = custOption.Email,
                Dob = custOption.Dob,
                Phone = custOption.Phone,
                Active = true,
                Balance = 0,
                Role = "customer",
            };

            db.Customers.Add(customer);
            db.SaveChanges();

            return customer;
        }

        public Customer FindCustomerById(int customerId)
        {
            return db.Customers.Find(customerId);
        }

        public string CustomerName(int customerId)
        {
            Customer customer = db.Customers.Find(customerId);
            return customer.FirstName;
        }

        public Customer FindCustomerByEmail(CustomerOption custOption)
        {
            if (custOption == null) return null;
            if (custOption.Email == null) return null;

            return db.Customers
                .Where(cust => cust.Email == custOption.Email)
                .FirstOrDefault();
        }

        public List<Customer> FindCustomerByName(CustomerOption custOption)
        {
            return db.Customers
                .Where(cust => cust.LastName == custOption.LastName)
                .Where(cust => cust.FirstName == custOption.FirstName)
                .ToList();
        }

        public Customer FindCustomerByLoginDetails(CustomerOption custOption)
        {
            return db.Customers
                .Where(c => c.Username == custOption.Username)
                .Where(c => c.Password == custOption.Password)
                .FirstOrDefault();
        }

        public Customer Update(CustomerOption custOption, int customerId)
        {

            Customer customer = db.Customers.Find(customerId);

            if (custOption.FirstName != null)
                customer.FirstName = custOption.FirstName;
            if (custOption.LastName != null)
                customer.LastName = custOption.LastName;
            if (custOption.Email != null)
                customer.Email = custOption.Email;
            if (custOption.Password != null)
                customer.Password = custOption.Password;
            if (custOption.Username != null)
                customer.Username = custOption.Username;
            if (custOption.Phone != null)
                customer.Phone = custOption.Phone;
            if (custOption.Dob != new DateTime())
                customer.Dob = custOption.Dob;

            db.SaveChanges();
            return customer;
        }

        public bool DeleteCustomerById(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SoftDeleteCustomerById(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer != null)
            {
                customer.Active = false;
                db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
