﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Queries.ProjectQuery
{
    public class ProjectQuery : IRequest<List<Project>>
    {
    }
}
