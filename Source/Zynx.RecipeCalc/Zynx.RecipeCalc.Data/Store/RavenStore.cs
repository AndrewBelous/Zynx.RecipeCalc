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
	public sealed class RavenStore : IStore
	{
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
				{ DataDirectory = "App_Data", UseEmbeddedHttpServer = true, };
			_documentStore.Initialize();
		}

		public List<T> List<T>()
		{
			//	Since we know the number of 
			//		items being worked with is under 100, this is a safe assumption
			return List<T>(100);
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
		}

		public void Delete<T>(T item)
		{
			//get session
			var sess = _documentStore.OpenSession();
			sess.Delete(item);
		}
	}
}	//n
