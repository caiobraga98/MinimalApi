using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/caio", () => "Hello World by Caio!");
app.MapGet("/getproduct", () => "Hello World by Caio!");
app.MapPost("/insertproduct", (Product product) =>
{
    ProductRepository.Add(product);
});
app.MapGet("/getproduct/{code}", ([FromRoute] string code) =>
{
    var product = ProductRepository.GetBy(code);
    return product;
});

app.MapPut("/changeproduct", (Product product) =>
{
   var produto = ProductRepository.GetBy(product.Code);
    produto.Name = product.Name;
});


app.Run();

public static class ProductRepository
{
    public static List<Product> Products { get; set; }
    //método de adição
    public static void Add(Product product)
    {
        if (Products == null)
            Products = new List<Product>();
        Products.Add(product);
    }
    //método de buscar produto
    public static Product GetBy(string code)
    {
        return Products.FirstOrDefault(p => p.Code == code);
    }

}

public class Product
{
    public string Code { get; set; }
    public string Name { get; set; }
}