using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dormitory
{
	static class ExtensionMethods
	{
		// Добавление возможности работать с null-значениями в элементе DateTimePicker.
		// Если check box элемента DateTime равен false, то идет работа со значением null.
		#region Nullable DateTimePicker 
		public static DateTime? NullableValue(this DateTimePicker dtp)
		{
			return dtp.Checked ? dtp.Value : (DateTime?)null;
		}

		public static void NullableValue(this DateTimePicker dtp, DateTime? value)
		{
			dtp.Checked = value.HasValue;
			if (value.HasValue) dtp.Value = value.Value;
		}
		#endregion
	}
}
