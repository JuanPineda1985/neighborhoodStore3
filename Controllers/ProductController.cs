using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using neighborhoodStore3.Data;
using neighborhoodStore3.Models;

namespace neighborhoodStore3.Controllers
{
    public class ProductController : ApiController
    {
        private neighborhoodStore3Context db = new neighborhoodStore3Context();

        // GET: api/Product
        public IQueryable<ProductDTO> GetProducts()
        {
            var products = from b in db.Products
                          select new ProductDTO()
                          {
                              ProductID = b.ProductID,
                              ProductName = b.ProductName,
                              Price = b.Price
                          };
            return products;
        }

        // GET: api/Product/5
        [ResponseType(typeof(ProductDetailDTO))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            var product = await db.Products.Include(b => b.ProductName).Select(b => new ProductDetailDTO()
            {
                ProductID = b.ProductID,
                Brand = b.Brand,
                ProductName = b.ProductName,
                Price = b.Price
            }).SingleOrDefaultAsync(b => b.ProductID == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Product/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Product
        [ResponseType(typeof(ProductDetailDTO))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            // New Code:
            // Load Product name

            db.Entry(product).Reference(x => x.ProductName).Load();

            var dto = new ProductDetailDTO()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Price = product.Price
            };
            
            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, dto);
        }

        // DELETE: api/Product/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}