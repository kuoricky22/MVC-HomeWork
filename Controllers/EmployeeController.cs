﻿using MVC_02_公司練習.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_02_公司練習.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly List<EmployeeModel> listEmployee;
        public EmployeeController()
        {
            string jsonData = "[{\"Name\":\"錡O亨  經理\",\"EmpNo\":\"Z97055\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"客管資訊課\",\"UnitNo\":\"11L100\",\"Title\":\"客管資訊課主管\",\"Email\":\"skz97055@skl.com.tw\",\"Score\":93},{\"Name\":\"謝O姍\",\"EmpNo\":\"AY3208\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"客管資訊課\",\"UnitNo\":\"11L100\",\"Title\":\"系統分析專案襄理\",\"Email\":\"skay3208@skl.com.tw\",\"Score\":80},{\"Name\":\"劉O文\",\"EmpNo\":\"CR9077\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"客管資訊課\",\"UnitNo\":\"11L100\",\"Title\":\"系統分析專案襄理\",\"Email\":\"skcr9077@skl.com.tw\",\"Score\":69},{\"Name\":\"彭O元\",\"EmpNo\":\"AY2201\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"客管資訊課\",\"UnitNo\":\"11L100\",\"Title\":\"系統分析專案襄理\",\"Email\":\"skay2201@skl.com.tw\",\"Score\":80},{\"Name\":\"蔣O育\",\"EmpNo\":\"EG9155\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"客管資訊課\",\"UnitNo\":\"11L100\",\"Title\":\"系統分析師\",\"Email\":\"skeg9155@skl.com.tw\",\"Score\":76},{\"Name\":\"郭O怡\",\"EmpNo\":\"EH9076\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"客管資訊課\",\"UnitNo\":\"11L100\",\"Title\":\"應用系統工程師\",\"Email\":\"skeh9076@skl.com.tw\",\"Score\":85},{\"Name\":\"朱O廷\",\"EmpNo\":\"EK2686\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"客管資訊課\",\"UnitNo\":\"11L100\",\"Title\":\"系統設計師\",\"Email\":\"skek2686@skl.com.tw\",\"Score\":70},{\"Name\":\"許O濬\",\"EmpNo\":\"EK7888\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"客管資訊課\",\"UnitNo\":\"11L100\",\"Title\":\"應用系統工程師\",\"Email\":\"skek7888@skl.com.tw\",\"Score\":81},{\"Name\":\"李O哲\",\"EmpNo\":\"EQ0924\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"客管資訊課\",\"UnitNo\":\"11L100\",\"Title\":\"系統設計師\",\"Email\":\"skeq0924@skl.com.tw\",\"Score\":61},{\"Name\":\"林O甄\",\"EmpNo\":\"EU2240\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"客管資訊課\",\"UnitNo\":\"11L100\",\"Title\":\"應用系統工程師\",\"Email\":\"skeu2240@skl.com.tw\",\"Score\":66},{\"Name\":\"陳O剛\",\"EmpNo\":\"EU2237\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"客管資訊課\",\"UnitNo\":\"11L100\",\"Title\":\"應用系統工程師\",\"Email\":\"skeu2237@skl.com.tw\",\"Score\":94},{\"Name\":\"葉O宏\",\"EmpNo\":\"AZ8321\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"架構專案襄理\",\"Email\":\"skaz8321@skl.com.tw\",\"Score\":65},{\"Name\":\"鍾O憶\",\"EmpNo\":\"Y97880\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"系統分析師\",\"Email\":\"sky97880@skl.com.tw\",\"Score\":82},{\"Name\":\"李O璇\",\"EmpNo\":\"EM2627\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"應用系統工程師\",\"Email\":\"skem2627@skl.com.tw\",\"Score\":85},{\"Name\":\"謝O美  經理\",\"EmpNo\":\"EQ3521\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"業務行銷資訊課主管\",\"Email\":\"skeq3521@skl.com.tw\",\"Score\":66},{\"Name\":\"康O傑\",\"EmpNo\":\"ES1328\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"應用系統工程師\",\"Email\":\"skes1328@skl.com.tw\",\"Score\":77},{\"Name\":\"王O惠\",\"EmpNo\":\"ES3485\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"應用系統工程師\",\"Email\":\"skes3485@skl.com.tw\",\"Score\":70},{\"Name\":\"黃O彥\",\"EmpNo\":\"ES5159\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"應用系統工程師\",\"Email\":\"skes5159@skl.com.tw\",\"Score\":92},{\"Name\":\"林O如\",\"EmpNo\":\"ES5618\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"系統分析專案襄理\",\"Email\":\"skes5618@skl.com.tw\",\"Score\":83},{\"Name\":\"陳O怡\",\"EmpNo\":\"EU6181\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"系統設計師\",\"Email\":\"skeu6181@skl.com.tw\",\"Score\":62},{\"Name\":\"王O丞\",\"EmpNo\":\"ER1336\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"應用系統工程師\",\"Email\":\"sker1336@skl.com.tw\",\"Score\":86},{\"Name\":\"王O嘉\",\"EmpNo\":\"EY4900\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"系統設計師\",\"Email\":\"skey4900@skl.com.tw\",\"Score\":67},{\"Name\":\"林O\",\"EmpNo\":\"EU2262\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"應用系統工程師\",\"Email\":\"skeu2262@skl.com.tw\",\"Score\":91},{\"Name\":\"李O鋒\",\"EmpNo\":\"EZ4647\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"系統分析專案襄理\",\"Email\":\"skez4647@skl.com.tw\",\"Score\":79},{\"Name\":\"岳O綺\",\"EmpNo\":\"EZ0331\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"業務行銷資訊課\",\"UnitNo\":\"11L200\",\"Title\":\"應用系統工程師\",\"Email\":\"skez0331@skl.com.tw\",\"Score\":68},{\"Name\":\"江O修\",\"EmpNo\":\"CQ0607\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"系統設計師\",\"Email\":\"skcq0607@skl.com.tw\",\"Score\":96},{\"Name\":\"林O融\",\"EmpNo\":\"CR7064\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"資深視覺設計師\",\"Email\":\"skcr7064@skl.com.tw\",\"Score\":66},{\"Name\":\"江O翰\",\"EmpNo\":\"CX1215\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"系統設計師\",\"Email\":\"skcx1215@skl.com.tw\",\"Score\":98},{\"Name\":\"許O中\",\"EmpNo\":\"CR5845\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"資深視覺設計師\",\"Email\":\"skcr5845@skl.com.tw\",\"Score\":88},{\"Name\":\"張O榕\",\"EmpNo\":\"AT4981\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"系統分析專案襄理\",\"Email\":\"skat4981@skl.com.tw\",\"Score\":79},{\"Name\":\"陳O志  經理\",\"EmpNo\":\"CX7973\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"資訊應用發展課主管\",\"Email\":\"skcx7973@skl.com.tw\",\"Score\":64},{\"Name\":\"蕭O修\",\"EmpNo\":\"EB2356\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"系統設計師\",\"Email\":\"skeb2356@skl.com.tw\",\"Score\":79},{\"Name\":\"鄧O翔\",\"EmpNo\":\"EK1095\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"架構專案襄理\",\"Email\":\"skek1095@skl.com.tw\",\"Score\":63},{\"Name\":\"陳O隆\",\"EmpNo\":\"EK6673\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"系統設計師\",\"Email\":\"skek6673@skl.com.tw\",\"Score\":65},{\"Name\":\"吳O昀\",\"EmpNo\":\"EU2221\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"應用系統工程師\",\"Email\":\"skeu2221@skl.com.tw\",\"Score\":79},{\"Name\":\"張O睿\",\"EmpNo\":\"EU4752\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"使用者體驗專案襄理\",\"Email\":\"skeu4752@skl.com.tw\",\"Score\":72},{\"Name\":\"蘇O文\",\"EmpNo\":\"EU4789\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"架構專案襄理\",\"Email\":\"skeu4789@skl.com.tw\",\"Score\":74},{\"Name\":\"宋O霖\",\"EmpNo\":\"FA4395\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"應用系統工程師\",\"Email\":\"skfa4395@skl.com.tw\",\"Score\":87},{\"Name\":\"劉O瑋\",\"EmpNo\":\"FA8567\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"資訊應用發展課\",\"UnitNo\":\"11L300\",\"Title\":\"應用系統工程師\",\"Email\":\"skfa8567@skl.com.tw\",\"Score\":80},{\"Name\":\"徐O敏  經理\",\"EmpNo\":\"AH3153\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"電子商務資訊課\",\"UnitNo\":\"11L300\",\"Title\":\"電子商務資訊課主管\",\"Email\":\"skah3153@skl.com.tw\",\"Score\":74},{\"Name\":\"蘇O\",\"EmpNo\":\"CM0303\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"電子商務資訊課\",\"UnitNo\":\"11L300\",\"Title\":\"系統設計師\",\"Email\":\"skcm0303@skl.com.tw\",\"Score\":95},{\"Name\":\"張O貞\",\"EmpNo\":\"AF8714\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"電子商務資訊課\",\"UnitNo\":\"11L300\",\"Title\":\"系統分析專案襄理\",\"Email\":\"skaf8714@skl.com.tw\",\"Score\":62},{\"Name\":\"張O昇\",\"EmpNo\":\"CT3052\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"電子商務資訊課\",\"UnitNo\":\"11L300\",\"Title\":\"架構專案襄理\",\"Email\":\"skct3052@skl.com.tw\",\"Score\":80},{\"Name\":\"陳O容\",\"EmpNo\":\"EM2499\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"電子商務資訊課\",\"UnitNo\":\"11L300\",\"Title\":\"應用系統工程師\",\"Email\":\"skem2499@skl.com.tw\",\"Score\":94},{\"Name\":\"黃O文\",\"EmpNo\":\"EM2627\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"電子商務資訊課\",\"UnitNo\":\"11L300\",\"Title\":\"應用系統工程師\",\"Email\":\"skem2627@skl.com.tw\",\"Score\":60},{\"Name\":\"蔡O芸\",\"EmpNo\":\"ER1344\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"電子商務資訊課\",\"UnitNo\":\"11L300\",\"Title\":\"應用系統工程師\",\"Email\":\"sker1344@skl.com.tw\",\"Score\":91},{\"Name\":\"林O安\",\"EmpNo\":\"ER1245\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"電子商務資訊課\",\"UnitNo\":\"11L300\",\"Title\":\"應用系統工程師\",\"Email\":\"sker1245@skl.com.tw\",\"Score\":94},{\"Name\":\"詹O翔\",\"EmpNo\":\"ER1377\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"電子商務資訊課\",\"UnitNo\":\"11L300\",\"Title\":\"應用系統工程師\",\"Email\":\"sker1377@skl.com.tw\",\"Score\":92},{\"Name\":\"廖O萍\",\"EmpNo\":\"EX2147\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"電子商務資訊課\",\"UnitNo\":\"11L300\",\"Title\":\"系統設計師\",\"Email\":\"skex2147@skl.com.tw\",\"Score\":91},{\"Name\":\"宋O銘\",\"EmpNo\":\"FA1879\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"電子商務資訊課\",\"UnitNo\":\"11L300\",\"Title\":\"系統分析師\",\"Email\":\"skfa1879@skl.com.tw\",\"Score\":70},{\"Name\":\"高O泓\",\"EmpNo\":\"EZ0594\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"電子商務資訊課\",\"UnitNo\":\"11L300\",\"Title\":\"應用系統工程師\",\"Email\":\"skez0594@skl.com.tw\",\"Score\":85},{\"Name\":\"傅O凱  部資深協理\",\"EmpNo\":\"BY1450\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數位資訊部\",\"UnitNo\":\"11L000\",\"Title\":\"數位資訊部部資深協理\",\"Email\":\"skby1450@skl.com.tw\",\"Score\":77},{\"Name\":\"朱O傑  經理\",\"EmpNo\":\"Z58515\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"數據分析課主管\",\"Email\":\"skz58515@skl.com.tw\",\"Score\":89},{\"Name\":\"黃O菁\",\"EmpNo\":\"CN3100\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"數據分析師\",\"Email\":\"skcn3100@skl.com.tw\",\"Score\":82},{\"Name\":\"陳O\",\"EmpNo\":\"CS8382\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"數據分析師\",\"Email\":\"skcs8382@skl.com.tw\",\"Score\":75},{\"Name\":\"張O菀\",\"EmpNo\":\"AF0853\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"數據分析師\",\"Email\":\"skaf0853@skl.com.tw\",\"Score\":61},{\"Name\":\"鄭O帆  專案經理\",\"EmpNo\":\"BC8835\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"專案經理\",\"Email\":\"skbc8835@skl.com.tw\",\"Score\":66},{\"Name\":\"曾O鈴\",\"EmpNo\":\"CK1371\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"數據分析師\",\"Email\":\"skck1371@skl.com.tw\",\"Score\":61},{\"Name\":\"方O賢\",\"EmpNo\":\"AS9223\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"數據分析師\",\"Email\":\"skas9223@skl.com.tw\",\"Score\":78},{\"Name\":\"楊O寧\",\"EmpNo\":\"EB6208\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"數據分析師\",\"Email\":\"skeb6208@skl.com.tw\",\"Score\":85},{\"Name\":\"葉O縈\",\"EmpNo\":\"EM3218\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"數據分析師\",\"Email\":\"skem3218@skl.com.tw\",\"Score\":98},{\"Name\":\"張O潔\",\"EmpNo\":\"EN3684\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"資料工程師\",\"Email\":\"sken3684@skl.com.tw\",\"Score\":99},{\"Name\":\"蔡O緯\",\"EmpNo\":\"EN8110\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"數據分析師\",\"Email\":\"sken8110@skl.com.tw\",\"Score\":87},{\"Name\":\"羅O聖\",\"EmpNo\":\"ES1645\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"資料工程師\",\"Email\":\"skes1645@skl.com.tw\",\"Score\":64},{\"Name\":\"潘O儀\",\"EmpNo\":\"ET3547\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"資料工程師\",\"Email\":\"sket3547@skl.com.tw\",\"Score\":66},{\"Name\":\"王O婷\",\"EmpNo\":\"ET3501\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"資料工程師\",\"Email\":\"sket3501@skl.com.tw\",\"Score\":70},{\"Name\":\"張O誠\",\"EmpNo\":\"ET4091\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"資料工程師\",\"Email\":\"sket4091@skl.com.tw\",\"Score\":91},{\"Name\":\"張O瑋\",\"EmpNo\":\"EU2180\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"資料工程師\",\"Email\":\"skeu2180@skl.com.tw\",\"Score\":84},{\"Name\":\"雷O鼎\",\"EmpNo\":\"EU4587\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"數據分析師\",\"Email\":\"skeu4587@skl.com.tw\",\"Score\":83},{\"Name\":\"王O靖\",\"EmpNo\":\"EU4348\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"資料工程師\",\"Email\":\"skeu4348@skl.com.tw\",\"Score\":91},{\"Name\":\"高O閔\",\"EmpNo\":\"EX4347\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"數據分析師\",\"Email\":\"skex4347@skl.com.tw\",\"Score\":77},{\"Name\":\"林O皓  專案經理\",\"EmpNo\":\"EY8509\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"專案經理\",\"Email\":\"skey8509@skl.com.tw\",\"Score\":89},{\"Name\":\"方O翰\",\"EmpNo\":\"EZ3491\",\"Dept\":\"數位資訊部\",\"DeptNo\":\"11L000\",\"Unit\":\"數據分析課\",\"UnitNo\":\"11L400\",\"Title\":\"數據分析專案襄理\",\"Email\":\"skez3491@skl.com.tw\",\"Score\":98}]";

            //  Newtonsoft.Json.JsonConvert.DeserializeObject<類別>(字串)：將JSON字串反序列化成物件
            // 反序列化：JSON轉物件
            // 序列化： 物件轉JSON

            // 所以利用此方法將我們要的JSON資料轉成特定的物件
            listEmployee = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EmployeeModel>>(jsonData);
        }
        // GET: Employee
        public ActionResult Index()
        {

            return View(listEmployee);
        }

        // 【 Report Action 】
        public ActionResult Report()
        {
            // *** 職稱資料處理 START***
            var titles = listEmployee.Select(x => x.Title).Distinct().ToList();

            ViewBag.titles = titles;
            // *** 職稱資料處理 END***

            // *** 部門資料處理 START***
            var DeptTotal = 0;
            var DeptSorceSum = 0;
            var DeptSorceAvg = 0;
            foreach (var item in listEmployee)
            {
                if (item.Dept == "數位資訊部")
                {
                    DeptTotal++;
                    DeptSorceSum += int.Parse(item.Score);
                }
            }
            DeptSorceAvg = DeptSorceSum / DeptTotal;

            ViewBag.DeptTotal = DeptTotal;
            ViewBag.DeptSorceAvg = DeptSorceAvg;
            // *** 部門資料處理 END***

            // *** 單位資料處理 START***
            var units = listEmployee.Select(x => x.Unit).Distinct().ToList();

            ViewBag.units = units;
            // *** 單位資料處理 END***


            return View(listEmployee);
        }

        // 【 List  Action 】
        public ActionResult List()
        {

            return View(listEmployee);
        }

        // 【 Detail Action 】
        public ActionResult Detail(string id)
        {

            ViewBag.id = id;

            return View(listEmployee);

        }
    }
}