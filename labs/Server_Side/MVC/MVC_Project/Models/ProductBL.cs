namespace MVC_Project.Models
{
    public class ProductBL
    {
        List<Product> products = new List<Product>();

        public ProductBL()
        {
            products.Add(new Product { Id = 1, Name = "Replacement Voice Remote Control (2nd GEN) L5B83H", Price = 1050, ImageUrl = "product1.jpg" });
            products.Add(new Product { Id = 2, Name = "Universal Remote Control Replacement for Samsung Smart-TV", Price = 870, ImageUrl = "product2.jpg" });
            products.Add(new Product { Id = 3, Name = "Universal Remote Control Compatible for Samsung Smart-TV", Price = 676, ImageUrl = "product3.jpg" });
        }


        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
}
