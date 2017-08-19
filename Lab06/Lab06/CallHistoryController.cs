using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Lab06
{
    public partial class CallHistoryController : UITableViewController
    {
        public List<string> PhoneNumbers;
        protected NSString CallHistoryCellID = new NSString("CallHistoryCell");

        public CallHistoryController(IntPtr handle) : base(handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), CallHistoryCellID);
            TableView.Source = new CallHistoryDataSource(this);
        }

        class CallHistoryDataSource : UITableViewSource
        {
            CallHistoryController _controller;

            public CallHistoryDataSource(CallHistoryController controller)
            {
                // Almacena la instancia del UITableViewController
                _controller = controller;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                // Devuelve un UITableViewCell reutilizable creado con el identificador
                // Controller.CallHistoryCellID
                var cell = tableView.DequeueReusableCell(_controller.CallHistoryCellID);
                // Asignar el contenido a mostrar en la celda
                cell.TextLabel.Text = _controller.PhoneNumbers[indexPath.Row];
                // Devolver la celda
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return _controller.PhoneNumbers.Count;
            }
        }
    }
}