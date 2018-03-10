using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VivaWebAPI.Class;
using VivaWebAPI.Models;

namespace VivaWebAPI.Services
{
    public class ReadFileService : IDisposable
    {
        ExcelWorksheet _workSheet = null;
        public ReadFileService(int category_id)
        {
            string fileName = (category_id == (int)Constants.FILE_NAME.SOLVENTS) ? Constants.CATEGORY_NAME_1 : Constants.CATEGORY_NAME_2;
            string path = System.Web.HttpContext.Current.Request.MapPath("~\\Excel\\" + fileName);
            ExcelPackage package = new ExcelPackage(new FileInfo(path));
            _workSheet = package.Workbook.Worksheets.FirstOrDefault();
        }

        public  async Task<IList<Product>> GetProductAsyn(bool firstRowHeader)
        {
            var data = await Task.Run(() => GetProduct(firstRowHeader)).ConfigureAwait(false);
            return data;

        }

        public IList<Product> GetProduct(bool firstRowHeader)
        {
            IList<Product> productList = new List<Product>();

            if (_workSheet != null)
            {
                Dictionary<string, int> header = new Dictionary<string, int>();

                for (int rowIndex = _workSheet.Dimension.Start.Row; rowIndex <= _workSheet.Dimension.End.Row; rowIndex++)
                {

                    if (rowIndex == 1 && firstRowHeader)
                    {
                        header = ExcelHelper.GetExcelHeader(_workSheet, rowIndex);
                    }
                    else
                    {
                        productList.Add(new Product
                        {
                            _thai_name = ExcelHelper.ParseWorksheetValue(_workSheet, header, rowIndex, "productname"),
                            _eng_name = ExcelHelper.ParseWorksheetValue(_workSheet, header, rowIndex, "productname"),
                            _volume = ExcelHelper.ParseWorksheetValue(_workSheet, header, rowIndex, "value"),
                            _package = ExcelHelper.ParseWorksheetValue(_workSheet, header, rowIndex, "package"),
                            _origin = ExcelHelper.ParseWorksheetValue(_workSheet, header, rowIndex, "origin"),
                            _category_id = ExcelHelper.ParseWorksheetValue(_workSheet, header, rowIndex, "catid"),
                            _sub_Category_id = ExcelHelper.ParseWorksheetValue(_workSheet, header, rowIndex, "subcatid"),
                            _id = Convert.ToInt32(ExcelHelper.ParseWorksheetValue(_workSheet, header, rowIndex, "productid"))
                        });

                    }
                }
            }

            return productList;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _workSheet = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ReadFileService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}