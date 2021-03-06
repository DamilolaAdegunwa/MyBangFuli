﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.API.MVCDotnet2.Filter;
using BangBangFuli.API.MVCDotnet2.Models;
using BangBangFuli.Common;
using BangBangFuli.H5.API.Application.Services.BasicDatas;
using BangBangFuli.H5.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BangBangFuli.API.MVCDotnet2.Controllers.Version1
{
    [UserLoginFilter]
    public class BatchController : BaseController
    {
        private IUserRoleJurisdictionService _userRoleJurisdictionService;
        private IModuleInfoService _moduleInfoService;
        private readonly IBatchInformationService _batchInformationService;

        public BatchController(IUserRoleJurisdictionService userRoleJurisdictionService, IModuleInfoService moduleInfoService,
            IBatchInformationService batchInformationService): base(userRoleJurisdictionService, moduleInfoService)
        {
            _userRoleJurisdictionService = userRoleJurisdictionService;
            _moduleInfoService = moduleInfoService;
            _batchInformationService = batchInformationService;
        }


        public IActionResult BatchList()
        {
            return View();
        }

        /// <summary>
        /// 头图页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BatchListData(int page, int limit)
        {
            List<BatchViewModel> batchList = new List<BatchViewModel>();
            var batchInfos = _batchInformationService.GetList(page, limit);
            if (batchInfos.Item1 != null && batchInfos.Item1.Count > 0)
            {
                foreach (var batch in batchInfos.Item1)
                {
                    batchList.Add(new BatchViewModel
                    {
                        Id = batch.Id,
                        BatchId = batch.Id,
                        Name = batch.Name,
                        CreateTime = batch.CreateTime
                    });
                }
            }
            return Json(new { code = 0, msg = "", count = batchInfos.Item2, data = batchList.ToArray() });
        }

        /// <summary>
        /// 新增界面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddNewBatch(int id)
        {
            BatchInformation batchInfo = new BatchInformation();
            if (id > 0)
            {
                batchInfo = _batchInformationService.GetBatchInfoById(id);
            }
            return View(batchInfo);
        }

        [HttpPost]
        public IActionResult SaveBatch()
        {
            int id = Request.Form["ID"].TryToInt(0);
            if (id > 0)
            {
                var info = _batchInformationService.GetBatchInfoById(id);
                info.Name = Request.Form["Name"].TryToString();
                _batchInformationService.UpdateBatchInfo(info);
                return Json(new { code = 1, msg = "OK", id = info.Id });
            }
            else
            {
                BatchInformation batchInfo = new BatchInformation();
                batchInfo.Name = Request.Form["Name"].TryToString();
                batchInfo.CreateTime = DateTime.Now;
                id = _batchInformationService.AddBatchInfo(batchInfo);
                if (id > 0)
                {
                    return Json(new { code = 1, msg = "OK", id = id });
                }
                else
                {
                    return Json(new { code = 0, msg = "保存失败" });
                }
            }
        }

        [HttpGet]
        public IActionResult DelBatch(int id)
        {
            try
            {
                _batchInformationService.RemoveBatchById(id);
                return Json(new { code = 1, msg = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 0, msg = "OK" });
            }
        }


    }
}