using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParcelDesk.Api.Data;
using ParcelDesk.Api.Models;

namespace ParcelDesk.Api.Services;

public class CustomerService
{
    private readonly ParcelDbContext _dbContext;

    public CustomerService(ParcelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _dbContext.Customers.AsNoTracking().OrderBy(customer => customer.Name).ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(customer => customer.Id == id);
    }

    public async Task<Customer> CreateAsync(string name,
                                            string phone,
                                            string? email,
                                            string address)
    {
        var customer = new Customer
        {
            Name = name.Trim(),
            Phone = phone.Trim(),
            Email = string.IsNullOrWhiteSpace(email) ? null : email.Trim(),
            Address = address.Trim()
        };
        
        _dbContext.Customers.Add(customer);

        await _dbContext.SaveChangesAsync();

        return customer;
    }

    public async Task<Customer?> UpdateAsync(int id,
                                             string name,
                                             string phone,
                                             string? email,
                                             string address)
    {
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(customer => customer.Id == id);

        if (customer is null)
        {
            return null;
        }

        customer.Name = name.Trim();
        customer.Phone = phone.Trim();
        customer.Email = string.IsNullOrWhiteSpace(email) ? null : email.Trim();
        customer.Address = address.Trim();

        await _dbContext.SaveChangesAsync();

        return customer;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(customer => customer.Id == id);

        if (customer is null)
        {
            return false;
        }

        _dbContext.Customers.Remove(customer);

        await _dbContext.SaveChangesAsync();

        return true;
    }
}