﻿namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;
    using System.Reflection;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type type = Type.GetType("_03BarracksFactory.Models.Units." + unitType);
            return (IUnit)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public
                | BindingFlags.NonPublic | BindingFlags.Static, null, new object[0] { }, null);

            //string qualifiedName = type.AssemblyQualifiedName;
            //return (IUnit)Activator.CreateInstance(Type.GetType(qualifiedName));

            throw new NotImplementedException();
        }
    }
}
