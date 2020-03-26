using System;
using System.Collections.Generic;
using MediatR;

namespace Nmro.IAM.Application.Resources.Commands
{
    public class CreateResourceCommand: IRequest<long>
    {
        public CreateResourceModel Model;
    }
}
