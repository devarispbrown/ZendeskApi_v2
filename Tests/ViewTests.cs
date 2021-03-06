﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ZenDeskApi_v2;
using ZenDeskApi_v2.Models.Constants;
using ZenDeskApi_v2.Models.Shared;
using ZenDeskApi_v2.Models.Tickets;
using ZenDeskApi_v2.Models.Views;
using ZenDeskApi_v2.Models.Views.Executed;


namespace Tests
{
    [TestFixture]
    public class ViewTests
    {        
        ZendeskApi api = new ZendeskApi(Settings.Site, Settings.Email, Settings.Password);

        [Test]
        public void CanGetViews()
        {
            var views = api.Views.GetAllViews();
            Assert.True(views.Count > 0);            
        }

        [Test]
        public void CanGetActiveViews()
        {
            var views = api.Views.GetActiveViews();
            Assert.True(views.Count > 0);
        }

        [Test]
        public void CanGetCompactViews()
        {
            var views = api.Views.GetCompactViews();
            Assert.True(views.Count > 0);
        }

        [Test]
        public void CanGetViewById()
        {
            var views = api.Views.GetAllViews();
            var view = api.Views.GetView(views.Views.First().Id);
            Assert.True(view.View.Id > 0);
        }

        [Test]
        public void CanExecuteViews()
        {
            var views = api.Views.GetAllViews();
            var res = api.Views.ExecuteView(views.Views.First().Id);

            Assert.Greater(res.Rows.Count, 0);
            Assert.Greater(res.Columns.Count, 0);
        }

        [Test]
        public void CanPreviewViews()
        {            
            var preview = new PreviewViewRequest()
                              {
                                  View = new PreviewView()
                                             {
                                                 All =
                                                     new List<All>()
                                                         {new All() {Field = "status", Value = "open", Operator = "is"}},
                                                 Output =
                                                     new PreviewViewOutput() {Columns = new List<string>() {"subject"}}
                                             }
                              };

            var previewRes = api.Views.PreviewView(preview);
            Assert.Greater(previewRes.Rows.Count, 0);
            Assert.Greater(previewRes.Columns.Count, 0);
        }

        [Test]
        public void CanGetViewCounts()
        {
            var views = api.Views.GetAllViews();
            var res = api.Views.GetViewCounts(new List<long>() { views.Views[0].Id });
            Assert.Greater(res.ViewCounts.Count, 0);

            Assert.True(views.Count > 0);
        }

        [Test]
        public void CanGetViewCount()
        {
            var views = api.Views.GetAllViews();
            var id = views.Views[0].Id;
            var res = api.Views.GetViewCount(id);

            Assert.True(res.ViewCount.ViewId == id);            
        }
    }
}
