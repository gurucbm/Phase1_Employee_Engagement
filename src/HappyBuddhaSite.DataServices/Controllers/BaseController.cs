using HappyBuddhaSite.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace HappyBuddhaSite.DataServices.Controllers
{
	public abstract class BaseController<Key, Type>
		: ODataController
		where Type : class
	{
		public BaseController()
			: base()
		{
			this.DataContext = new HappyBuddhaContext();
		}

		protected HappyBuddhaContext DataContext
		{
			get; private set;
		}

		protected abstract DbSet<Type> Set { get; }

		protected abstract Func<Type, Key, Boolean> IsEqualToKey { get; }

		private bool ProductExists(Key key)
		{
			return this.Set.Any(p => this.IsEqualToKey(p, key));
		}

		[EnableQuery]
		public IQueryable<Type> Get()
		{
			return this.Set;
		}

		[EnableQuery]
		public SingleResult<Type> Get([FromODataUri] Key key)
		{
			IQueryable<Type> result = this.Set.Where(p => this.IsEqualToKey(p, key));

			return SingleResult.Create(result);
		}

		public async Task<IHttpActionResult> Post(Type product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			this.Set.Add(product);

			await this.DataContext.SaveChangesAsync();

			return Created(product);
		}

		public async Task<IHttpActionResult> Patch([FromODataUri] Key key, Delta<Type> product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var entity = await this.Set.FindAsync(key);

			if (entity == null)
			{
				return NotFound();
			}

			product.Patch(entity);

			try
			{
				await this.DataContext.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductExists(key))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return Updated(entity);
		}
		public async Task<IHttpActionResult> Put([FromODataUri] Key key, Type update)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (!this.IsEqualToKey(update, key))
			{
				return BadRequest();
			}

			this.DataContext.Entry(update).State = EntityState.Modified;

			try
			{
				await this.DataContext.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductExists(key))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return Updated(update);
		}

		public async Task<IHttpActionResult> Delete([FromODataUri] Key key)
		{
			var product = await this.Set.FindAsync(key);

			if (product == null)
			{
				return NotFound();
			}

			this.Set.Remove(product);

			await this.DataContext.SaveChangesAsync();

			return StatusCode(HttpStatusCode.NoContent);
		}

		protected override void Dispose(bool disposing)
		{
			this.DataContext.Dispose();

			base.Dispose(disposing);
		}
	}
}