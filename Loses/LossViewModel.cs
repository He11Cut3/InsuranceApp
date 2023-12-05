using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApp.Loses
{
	public class LossViewModel
	{
		public int ClaimID { get; set; }
		public string PolicyName { get; set; }
		public DateTime? ClaimDate { get; set; }
		public string Description { get; set; }
		public string ClaimStatus { get; set; }
	}
}
