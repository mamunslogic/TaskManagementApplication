using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Queries.TaskQuery
{
    public class TaskQuery : IRequest<List<TaskInfo>>
    {
    }
}
