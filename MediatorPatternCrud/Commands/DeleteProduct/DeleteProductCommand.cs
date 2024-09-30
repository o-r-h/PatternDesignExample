﻿using MediatR;

namespace MediatorPatternCrud.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
