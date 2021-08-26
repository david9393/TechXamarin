using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTest.ViewModels.Domain
{
    public class TipViewModel : BindableBase
    {
        [DoNotNotify]
        public Guid TipId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
    }
}
