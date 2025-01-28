using AutoMapper;
using STAPI.Core.DTOs.Customer;
using STAPI.Core.DTOs.Job;
using STAPI.Core.DTOs.Offer;
using STAPI.Core.DTOs.Sale;
using STAPI.Core.DTOs.Stock;
using STAPI.Core.DTOs.StockMove;
using STAPI.Core.DTOs.Transactions;
using STAPI.Core.Entities;

namespace STAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity -> DTO ve DTO -> Entity dönüşümleri
            CreateMap<Offer, OfferDto>();
            CreateMap<OfferDto, Offer>().ForMember(x => x.CreatedTime, opt => opt.Ignore())
                //.ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.UpdatedTime, opt => opt.Ignore())
                .ForMember(x => x.DeletedTime, opt => opt.Ignore())
                .ForMember(x => x.IsActive, opt => opt.Ignore())
                .ForMember(x => x.IsDeleted, opt => opt.Ignore())
                .ForMember(x => x.Jobs, opt => opt.Ignore());

            //CreateMap<Offer, AddOffer>().ReverseMap();
            //CreateMap<Offer, UpdateOffer>().ReverseMap();

            CreateMap<Job, JobDto>();
            CreateMap<JobDto, Job>().ForMember(x => x.CreatedTime, opt => opt.Ignore())
               //.ForMember(x => x.Id, opt => opt.Ignore())
               .ForMember(x => x.UpdatedTime, opt => opt.Ignore())
               .ForMember(x => x.DeletedTime, opt => opt.Ignore())
               .ForMember(x => x.IsActive, opt => opt.Ignore())
               .ForMember(x => x.IsDeleted, opt => opt.Ignore())
               .ForMember(x => x.Transactions, opt => opt.Ignore());

            //CreateMap<Job, AddJob>().ReverseMap();
            //CreateMap<Job, UpdateJob>().ReverseMap();

            CreateMap<Sale, SaleDto>();
            CreateMap<SaleDto, Sale>()
                  .ForMember(x => x.UpdatedTime, opt => opt.Ignore())
               .ForMember(x => x.DeletedTime, opt => opt.Ignore())
               .ForMember(x => x.IsActive, opt => opt.Ignore())
               .ForMember(x => x.IsDeleted, opt => opt.Ignore());
            //CreateMap<Sale, AddSale>().ReverseMap();
            //CreateMap<Sale, UpdateSale>().ReverseMap();

            CreateMap<Stock, StockDto>();
            CreateMap<StockDto, Stock>().ForMember(x => x.UpdatedTime, opt => opt.Ignore())
               .ForMember(x => x.DeletedTime, opt => opt.Ignore())
               .ForMember(x => x.IsActive, opt => opt.Ignore())
               .ForMember(x => x.IsDeleted, opt => opt.Ignore())
               .ForMember(x => x.StockMovements, opt => opt.Ignore());

            //CreateMap<Stock, AddStock>().ReverseMap();
            //CreateMap<Stock, UpdateStock>().ReverseMap();

            CreateMap<StockMovement, StockMovementDto>();
            CreateMap<StockMovementDto, StockMovement>()
                  .ForMember(x => x.UpdatedTime, opt => opt.Ignore())
               .ForMember(x => x.DeletedTime, opt => opt.Ignore())
               .ForMember(x => x.IsActive, opt => opt.Ignore())
               .ForMember(x => x.IsDeleted, opt => opt.Ignore());
            //CreateMap<StockMovement, AddStockMove>().ReverseMap();
            //CreateMap<StockMovement, UpdateStockMove>().ReverseMap();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>()
                 .ForMember(x => x.UpdatedTime, opt => opt.Ignore())
               .ForMember(x => x.DeletedTime, opt => opt.Ignore())
               .ForMember(x => x.IsActive, opt => opt.Ignore())
               .ForMember(x => x.IsDeleted, opt => opt.Ignore());
            //CreateMap<Customer, AddCustomer>().ReverseMap();
            //CreateMap<Customer, UpdateCustomer>().ReverseMap();

            CreateMap<Transaction, TransactionDto>();
            CreateMap<TransactionDto, Transaction>().ForMember(x => x.UpdatedTime, opt => opt.Ignore())
               .ForMember(x => x.DeletedTime, opt => opt.Ignore())
               .ForMember(x => x.IsActive, opt => opt.Ignore())
               .ForMember(x => x.IsDeleted, opt => opt.Ignore());

            //CreateMap<Transaction, AddTransaction>().ReverseMap();
            //CreateMap<Transaction, UpdateTransaction>().ReverseMap();


        }
    }
}
