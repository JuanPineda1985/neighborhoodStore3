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
    public class SaleController : ApiController
    {
        private neighborhoodStore3Context db = new neighborhoodStore3Context();

        // GET: api/Sale
        public IQueryable<Sales> GetSales()
        {
            return db.Sales;
        }

        // GET: api/Sale/5
        [ResponseType(typeof(Sales))]
        public async Task<IHttpActionResult> GetSales(int id)
        {
            Sales sales = await db.Sales.FindAsync(id);
            if (sales == null)
            {
                return NotFound();
            }

            return Ok(sales);
        }

        // PUT: api/Sale/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSales(int id, Sales sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sales.SalesID)
            {
                return BadRequest();
            }

            db.Entry(sales).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExists(id))
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

        // POST: api/Sale
        [ResponseType(typeof(Sales))]
        public async Task<IHttpActionResult> PostSales(Sales sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sales.Add(sales);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sales.SalesID }, sales);
        }

        // DELETE: api/Sale/5
        [ResponseType(typeof(Sales))]
        public async Task<IHttpActionResult> DeleteSales(int id)
        {
            Sales sales = await db.Sales.FindAsync(id);
            if (sales == null)
            {
                return NotFound();
            }

            db.Sales.Remove(sales);
            await db.SaveChangesAsync();

            return Ok(sales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesExists(int id)
        {
            return db.Sales.Count(e => e.SalesID == id) > 0;
        }
    }
}