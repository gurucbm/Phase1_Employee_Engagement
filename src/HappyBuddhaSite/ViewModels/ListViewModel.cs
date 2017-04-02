using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.ViewModels
{
    public class ListViewModel<T>
    {
		public ListViewModel(IEnumerable<T> Items)
		{
			this.Items = Items;
		}

		public IEnumerable<T> Items { get; private set; }
	}
}
