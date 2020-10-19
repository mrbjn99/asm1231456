﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsmAppDev2.Models
{
	public class AssignTrainertoTopic
	{
		[Key]
		public int ID { get; set; }
		public string TrainerID { get; set; }
		public ApplicationUser Trainer { get; set; }
		public int TopicID { get; set; }
		public Topic Topic { get; set; }
	}
}