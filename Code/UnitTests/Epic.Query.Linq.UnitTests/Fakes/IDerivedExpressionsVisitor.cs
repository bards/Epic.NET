//  
//  IDerivedExpressionsVisitor.cs
//  
//  Author:
//       Giacomo Tesio <giacomo@tesio.it>
// 
//  Copyright (c) 2010-2013 Giacomo Tesio
// 
//  This file is part of Epic.NET.
// 
//  Epic.NET is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  Epic.NET is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
// 
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//  
using System;
using System.Linq.Expressions;
using Epic.Query.Linq.Expressions;

namespace Epic.Query.Linq.Fakes
{
    public interface IDerivedExpressionsVisitor : IVisitor<Expression, UnaryExpression>, 
        IVisitor<Expression, BinaryExpression>, 
        IVisitor<Expression, ConditionalExpression>,
        IVisitor<Expression, ConstantExpression>,
        IVisitor<Expression, InvocationExpression>,
        IVisitor<Expression, LambdaExpression>,
        IVisitor<Expression, MemberExpression>,
        IVisitor<Expression, MethodCallExpression>,
        IVisitor<Expression, NewExpression>,
        IVisitor<Expression, NewArrayExpression>,
        IVisitor<Expression, MemberInitExpression>,
        IVisitor<Expression, ListInitExpression>,
        IVisitor<Expression, ParameterExpression>,
        IVisitor<Expression, TypeBinaryExpression>
    {
    }
}

