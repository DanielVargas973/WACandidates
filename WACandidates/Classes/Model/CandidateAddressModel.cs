using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WACandidates.Classes.Model
{
    public class CandidateAddressModel
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public CandidateGeoModel geo { get; set; }
    }
}