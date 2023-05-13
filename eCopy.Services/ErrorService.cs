﻿using AutoMapper;
using eCopy.Model.Requests;
using eCopy.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services
{
    public class ErrorService : IErrorService
    {
        private readonly eCopyContext context;
        private readonly IMapper mapper;

        public ErrorService(eCopyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void AddError(ErrorRequest request)
        {

            var err = mapper.Map<Error>(request);

            context.Errors.Add(err);
            context.SaveChanges();
        }
    }
}
