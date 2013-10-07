using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raven.Client;
using Raven.Client.Embedded;
using Raven.Database.Server;

namespace Zynx.RecipeCalc.Data.Store
{
	/// <summary>
	/// Class is sealed in order to prevent subclassing in order to maintain only
	/// one instance of <see cref="RavenStoreImp">RavenStoreImp</see>
	/// </summary>
	public sealed class RavenStore : IStore
	{
		//the store is declared static so that there is only one per application domain.
		private static RavenStoreImp _store = new RavenStoreImp();

		#region IStore Members
		public T Load<T>(int id)
		{
			return _store.Load<T>(id);
		}

		public void Store<T>(T item)
		{
			//noun, then verb. :)
			_store.Store(item);
		}

		public void Delete<T>(T item)
		{
			_store.Delete(item);
		}

		public List<T> List<T>()
		{
			//	Since we know the number of 
			//		items being worked with is under 100, this is a safe assumption
			return _store.List<T>(100);
		}

		public List<T> List<T>(int limit)
		{
			return _store.List<T>(limit);
		}
		#endregion
	}	//c

	internal class RavenStoreImp
	{
		private IDocumentStore _documentStore = null;

		public IDocumentStore DocumentStore
		{
			get { return _documentStore; }
		}

		public RavenStoreImp()
		{
			_documentStore = new EmbeddableDocumentStore 
				{ DataDirectory = "App_Data", };
			_documentStore.Initialize();
		}

		public List<T> List<T>(int limit)
		{
			var res = new List<T>();

			//get session
			var sess = _documentStore.OpenSession();
			//TODO: paging :)
			//TODO: order by
			res = sess.Query<T>()
                .Customize(x=>x.WaitForNonStaleResults())
                .Take(limit).ToList(); 

			return res;
		}

		public T Load<T>(int id)
		{
			T res = default(T);

			//get session
			var sess = _documentStore.OpenSession();
			res = sess.Load<T>(id);

			return res;
		}

		public void Store<T>(T item)
		{
			//get session
			var sess = _documentStore.OpenSession();
			sess.Store(item);
			sess.SaveChanges();
		}

		public void Delete<T>(T item)
		{
			//get session
			var sess = _documentStore.OpenSession();
			sess.Delete(item);
			sess.SaveChanges();
		}
	}
}	//n
