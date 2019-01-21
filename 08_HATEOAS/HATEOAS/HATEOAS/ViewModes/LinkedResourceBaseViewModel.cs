using System.Collections.Generic;
using HATEOAS.DomainModel;

namespace HATEOAS.ViewModes
{
    public abstract class LinkedResourceBaseViewModel : EntityBase
    {
        public List<LinkViewModel> Links { get; set; } = new List<LinkViewModel>();
    }

    public class LinkedCollectionResourceWrapperViewModel<T> : LinkedResourceBaseViewModel
        where T : LinkedResourceBaseViewModel
    {
        public LinkedCollectionResourceWrapperViewModel(IEnumerable<T> value)
        {
            Value = value;
        }

        public IEnumerable<T> Value { get; set; }
    }
}