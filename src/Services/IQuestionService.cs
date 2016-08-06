﻿using Qubiz.QuizEngine.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qubiz.QuizEngine.Services
{
	public interface IQuestionService
	{

        void DeleteQuestion(Guid id);
		Task<Database.Models.PagedResult<Database.Models.QuestionListItem>> GetQuestionsByPage(int pagenumber);

	}
}