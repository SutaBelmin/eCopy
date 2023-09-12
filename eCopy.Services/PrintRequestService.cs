using AutoMapper;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace eCopy.Services
{
    public class PrintRequestService : BaseCRUDService<PrintRequestR, Request, PrintRequestSearch, eCopy.Model.Requests.PrintRequest, eCopy.Model.Requests.PrintRequestUpdate>, IPrintRequestService
    {
        private IHttpContextAccessor httpContextAccessor;
        private readonly IFileService fileService;
        public PrintRequestService(eCopyContext context, IMapper mapper, 
            IHttpContextAccessor httpContextAccessor,
            IFileService fileService) : base(context, mapper)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.fileService = fileService;
        }


        public IEnumerable<PrintRequestR> GetAllR()
        {
            var entity = context.Requests
                .Include(x=>x.CollatedPrintOption)
                .Include(x=>x.SidePrintOption)
                .Include(x=>x.PagePerSheet)
                .Include(x=>x.Letter)
                .Include(x=> x.Orientation)
                .Include(x=> x.PrintPageOption)
                .AsQueryable();


            var list = entity.ToList();

            return mapper.Map<IList<PrintRequestR>>(list);
        }

        public override PrintRequestR GetById(int id)
        {
            var result = base.GetById(id);

            var files = context.PrintRequestFiles.Where(x=> x.RequestId == id).FirstOrDefault();

            if(files != null)
            {
                result.FilePath = files.Name;
            }

            var payment = context.Payment.FirstOrDefault(x => x.RequestId == id);
            if (payment != null)
            {
                result.PaymentId = payment.Id;

                result.PaymentInfo = new PaymentResponse
                {
                    Amount = payment.Amount,
                    Created = payment.Created,
                    StripePaymentId = payment.StripePaymentId
                };
            }

            return result;
        }


        public override IEnumerable<PrintRequestR> Get(PrintRequestSearch search = null)
        {
            var clientIdClaim = httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == "ClientId");

            var entity = context.Requests.Include(x=> x.Client).ThenInclude(x=> x.Person).AsQueryable();

            if (int.TryParse(clientIdClaim?.Value, out int clientId))
            {
                entity = entity.Where(x => x.ClientId == clientId);
            }
            
            if(!string.IsNullOrEmpty(search.Status))
            {
                entity = entity.Where(x=> x.Status == search.Status);
            }

            var list = entity.ToList();

            return mapper.Map<IList<PrintRequestR>>(list);
        }

        public override PrintRequestR Insert(PrintRequest insert)
        {
            var clientIdClaim = httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == "ClientId");
            var clientId = int.Parse(clientIdClaim.Value);

            Request model = mapper.Map<Request>(insert);
            model.ClientId = clientId;
            model.CopierId = 1;
            model.RequestDate = DateTime.Now;
            model.CreatedDate= DateTime.Now; 
            context.Requests.Add(model);
            context.SaveChanges();

            if (insert.File != null)
            {
                var memoryStream = new MemoryStream();
                insert.File.CopyTo(memoryStream);

                string extension = insert.PrintRequestFile?.Extension ?? string.Empty;
                if (string.IsNullOrEmpty(extension))
                {
                    extension = Path.GetExtension(insert.File.FileName);
                }

                var uploadedFile = fileService.Upload(memoryStream.ToArray(), extension);
                context.PrintRequestFiles.Add(new PrintRequestFile
                {
                    Active = true,
                    CreatedDate = DateTime.Now,
                    Extension = uploadedFile.Extension,
                    ModifiedDate = DateTime.Now,
                    Name = uploadedFile.Name,
                    Path = uploadedFile.Url,
                    RequestId = model.Id,
                });
            }
            context.SaveChanges();
            return mapper.Map<PrintRequestR>(model); 
        }

        public PrintRequestR Pay(int id, PaymentRequest model)
        {
            var request = context.Requests.FirstOrDefault(x => x.Id == id);
            request.IsPaid = true;
            context.Payment.Add(new Database.Payment
            {
                RequestId = id,
                Amount = Convert.ToDecimal(request.Price),
                Created = DateTime.Now,
                StripePaymentId = model.StripePaymentId
            });
            context.SaveChanges();

            return mapper.Map<PrintRequestR>(request);
        }

        public PrintRequestR UpdateRequest(int id, UpdateRequest update)
        {
            var request = context.Requests.FirstOrDefault(x => x.Id == id);
            if (request != null)
            {
                mapper.Map(update, request);
                context.SaveChanges();
            }
            return mapper.Map<PrintRequestR>(request);
        }

        public void CancelRequest(int id)
        {
            var request = context.Requests.FirstOrDefault(x => x.Id == id);
            if(request!=null)
            {
                request.Status = "Canceled";
                context.SaveChanges();
            }
        }

    }
}
