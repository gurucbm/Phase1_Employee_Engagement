using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Core.Data
{
    public class EnumValue<T, V>
    {
		public EnumValue()
			: base()
		{ }

		public EnumValue(T Id, V Value)
			: this()
		{
			this.Id = Id;

			this.Value = Value;
		}

		public T Id { get; set; }

		public V Value { get; set; }
	}
}
