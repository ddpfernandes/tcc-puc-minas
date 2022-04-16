using MediatR;
using Seedwork.DomainObjects;
using Supplier.Domain;

namespace Supplier.Application.Commands
{
    public class CreateSupplierCommand : IRequest<CreateSupplierCommandResponse>
    {
        public CreateSupplierCommand(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }     
    }

    public class CreateSupplierCommandResponse
    {
        public CreateSupplierCommandResponse(Guid id, string name, string address, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }   
    }

    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, CreateSupplierCommandResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _uow;

        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, 
                                        IUnitOfWork uow)
        {
            _supplierRepository = supplierRepository;
            _uow = uow;
        }

        public async Task<CreateSupplierCommandResponse> Handle(CreateSupplierCommand command, CancellationToken cancellationToken)
        {
            var supplier = new Supplier.Domain.Supplier(command.Name, command.Address, command.Phone);

            _supplierRepository.Add(supplier);
            await _uow.Commit();

            return new CreateSupplierCommandResponse(supplier.Id, supplier.Name, supplier.Address, supplier.Phone);            
        }
    }
}