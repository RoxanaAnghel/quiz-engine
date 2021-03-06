﻿using System;

namespace Qubiz.QuizEngine.Areas.M.Models
{
	public class Question
	{
		public Guid ID { get; set; }

		public string QuestionText { get; set; }

		public Guid SectionID { get; set; }

		public byte Complexity { get; set; }

		public QuestionType Type { get; set; }

		public int Number { get; set; }

		public Option[] Options { get; set; }
	}

	public enum QuestionType
	{
		SingleSelect, MultiSelect
	}
}