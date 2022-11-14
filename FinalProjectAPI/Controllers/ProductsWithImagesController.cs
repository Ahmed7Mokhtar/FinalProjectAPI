using FinalProjectAPI.DTO;
using FinalProjectAPI.Services;
using FinalProjectDB.Models;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Collections;
using System.Buffers.Text;

namespace FinalProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsWithImagesController : ControllerBase
    {
        private readonly FinalProjectEntity context;
        private IWebHostEnvironment Environment;
        IConfiguration configuration;

        public ProductsWithImagesController(FinalProjectEntity context, IWebHostEnvironment environment, IConfiguration configuration)
        {
            this.context = context;
            Environment = environment;
            this.configuration = configuration;
        }

        //[HttpPost("AddProductWithImage")]
        //public IActionResult AddProduct()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ProductsWithImagesService PrdImg = new ProductsWithImagesService(context, Environment, configuration);
        //        var httpRequest = HttpContext.Request;
        //        PrdImg.Add(httpRequest);
        //        return StatusCode(201, "Created");
        //    }
        //    return BadRequest(ModelState);
        //}

        //[HttpGet("GetProductsWithImages")]
        //public IActionResult GetProducts()
        //{
        //    ProductsWithImagesService PrdImg = new ProductsWithImagesService(context, Environment, configuration);
        //    return Ok(PrdImg.GetAll());
        //}

        [HttpGet("GetAllProducts")]
        public IActionResult GetAll()
        {
            var products = context.البضاعه.ToList();

            List<ProductsWithImagesDTO> productsList = new List<ProductsWithImagesDTO>();
            foreach (var item in products)
            {
                productsList.Add(new ProductsWithImagesDTO
                {
                    location = item.ImageName,
                    buyingPrice = item.سعر_الشراء.ToString(),
                    disc = item.الوصف,
                    quantity = item.اجمالي_الكميه.ToString(),
                    productName = item.اسم_الصنف,
                    sellingPrice = item.سعر_البيع.ToString(),
                    category = item.نوع_الصنف,
                    id = item.رقم_الصنف,
                });
            }

            return Ok(productsList);
        }

        [HttpGet("GetProductsByCategory/{category:alpha}")]
        public IActionResult GetWithCategory(string category)
        {
            if(ModelState.IsValid)
            {
                var products = context.البضاعه.Where(p => p.نوع_الصنف == category).ToList();

                var responseProducts = new List<ProductsWithImagesDTO>();
                foreach (var item in products)
                {
                    responseProducts.Add(new ProductsWithImagesDTO
                    {
                        location = item.ImageName,
                        buyingPrice = item.سعر_الشراء.ToString(),
                        disc = item.الوصف,
                        quantity = item.اجمالي_الكميه.ToString(),
                        productName = item.اسم_الصنف,
                        sellingPrice = item.سعر_البيع.ToString(),
                        category = item.نوع_الصنف,
                        id = item.رقم_الصنف,
                    });
                }

                return Ok(responseProducts);
            }

            return BadRequest(ModelState);
        }


        [HttpGet("GetOneProduct/{id:int}")]
        public IActionResult GetOneProduct(int id)
        {
            var product = context.البضاعه.FirstOrDefault(p => p.رقم_الصنف == id);
            if(product != null)
            {
                var responseProduct = new ProductsWithImagesDTO
                {
                    location = product.ImageName,
                    buyingPrice = product.سعر_الشراء.ToString(),
                    disc = product.الوصف,
                    quantity = product.اجمالي_الكميه.ToString(),
                    productName = product.اسم_الصنف,
                    sellingPrice = product.سعر_البيع.ToString(),
                    category = product.نوع_الصنف,
                    id = product.رقم_الصنف,
                };

                return Ok(responseProduct);
            }

            return BadRequest("No Product Found!");
        }


        [HttpPost("UploadImage/{id:int}")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadProduct(int id)
        {
            //if (!Request.Form.Files.Any())
            //    return BadRequest("No files found in the request");
            if (Request.Form.Files[0].Length <= 0)
                return BadRequest("Invalid file length, seems to be empty");

            try
            {
                string webRootPath = Environment.WebRootPath;
                string uploadsDir = Path.Combine(webRootPath, "uploads");

                if (!Directory.Exists(uploadsDir))
                    Directory.CreateDirectory(uploadsDir);

                IFormFile file = Request.Form.Files[0];
                string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string fullPath = Path.Combine(uploadsDir, fileName);

                var buffer = 1024 * 1024;
                using var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, buffer, useAsync: false);
                await file.CopyToAsync(stream);
                await stream.FlushAsync();

                string location = $"http://rooneya-001-site1.htempurl.com/uploads/{fileName}";
                //string location = $"http://localhost:5253/uploads/{fileName}";

                var prd = context.البضاعه.FirstOrDefault(p => p.رقم_الصنف == id);
                prd.ImageName = location;
                context.SaveChanges();

                var result = new
                {
                    message = "Upload successful",
                    url = location
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Upload failed: " + ex.Message);
            }
        }


        [HttpPost("AddProductWinForm")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> AddProductImageBytes(ProductFromFormWithImage newProduct)
        {
            if(ModelState.IsValid)
            {

                string webRootPath = Environment.WebRootPath;
                string uploadsDir = Path.Combine(webRootPath, "uploads");

                if (!Directory.Exists(uploadsDir))
                    Directory.CreateDirectory(uploadsDir);

                //string fileName = newProduct.imageName.Trim('"');
                //string fullPath = Path.Combine(uploadsDir, fileName);

                var str = new MemoryStream(newProduct.bytes);
                IFormFile file = new FormFile(str, 0, newProduct.bytes.Length, newProduct.imageName, newProduct.imageName);
                //string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string fileName = newProduct.imageName.Trim('"');
                string fullPath = Path.Combine(uploadsDir, fileName);

                var buffer = 1024 * 1024;
                using var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, buffer, useAsync: false);
                await file.CopyToAsync(stream);
                await stream.FlushAsync();

                string location = $"http://rooneya-001-site1.htempurl.com/uploads/{fileName}";
                //string location = $"http://localhost:5253/uploads/{fileName}";

                context.البضاعه.Add(new البضاعه
                {
                    ImageName = location,
                    اجمالي_الكميه = newProduct.quantity,
                    سعر_الشراء = newProduct.buyingPrice,
                    سعر_البيع = newProduct.sellingPrice,
                    الوصف = newProduct.disc,
                    اسم_الصنف = newProduct.productName,
                    نوع_الصنف = newProduct.category,
                });

                context.SaveChanges();

                return StatusCode(201, "Created");
            }

            return BadRequest("bad");
        }


        //[HttpPost("NewOne")]
        //[DisableRequestSizeLimit]
        //public async Task<IActionResult> UploadFile()
        //{
        //    if (!Request.Form.Files.Any())
        //        return BadRequest("No files found in the request");

        //    if (Request.Form.Files.Count > 1)
        //        return BadRequest("Cannot upload more than one file at a time");

        //    if (Request.Form.Files[0].Length <= 0)
        //        return BadRequest("Invalid file length, seems to be empty");

        //    try
        //    {
        //        string webRootPath = Environment.WebRootPath;
        //        string uploadsDir = Path.Combine(webRootPath, "uploads");

        //        // wwwroot/uploads/
        //        if (!Directory.Exists(uploadsDir))
        //            Directory.CreateDirectory(uploadsDir);

        //        IFormFile file = Request.Form.Files[0];
        //        string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //        string fullPath = Path.Combine(uploadsDir, fileName);

        //        var buffer = 1024 * 1024;
        //        using var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, buffer, useAsync: false);
        //        await file.CopyToAsync(stream);
        //        await stream.FlushAsync();

        //        string location = $"http://rooneya-001-site1.htempurl.com/uploads/{fileName}";

        //        var result = new
        //        {
        //            message = "Upload successful",
        //            url = location
        //        };

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Upload failed: " + ex.Message);
        //    }
        //}
    }
}
