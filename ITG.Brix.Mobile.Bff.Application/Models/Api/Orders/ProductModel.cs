﻿using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Application.Models.Api
{
    public class ProductModel
    {
        public ConfigurationModel Configuration { get; set; }
        public IEnumerable<string> Remarks { get; set; }
        public IEnumerable<string> SafetyRemarks { get; set; }
        public IEnumerable<string> Notes { get; set; }
        public string Code { get; set; }
        public string Customer { get; set; }
        public string Arrival { get; set; }
        public string Article { get; set; }
        public string ArticlePackagingCode { get; set; }
        public string Name { get; set; }
        public string Gtin { get; set; }
        public string ProductType { get; set; }
        public string MaterialType { get; set; }
        public string Color { get; set; }
        public string Shape { get; set; }
        public string Lotbatch { get; set; }
        public string Lotbatch2 { get; set; }
        public string ClientReference { get; set; }
        public string ClientReference2 { get; set; }
        public string BestBeforeDate { get; set; }
        public string CustomsDocument { get; set; }
        public string StorageStatus { get; set; }
        public string Stackheight { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string OriginalContainer { get; set; }
        public string Quantity { get; set; }
        public string WeightNet { get; set; }
        public string WeightGross { get; set; }
    }
}
