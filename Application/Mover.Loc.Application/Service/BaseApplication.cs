using AutoMapper;
using IET.Common.Patterns.DomainNotification.Interface;

namespace Mover.Loc.Application.Service
{
    public abstract class BaseApplication
    {
        protected readonly INotify _notify;
        protected readonly IMapper _mapper;
        public BaseApplication(INotify notify, IMapper mapper)
        {
            _notify = notify;
            _mapper = mapper;
        } 
    }
}