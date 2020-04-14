using System;
using System.Configuration;
using System.Data;

namespace ConsoleApp
{
    class Program
    {
        public static string conStr { get; set; }

        static void Main(string[] args)
        {
            conStr = ConfigurationManager.ConnectionStrings[0].ConnectionString;

            DataSet dataSet = CreateTables();

            ViewTables(dataSet);
            AddRecordsTrackEvaluationPart(dataSet.Tables["TrackEvaluationPart"]);
            ViewRow(dataSet.Tables["TrackEvaluationPart"]);

            Console.ReadKey();
        }
        private static DataSet CreateTables()
        {
            DataSet dataSet = new DataSet("Track");

            DataTable dataTable = new DataTable("TrackEvaluationPart");
            dataSet.Tables.Add(dataTable);

            DataColumn PK_EvaluationPartId = new DataColumn("EvaluationPartId", Type.GetType("System.Int32"));
            PK_EvaluationPartId.Unique = true;
            PK_EvaluationPartId.AllowDBNull = false;
            PK_EvaluationPartId.AutoIncrement = true;
            PK_EvaluationPartId.AutoIncrementSeed = 1;
            PK_EvaluationPartId.AutoIncrementStep = 1;

            DataColumn FK_ComponentId = new DataColumn("ComponentId", Type.GetType("System.Int32"));
            DataColumn FK_PMCheckListPartId = new DataColumn("PMCheckListPartId", Type.GetType("System.Int32"));
            DataColumn Quantity = new DataColumn("Quantity", Type.GetType("System.Single"));
            DataColumn UnitCostTrack = new DataColumn("UnitCostTrack", Type.GetType("System.Single"));
            DataColumn Description = new DataColumn("Description", Type.GetType("System.String"));

            dataTable.Columns.Add(PK_EvaluationPartId);
            dataTable.Columns.Add(FK_ComponentId);
            dataTable.Columns.Add(FK_PMCheckListPartId);
            dataTable.Columns.Add(Quantity);
            dataTable.Columns.Add(UnitCostTrack);
            dataTable.Columns.Add(Description);

            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["EvaluationPartId"] };

            DataTable dataTable1 = new DataTable("TrackComponent");
            dataSet.Tables.Add(dataTable1);

            DataColumn PK_ComponentId = new DataColumn("ComponentId", Type.GetType("System.Int32"));
            PK_ComponentId.Unique = true;
            PK_ComponentId.AllowDBNull = false;
            PK_ComponentId.AutoIncrement = true;
            PK_ComponentId.AutoIncrementSeed = 1;
            PK_ComponentId.AutoIncrementStep = 1;

            DataColumn until = new DataColumn("Until", Type.GetType("System.String"));
            DataColumn totalUnits = new DataColumn("TotalUnits", Type.GetType("System.Int32"));

            dataTable1.Columns.Add(PK_ComponentId);
            dataTable1.Columns.Add(until);
            dataTable1.Columns.Add(totalUnits);

            dataTable1.PrimaryKey = new DataColumn[] { dataTable1.Columns["PK_ComponentId"] };
            
            DataTable dataTable2 = new DataTable("PMChecklistPart");
            dataSet.Tables.Add(dataTable2);

            DataColumn PK_PMChecklistPartId = new DataColumn("PMChecklistPartId", Type.GetType("System.Int32"));
            PK_PMChecklistPartId.Unique = true;
            PK_PMChecklistPartId.AllowDBNull = false;
            PK_PMChecklistPartId.AutoIncrement = true;
            PK_PMChecklistPartId.AutoIncrementSeed = 1;
            PK_PMChecklistPartId.AutoIncrementStep = 1;

            DataColumn dataColumn = new DataColumn("Quantity", Type.GetType("System.Int32"));
            dataColumn.AllowDBNull = false;

            DataColumn PartDescrtiption = new DataColumn("PartDescrtiption", Type.GetType("System.String"));

            dataTable2.Columns.Add(PK_PMChecklistPartId);
            dataTable2.Columns.Add(dataColumn);
            dataTable2.Columns.Add(PartDescrtiption);

            dataTable2.PrimaryKey = new DataColumn[] { dataTable2.Columns["PK_PMChecklistPartId"] };

            ForeignKeyConstraint FKConstraint = new ForeignKeyConstraint("FK_TrackEvaluationPart_TrackComponent",
                                                    dataSet.Tables["TrackComponent"].Columns["ComponentId"],
                                                    dataSet.Tables["TrackEvaluationPart"].Columns["ComponentId"]);

            dataSet.Tables["TrackEvaluationPart"].Constraints.Add(FKConstraint);

            FKConstraint = new ForeignKeyConstraint("FK_TrackEvaluationPart_PMChecklistPart",
                                                    dataSet.Tables["PMChecklistPart"].Columns["PMChecklistPartId"],
                                                    dataSet.Tables["TrackEvaluationPart"].Columns["PMChecklistPartId"]);

            dataSet.Tables["TrackEvaluationPart"].Constraints.Add(FKConstraint);

            return dataSet;
        }

        private static void ViewTables(DataSet ds)
        {
            foreach (DataTable dataTable in ds.Tables)
            {
                Console.WriteLine("Таблица: " + dataTable.TableName);
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    Console.WriteLine($"{dataColumn.ColumnName}, {dataColumn.DataType}");
                }
            }
        }

        private static void ViewRow(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    Console.WriteLine($"{dataTable.Columns[j].ColumnName} : {dataTable.Rows[i].ItemArray[j]}");
                }
                Console.WriteLine();
            }
        }

        private static void AddRecordsTrackEvaluationPart(DataTable dataTable)
        {
            DataRow dataRow = dataTable.NewRow();
            dataRow.ItemArray = new object[] { null, null, null, 20, 50.0, "check1" };

            dataTable.Rows.Add(dataRow);
            dataTable.Rows.Add(new object[] { null, null, null, 30, 43.5, "check2" });
        }


        
    }
}
