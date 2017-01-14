﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace SqlSugar
{
    public class ExpressionContext : ExpResolveAccessory
    {
        #region constructor
        private ExpressionContext() {

        }
        public ExpressionContext(Expression expression, ResolveExpressType resolveType)
        {
            this.ResolveType = resolveType;
            this.Expression = expression;
        }
        #endregion

        #region properties
        public IDbMethods DbMehtods { get; set; }
        public int Index { get; set; }
        public ResolveExpressType ResolveType { get; set; }
        public Expression Expression { get; set; }
        public StringBuilder ResultString { get; set; }
        public object ResultObj { get; set; }
        public bool IsWhereSingle
        {
            get
            {
                return this.ResolveType == ResolveExpressType.WhereSingle;
            }
        }
        public List<SugarParameter> Parameters
        {
            get
            {
                return base._Parameters;
            }
            set
            {
                base._Parameters = value;
            }
        }
        public virtual string SqlParameterKeyWord
        {
            get
            {
                return "@";
            }
        }
        #endregion

        #region functions
        public virtual string GetaMppingColumnsName(string name)
        {
            return name;
        }

        public virtual string ToResultString()
        {
            BaseResolve resolve = new BaseResolve(new ExpressionParameter() { Expression = this.Expression, Context = this });
            resolve.Start();
            if (this.ResultString == null) return string.Empty;
            return this.ResultString.ToString();
        }

        public virtual object GetResultObj()
        {
            BaseResolve resolve = new BaseResolve(new ExpressionParameter() { Expression = this.Expression, Context = this });
            resolve.Start();
            return this.ResultObj;
        }
        #endregion
    }
}
