﻿using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> findAll() 
        {
            return _context.seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindByid(int id) 
        {
            return _context.seller.Include(obj => obj.Departament).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id) 
        {
            var obj = _context.seller.Find(id);
            _context.seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj) 
        {
            if (!_context.seller.Any(x => x.Id == obj.Id)) 
            {
                throw new DirectoryNotFoundException("ID not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) 
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
    }
}
