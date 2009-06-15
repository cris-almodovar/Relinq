// This file is part of the re-motion Core Framework (www.re-motion.org)
// Copyright (C) 2005-2009 rubicon informationstechnologie gmbh, www.rubicon.eu
// 
// The re-motion Core Framework is free software; you can redistribute it 
// and/or modify it under the terms of the GNU Lesser General Public License 
// version 3.0 as published by the Free Software Foundation.
// 
// re-motion is distributed in the hope that it will be useful, 
// but WITHOUT ANY WARRANTY; without even the implied warranty of 
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with re-motion; if not, see http://www.gnu.org/licenses.
// 
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Remotion.Data.Linq.Clauses;
using Remotion.Data.Linq.Clauses.ResultModifications;
using Remotion.Utilities;

namespace Remotion.Data.Linq.Parsing.Structure.IntermediateModel
{
  /// <summary>
  /// Represents a <see cref="MethodCallExpression"/> for the different overloads of <see cref="O:Queryable.Sum"/>.
  /// It is generated by <see cref="ExpressionTreeParser"/> when an <see cref="Expression"/> tree is parsed.
  /// When this node is used, it marks the beginning (i.e. the last node) of an <see cref="IExpressionNode"/> chain that represents a query.
  /// </summary>
  public class SumExpressionNode : ResultModificationExpressionNodeBase
  {
    public static readonly MethodInfo[] SupportedMethods = new[]
                                                           {
                                                               GetSupportedMethod (() => Queryable.Sum ((IQueryable<decimal>) null)),
                                                               GetSupportedMethod (() => Queryable.Sum ((IQueryable<decimal?>) null)),
                                                               GetSupportedMethod (() => Queryable.Sum ((IQueryable<double>) null)),
                                                               GetSupportedMethod (() => Queryable.Sum ((IQueryable<double?>) null)),
                                                               GetSupportedMethod (() => Queryable.Sum ((IQueryable<int>) null)),
                                                               GetSupportedMethod (() => Queryable.Sum ((IQueryable<int?>) null)),
                                                               GetSupportedMethod (() => Queryable.Sum ((IQueryable<long>) null)),
                                                               GetSupportedMethod (() => Queryable.Sum ((IQueryable<long?>) null)),
                                                               GetSupportedMethod (() => Queryable.Sum ((IQueryable<float>) null)),
                                                               GetSupportedMethod (() => Queryable.Sum ((IQueryable<float?>) null)),
                                                               GetSupportedMethod (() => Queryable.Sum<object> (null, o => (decimal) 0)),
                                                               GetSupportedMethod (() => Queryable.Sum<object> (null, o => (decimal?) 0)),
                                                               GetSupportedMethod (() => Queryable.Sum<object> (null, o => (double) 0)),
                                                               GetSupportedMethod (() => Queryable.Sum<object> (null, o => (double?) 0)),
                                                               GetSupportedMethod (() => Queryable.Sum<object> (null, o => (int) 0)),
                                                               GetSupportedMethod (() => Queryable.Sum<object> (null, o => (int?) 0)),
                                                               GetSupportedMethod (() => Queryable.Sum<object> (null, o => (long) 0)),
                                                               GetSupportedMethod (() => Queryable.Sum<object> (null, o => (long?) 0)),
                                                               GetSupportedMethod (() => Queryable.Sum<object> (null, o => (float) 0)),
                                                               GetSupportedMethod (() => Queryable.Sum<object> (null, o => (float?) 0)),
                                                           };

    public SumExpressionNode (MethodCallExpressionParseInfo parseInfo, LambdaExpression optionalSelector)
        : base (parseInfo, null, optionalSelector)
    {
    }

    public override Expression Resolve (ParameterExpression inputParameter, Expression expressionToBeResolved, QuerySourceClauseMapping querySourceClauseMapping)
    {
      // no data streams out from this node, so we cannot resolve any expressions
      throw CreateResolveNotSupportedException();
    }

    public override ParameterExpression CreateParameterForOutput ()
    {
      // no data streams out from this node, so we cannot create a parameter accepting that data
      throw CreateOutputParameterNotSupportedException();
    }

    protected override ResultModificationBase CreateResultModification (SelectClause selectClause)
    {
      return new SumResultModification (selectClause);
    }
  }
}