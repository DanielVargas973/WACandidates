﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WACandidates.Classes.Model
{
    public class CandidateModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public CandidateAddressModel address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public CandidatesCompanyModel company { get; set; }
    }
}