﻿using OrmTest.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrmTest.ExpressionTest
{
    public class Select
    {
        internal static void Init()
        {
            Expression<Func<Student, object>> exp = it => new Program() { x = it.Name };
            ExpressionContext expContext = new ExpressionContext(exp, ResolveExpressType.WhereSingle);
            expContext.ResolveType = ResolveExpressType.SelectSingle;
            var x= expContext.ToResultString();
        }
    }
}
