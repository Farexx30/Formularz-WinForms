using FormularzWinForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularzWinForms.Presenters
{ 
    public interface IEmployeePresenter
    {
        void HandleAddToListBox();
    }

    public class EmployeePresenter : IEmployeePresenter
    {
        private readonly IEmployee _employee = null!;
        private readonly IEmployeeView _employeeView = null!;

        public EmployeePresenter(IEmployee employee)//, IEmployeeView employeeView)
        {
            _employee = employee;
            //_employeeView.AddToListBox += HandleAddToListBox;
        }

        public void HandleAddToListBox()
        {
            MessageBox.Show("klik");
        }
    }
}
