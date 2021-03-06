﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels;


namespace Kulagin.MasteringWPF.ViewModels {
    public class SpreadsheetViewModel : BaseViewModel {
        private DataRowCollection dataRowCollection = null;

        public SpreadsheetViewModel() {
            Cell[] Cells = new Cell[9];
            Cells[0] = new Cell("A1", "", 64);
            Cells[1] = new Cell("B1", "", 96);
            Cells[2] = new Cell("C1", "", 64);
            Cells[3] = new Cell("A2", "", 64);
            Cells[4] = new Cell("B2", "Hello World", 96);
            Cells[5] = new Cell("C2", "", 64);
            Cells[6] = new Cell("A3", "", 64);
            Cells[7] = new Cell("B3", "", 96);
            Cells[8] = new Cell("C3", "", 64);
            DataTable table = new DataTable();
            table.Columns.Add("A", typeof(Cell));
            table.Columns.Add("B", typeof(Cell));
            table.Columns.Add("C", typeof(Cell));
            table.Rows.Add(Cells[0], Cells[1], Cells[2]);
            table.Rows.Add(Cells[3], Cells[4], Cells[5]);
            table.Rows.Add(Cells[6], Cells[7], Cells[8]);
            Rows = table.Rows;
        }

        public DataRowCollection Rows {
            get { return dataRowCollection; }
            set {
                if (dataRowCollection != value) {
                    dataRowCollection = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}