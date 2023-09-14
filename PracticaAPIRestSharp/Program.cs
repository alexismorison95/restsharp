// See https://aka.ms/new-console-template for more information
using RestSharp;
using System.Text.Json.Nodes;
using System.Text.Json;
using PracticaAPIRestSharp;

Console.WriteLine("Hello, World!");

//defino la URL base a consultar
string cBaseUrl = "https://testapi.jasonwatmore.com";

//instancio el objeto RestClient
var client = new RestClient(cBaseUrl);

//instacio la solitud para obtener todos los productos
var request = new RestRequest("products");

//ejecuto la consulta a la API y obtengo la respuesta
var response = await client.ExecuteGetAsync(request);


//transformo el string Json en una lista de productos
var data = JsonSerializer.Deserialize<IEnumerable<Product>>(response.Content!)!;

//itero por cada producto de la lista
foreach (var item in data)
{
    Console.WriteLine($"id: {item.Id}, name: {item.Name}");
}

Console.Write("Ingrese un id: ");
var id = Console.ReadLine();

Console.WriteLine($"su id es: {id}");

//instacio la solitud para obtener un producto según su id
var request2 = new RestRequest($"products/{id}");

//ejecuto la consulta a la API y obtengo la respuesta
var response2 = await client.ExecuteGetAsync(request2);


//transformo el string Json en un producto
var data2 = JsonSerializer.Deserialize<Product>(response2.Content!)!;

Console.WriteLine($"id: {data2.Id}, name: {data2.Name}");
