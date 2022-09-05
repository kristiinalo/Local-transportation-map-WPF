using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Local_transportation_map_WPF
{
    public class Program
    {
        public string GPSFileurl = "https://transport.tallinn.ee/gps.txt";
        public string tmp = System.IO.Path.GetTempPath() + "GPSRAW.csv";

        public byte[] DownloadFile(string GPSFileurl)
        {
            return new WebClient().DownloadData(GPSFileurl);
        }

        public List<ModelGPS> FillClass()
        {
            List<ModelGPS> records;
            Stream webstream = new MemoryStream(DownloadFile(GPSFileurl));
            StreamReader reader = new StreamReader(webstream);

            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture);
            config.HasHeaderRecord = false;

            CsvReader csv = new CsvReader(reader, config);

            records = csv.GetRecords<ModelGPS>().ToList();

            return records;
        }
    }
}
