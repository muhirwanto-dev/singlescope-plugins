using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SingleScope.Sample.ViewModel
{
    public partial class ExampleViewModel2 : ObservableObject
    {
        [ObservableProperty]
        private bool _isTest = false;
    }
}
