using FinalProjectAPI.DTO;
using FinalProjectDB.Models;
using FinalProjectModels.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FinalProjectAPI.Services
{
    public class ProductsWithImagesService
    {
        private readonly FinalProjectEntity context;
        private IWebHostEnvironment Environment;
        IConfiguration configuration;

        public ProductsWithImagesService(FinalProjectEntity _context, IWebHostEnvironment environment, IConfiguration configuration)
        {
            context = _context;
            Environment = environment;
            this.configuration = configuration;
        }

        public int Add(HttpRequest httpRequest)
        {
            var postedFile = httpRequest.Form.Files["Image"];

            string NewNameOfile = Guid.NewGuid().ToString() + postedFile.FileName;

            FileStream str = new FileStream
            (
                Path.Combine(Directory.GetCurrentDirectory(), "images", NewNameOfile)
                , FileMode.OpenOrCreate, FileAccess.ReadWrite
            );

            str.Position = 0;

            context.البضاعه.Add(new البضاعه
            {
                الوصف = httpRequest.Form["Disc"],
                اسم_الصنف = httpRequest.Form["ProductName"],
                اجمالي_الكميه = int.Parse(httpRequest.Form["Quantity"]),
                سعر_البيع = double.Parse(httpRequest.Form["BuyingPrice"]),
                سعر_الشراء = double.Parse(httpRequest.Form["SellingPrice"]),
                ImageName = NewNameOfile,
            });

            postedFile.CopyTo(str);
            str.Close();

            context.SaveChanges();

            return 1;
        }

        public List<ProductsWithImagesDTO> GetAll()
        {
            var products = context.البضاعه.ToList();

            //string path = Environment.ContentRootPath;

            List<ProductsWithImagesDTO> productsDTO = new List<ProductsWithImagesDTO>();

            foreach (var item in products)
            {
                //Byte[] bytesImage = System.IO.File.ReadAllBytes(path + "/images/" + item.ImageName);
                string url = configuration.GetSection("imgUrl").Value + '/' + item.ImageName; 
                productsDTO.Add(new ProductsWithImagesDTO
                {
                    //رقم_الصنف = item.رقم_الصنف,
                    quantity = item.اجمالي_الكميه.ToString(),
                    productName = item.اسم_الصنف,
                    disc = item.الوصف,
                    buyingPrice = item.سعر_الشراء.ToString(),
                    sellingPrice = item.سعر_البيع.ToString(),
                    //bytes = url,
                });
            }

            return productsDTO;
        }
    }
}
