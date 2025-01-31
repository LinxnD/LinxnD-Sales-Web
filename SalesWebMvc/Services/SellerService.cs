using SalesWebMvc.Data;
using SalesWebMvc.Models;

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
            obj.Departament = _context.Departament.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
