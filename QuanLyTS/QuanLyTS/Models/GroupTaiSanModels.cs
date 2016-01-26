using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTS.Models
{
   
    public class DropdownModel
    {
        public List<Parent> DropdownDataModel { get; set; }
        public List<Parent> ParentDataModel { get; set; }
        public List<Child> ClildDataModel { get; set; }
        public int SelectedValue { get; set; }
    }
    public class Parent
    {
        public string ParentId { get; set; }
        public string ParentName { get; set; }
    }
    public class Child
    {
        public string ParentId { get; set; }
        public string ChildId { get; set; }
        public string ChildName { get; set; }
    }



}