using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dormitory
{
	class LinkLabelModified : LinkLabel
	{
		public int residentId { get; set; }
		public int roomId { get; set; }

		public LinkLabelModified() : base()
		{
			
		}

		public LinkLabelModified(int residentId = 0, int roomId = 0) : base()
		{
			this.residentId = residentId;
			this.roomId = roomId;
		}
	}
}
