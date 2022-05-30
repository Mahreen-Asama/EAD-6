namespace WebApplication3
{

    public class Program {

        public static void Main(string[] args)
        {
            //insert
            var context=new MVC_DatabaseContext();
            Product product=new Product();
            product.Id = 1;
            product.Name = "PC";
            context.Products.Add(product);
            context.SaveChanges();

            //update
            var pro=context.Products.First();
            pro.Name = "Laptop";
            context.SaveChanges();

            //delete
            var pro2 = context.Products.First();
            context.Products.Remove(pro);
            context.SaveChanges();

            //read
            var query = context.Products.Where(p => p.Name == "Mobile");
            foreach(var item in query)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("helo");
        }
    }

}
