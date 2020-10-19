﻿using AsmAppDev2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsmAppDev2.ViewModels
{
	public class AssignTrainertoTopicViewModels
	{
		public AssignTrainertoTopic assignTrainertoTopics { get; set; }
		public IEnumerable<ApplicationUser> Trainers { get; set; }
		public IEnumerable<Topic> Topics { get; set; }
	}
}