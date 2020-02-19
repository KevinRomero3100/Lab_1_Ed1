﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_1.Models
{
    public class UploadFilesModel
    {
        public string Confirmation { get; set; }
        public Exception error { get; set; }

        public void UploadFile(string route, HttpPostedFileBase file)
        {
            try
            {
                file.SaveAs(route);
                this.Confirmation = "Archivo cargado en el servidor";
            }
            catch (Exception ex)
            {
                this.error = ex;
                throw;
            }
        }

    }
}