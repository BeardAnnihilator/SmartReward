using PagedList;
using SmartReward.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartReward.ViewModel
{
    public class BindingViewModel
    {
        public IPagedList<User> result;
    }
}