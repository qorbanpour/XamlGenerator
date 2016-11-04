using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Collections;
using System.Data.Metadata.Edm;
using System.IO;

namespace XamlGenerator.DAL
{
    class DAL
    {

        //static GeneratorEntities generatorContext = new GeneratorEntities();
        //static HesabR1Entities generatorContext = new HesabR1Entities();
        static CommonEntities generatorContext = new CommonEntities();

        public static ObjectResult GetAllEntitySet()
        {
            var EntitySetQuery = from d in generatorContext.EntitySet.Include("EntityMetaData")
                                 select d;
            return ((ObjectQuery)EntitySetQuery).Execute(MergeOption.AppendOnly); 
      

            
            
        }
         public  static IQueryable<EntitySet> GetChildEntitySet(EntitySet Master) 
         {
            
            var query = from meta in generatorContext.EntityMetaData.Where(m => m.EntitySet_id == Master.id && m.IsCollectionEntity == true)
                        select meta;
            var query2 = from entity in generatorContext.EntitySet.Include("EntityMetaData")
                         join meta in query on entity.EntityTypeName equals meta.ForeignEntityType
                         select entity;
            return query2;

         }

         public static EntitySet GetEntitySetByEntitySetTypeName(string ListEntityName)
         {
             var Query = from d in generatorContext.EntitySet.Include("EntityMetaData")
                         where d.EntityTypeName == ListEntityName
                         select d;
             
             var Result= ((ObjectQuery)Query).Execute(MergeOption.AppendOnly);
             EntitySet returnValue = null;
             foreach (var item in Result)
             {
                 returnValue = item as EntitySet;
                 break;                     
             }

             return returnValue;
         }public static string GetEntityTypeNameById(int id)
         {
             var Query = from d in generatorContext.EntitySet.Include("EntityMetaData")
                         where d.id == id
                         select d;
             var Result = ((ObjectQuery)Query).Execute(MergeOption.AppendOnly);
             foreach (var item in Result)
             {
                 return (item as EntitySet).EntityTypeName;
             }
             throw new Exception("Invalid Id");
         }



        #region MasterDetailQueryGenerator




         //private static IEnumerable<EntitySet> GetEntitiesSet()
         //{
         //    var container = generatorContext.MetadataWorkspace.GetEntityContainer(generatorContext.DefaultContainerName, DataSpace.CSpace);
         //    var query = from meta in container.BaseEntitySets
         //                where meta.BuiltInTypeKind == BuiltInTypeKind.EntitySet
         //                select new EntitySet()
         //                {
         //                    EntitySetName = meta.Name,
         //                    EntityTypeName = meta.ElementType.Name
         //                };
         //    return query;

         //}

         //private static string GetEntitySetName(string entityTypeName)
         //{
         //    if (entityTypeName == null)
         //        return null;
         //    var container = generatorContext.MetadataWorkspace.GetEntityContainer(generatorContext.DefaultContainerName, DataSpace.CSpace);
         //    string entitySetName = (from meta in container.BaseEntitySets
         //                            where meta.ElementType.Name == entityTypeName
         //                            select meta.Name).FirstOrDefault();
         //    return entitySetName;
         //}

         //private static string GetEntityTypeName(string entitySetName)
         //{
         //    var container = generatorContext.MetadataWorkspace.GetEntityContainer(generatorContext.DefaultContainerName, DataSpace.CSpace);
         //    string entityTypeName = (from meta in container.BaseEntitySets
         //                             where meta.Name == entitySetName
         //                             select meta.ElementType.Name).FirstOrDefault();
         //    return entityTypeName;
         //}
         //private static IEnumerable<String> GetEntityTypeNames()
         //{

         //    var query = from meta in generatorContext.MetadataWorkspace.GetItems(DataSpace.CSpace)
         //                where meta.BuiltInTypeKind == BuiltInTypeKind.EntityType
         //                select (meta as EntityType).Name;
         //    return query;
         //}



         //private static IEnumerable<EntityMetaData> GetMetaDataNotNullable(String EntityName)
         //{
         //    var query = from metaData in GetMetaData(EntityName)
         //                where metaData.Nullable == false
         //                select metaData;
         //    return query;

         //}



         //private static string KeyName(String EntityName)
         //{
         //    var query = from meta in generatorContext.MetadataWorkspace.GetItems(DataSpace.CSpace)
         //             .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
         //                from p in (meta as EntityType).Properties.Where(p => p.DeclaringType.Name.Equals(EntityName, StringComparison.OrdinalIgnoreCase))
         //                select new
         //                {
         //                    KeyName = (meta as EntityType).KeyMembers.ElementAt(0)


         //                };

         //    if (query.Count() != 0)
         //        return query.ElementAt(0).KeyName.ToString();
         //    return null;

         //}

         //private static string ForeignKeyName(String ParentEntityName, String ChildEntityName)
         //{
         //    MetadataWorkspace mw = generatorContext.MetadataWorkspace;
         //    var items = mw.GetItems<EntityType>(DataSpace.CSpace).Where(i => i.Name.Equals(ChildEntityName, StringComparison.OrdinalIgnoreCase));
         //    foreach (var item in items)
         //        foreach (var navigationProprty in item.NavigationProperties)
         //            if (navigationProprty.GetDependentProperties().Count() != 0 && navigationProprty.Name == ParentEntityName)
         //            {
         //                return navigationProprty.GetDependentProperties().ElementAt(0).Name;
         //            }

         //    return null;

         //}
         //private static IEnumerable<EntityMetaData> GetMetaData(String EntityName)
         //{

         //    var query = from meta in generatorContext.MetadataWorkspace.GetItems(DataSpace.CSpace)
         //          .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
         //                from p in (meta as EntityType).Properties.Where(p => p.DeclaringType.Name.Equals(EntityName, StringComparison.OrdinalIgnoreCase))
         //                select new EntityMetaData()
         //                {


         //                    IsKey = (meta as EntityType).KeyMembers.Contains(p.Name),
         //                    IsForeignKey = IsForeignKey(meta as EntityType, p.Name),
         //                    ForeignEntityType = GetForeignEntityType(meta as EntityType, p.Name),
         //                    ForeingEntitySet = GetEntitySetName(GetForeignEntityType(meta as EntityType, p.Name)),
         //                    // EntityTypeName = p.DeclaringType.Name,
         //                    PropertyName = p.Name,
         //                    Nullable = p.Nullable,
         //                    TypeUsageName = p.TypeUsage.EdmType.Name,
         //                    DefaultValue = p.DefaultValue as string,
         //                    Documentation = p.Documentation != null ? p.Documentation.LongDescription : null


         //                };

         //    MetadataWorkspace mw = generatorContext.MetadataWorkspace;
         //    var items = mw.GetItems<EntityType>(DataSpace.CSpace).Where(i => i.Name.Equals(EntityName, StringComparison.OrdinalIgnoreCase));
         //    IList<EntityMetaData> collectionProperties = new List<EntityMetaData>();
         //    foreach (var item in items)
         //        foreach (var navigationProprty in item.NavigationProperties)
         //            if (navigationProprty.GetDependentProperties().Count() == 0)
         //            {
         //                EntityMetaData m = new EntityMetaData();
         //                m.PropertyName = navigationProprty.Name;
         //                m.ForeignEntityType = GetEntityTypeName(navigationProprty.Name);
         //                m.ForeingEntitySet = navigationProprty.Name;
         //                m.IsKey = false;
         //                m.Nullable = true;
         //                m.TypeUsageName = navigationProprty.TypeUsage.EdmType.Name;
         //                m.Documentation = navigationProprty.Documentation != null ? navigationProprty.Documentation.LongDescription : null;
         //                m.IsCollectionEntity = true;
         //                collectionProperties.Add(m);


         //            }


         //    return query.Concat<EntityMetaData>(collectionProperties);


         //}



         //private static bool IsForeignKey(EntityType EntityType, String PropertyName)
         //{
         //    foreach (var n in EntityType.NavigationProperties)
         //        foreach (var dependent in n.GetDependentProperties())
         //            if (PropertyName.Equals(dependent.Name))
         //                return true;

         //    return false;
         //}

         //private static string GetForeignEntityType(EntityType EntityType, String PropertyName)
         //{
         //    foreach (var n in EntityType.NavigationProperties)
         //        foreach (var dependent in n.GetDependentProperties())
         //            if (PropertyName.Equals(dependent.Name))
         //                return n.Name;

         //    return null;
         //}




         //public static void GenerateParentChildLoadQueries(string SavePath)
         //{
         //    StringBuilder sb = new StringBuilder();
         //    IEnumerable<EntitySet> set = GetEntitiesSet();
         //    foreach (var item in set)
         //    {
         //        IEnumerable<EntityMetaData> metaData = GetMetaData(item.EntityTypeName);
         //        foreach (var propertyItem in metaData)
         //        {
         //            sb.AppendLine("         ");
         //            if (propertyItem.IsCollectionEntity==true)
         //            {
         //                sb.AppendLine("public IQueryable<" + propertyItem.ForeignEntityType + ">    " + "Get" + propertyItem.PropertyName + "By" + item.EntityTypeName + "Query" + "(int " + KeyName(item.EntityTypeName) + "  ) { ");
         //                sb.AppendLine("   return this.generatorContext." + propertyItem.PropertyName + ".Where<" + propertyItem
         //                    .ForeignEntityType + ">(" + propertyItem.PropertyName.Substring(0, 1).ToLower() + "  =>  " +
         //                     propertyItem.PropertyName.Substring(0, 1).ToLower() + "." + ForeignKeyName(item.EntityTypeName, propertyItem.ForeignEntityType) + " == " + KeyName(item.EntityTypeName) + " ); ");
         //                sb.AppendLine(" } "

         //                    );
         //            }

         //        }

         //    }

         //    StreamWriter outfile =
         //    new StreamWriter(SavePath+"generated.txt");
         //    outfile.Write(sb.ToString());
         //    outfile.Flush();
         //    outfile.Close();

         //}
     


















        #endregion






        #region test


         public static IEnumerable<EntitySet> GetEntitiesSet()
         {
             var container = generatorContext.MetadataWorkspace.GetEntityContainer(generatorContext.DefaultContainerName, DataSpace.CSpace);
             var query = from meta in container.BaseEntitySets
                         where meta.BuiltInTypeKind == BuiltInTypeKind.EntitySet
                         select new EntitySet()
                         {
                             EntitySetName = meta.Name,
                             EntityTypeName = meta.ElementType.Name
                         };
             return query;

         }

         public static string GetEntitySetName(string entityTypeName)
         {
             if (entityTypeName == null)
                 return null;
             var container = generatorContext.MetadataWorkspace.GetEntityContainer(generatorContext.DefaultContainerName, DataSpace.CSpace);
             string entitySetName = (from meta in container.BaseEntitySets
                                     where meta.ElementType.Name == entityTypeName
                                     select meta.Name).FirstOrDefault();
             return entitySetName;
         }

         public static string GetEntityTypeName(string entitySetName)
         {
             var container = generatorContext.MetadataWorkspace.GetEntityContainer(generatorContext.DefaultContainerName, DataSpace.CSpace);
             string entityTypeName = (from meta in container.BaseEntitySets
                                      where meta.Name == entitySetName
                                      select meta.ElementType.Name).FirstOrDefault();
             return entityTypeName;
         }
         public static IEnumerable<String> GetEntityTypeNames()
         {

             var query = from meta in generatorContext.MetadataWorkspace.GetItems(DataSpace.CSpace)
                         where meta.BuiltInTypeKind == BuiltInTypeKind.EntityType
                         select (meta as EntityType).Name;
             return query;
         }



         public static IEnumerable<EntityMetaData> GetMetaDataNotNullable(String EntityName)
         {
             var query = from metaData in GetMetaData(EntityName)
                         where metaData.Nullable == false
                         select metaData;
             return query;

         }



         public static String KeyName(String EntityName)
         {
             var query = from meta in generatorContext.MetadataWorkspace.GetItems(DataSpace.CSpace)
                      .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                         from p in (meta as EntityType).Properties.Where(p => p.DeclaringType.Name.Equals(EntityName, StringComparison.OrdinalIgnoreCase))
                         select new
                         {
                             KeyName = (meta as EntityType).KeyMembers.ElementAt(0)


                         };

             if (query.Count() != 0)
                 return query.ElementAt(0).KeyName.ToString();
             return null;

         }

         public static String ForeignKeyName(String ParentEntityName, String ChildEntityName)
         {
             MetadataWorkspace mw = generatorContext.MetadataWorkspace;
             var items = mw.GetItems<EntityType>(DataSpace.CSpace).Where(i => i.Name.Equals(ChildEntityName, StringComparison.OrdinalIgnoreCase));
             foreach (var item in items)
                 foreach (var navigationProprty in item.NavigationProperties)
                     if (navigationProprty.GetDependentProperties().Count() != 0 && navigationProprty.Name == ParentEntityName)
                     {
                         return navigationProprty.GetDependentProperties().ElementAt(0).Name;
                     }

             return null;

         }
         public static IEnumerable<EntityMetaData> GetMetaData(String EntityName)
         {

             var query = from meta in generatorContext.MetadataWorkspace.GetItems(DataSpace.CSpace)
                   .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                         from p in (meta as EntityType).Properties.Where(p => p.DeclaringType.Name.Equals(EntityName, StringComparison.OrdinalIgnoreCase))
                         select new EntityMetaData()
                         {


                             IsKey = (meta as EntityType).KeyMembers.Contains(p.Name),
                             IsForeignKey = IsForeignKey(meta as EntityType, p.Name),
                             ForeignEntityType = GetForeignEntityType(meta as EntityType, p.Name),
                             ForeingEntitySet = GetEntitySetName(GetForeignEntityType(meta as EntityType, p.Name)),
                             // EntityTypeName = p.DeclaringType.Name,
                             PropertyName = p.Name,
                             Nullable = p.Nullable,
                             TypeUsageName = p.TypeUsage.EdmType.Name,
                             DefaultValue = p.DefaultValue != null ? p.DefaultValue.ToString() : null,
                             Documentation = p.Documentation != null ? p.Documentation.LongDescription : null


                         };

             MetadataWorkspace mw = generatorContext.MetadataWorkspace;
             var items = mw.GetItems<EntityType>(DataSpace.CSpace).Where(i => i.Name.Equals(EntityName, StringComparison.OrdinalIgnoreCase));
             IList<EntityMetaData> collectionProperties = new List<EntityMetaData>();
             foreach (var item in items)
                 foreach (var navigationProprty in item.NavigationProperties)
                     if (navigationProprty.GetDependentProperties().Count() == 0)
                     {
                         EntityMetaData m = new EntityMetaData();
                         m.PropertyName = navigationProprty.Name;
                         m.ForeignEntityType = GetEntityTypeName(navigationProprty.Name);
                         m.ForeingEntitySet = navigationProprty.Name;
                         m.IsKey = false;
                         m.Nullable = true;
                         m.TypeUsageName = navigationProprty.TypeUsage.EdmType.Name;
                         m.Documentation = navigationProprty.Documentation != null ? navigationProprty.Documentation.LongDescription : null;
                         m.IsCollectionEntity = true;
                         collectionProperties.Add(m);


                     }


             return query.Concat<EntityMetaData>(collectionProperties);


         }



         public static Boolean IsForeignKey(EntityType EntityType, String PropertyName)
         {
             foreach (var n in EntityType.NavigationProperties)
                 foreach (var dependent in n.GetDependentProperties())
                     if (PropertyName.Equals(dependent.Name))
                         return true;

             return false;
         }

         public static String GetForeignEntityType(EntityType EntityType, String PropertyName)
         {
             foreach (var n in EntityType.NavigationProperties)
                 foreach (var dependent in n.GetDependentProperties())
                     if (PropertyName.Equals(dependent.Name))
                         return n.Name;

             return null;
         }





         // TODO:
         // Consider constraining the results of your query method.  If you need additional input you can
         // add parameters to this method or create additional query methods with different names.
         // To support paging you will need to add ordering to the \"Cities\" query.

         public static void GenerateParentChildLoadQueries(string savePath)
         {
             StringBuilder sb = new StringBuilder();
             IEnumerable<EntitySet> set = GetEntitiesSet();
             foreach (var item in set)
             {
                 IEnumerable<EntityMetaData> metaData = GetMetaData(item.EntityTypeName);
                 foreach (var propertyItem in metaData)
                 {
                     sb.AppendLine("         ");
                     if (propertyItem.IsCollectionEntity == true)
                     {
                         sb.AppendLine("public IQueryable<" + propertyItem.ForeignEntityType + ">    " + "Get" + propertyItem.PropertyName + "By" + item.EntityTypeName + "(int " + KeyName(item.EntityTypeName) + "  ) { ");
                         sb.AppendLine("   return this.generatorContext." + propertyItem.PropertyName + ".Where<" + propertyItem
                             .ForeignEntityType + ">(" + propertyItem.PropertyName.Substring(0, 1).ToLower() + "  =>  " +
                              propertyItem.PropertyName.Substring(0, 1).ToLower() + "." + ForeignKeyName(item.EntityTypeName, propertyItem.ForeignEntityType) + " == " + KeyName(item.EntityTypeName) + " ); ");
                         sb.AppendLine(" } "

                             );
                     }

                 }

             }

             StreamWriter outfile =
             new StreamWriter(savePath+"generated.txt");
             outfile.Write(sb.ToString());
             outfile.Flush();
             outfile.Close();

         }
        #endregion
















        //public static ObjectResult GetChildEntitySet(EntitySet Master)
        //{
        //    throw new NotImplementedException();
        //    var query = from d in Master.EntityMetaData
        //                where d.ForeignEntityType != null && d.IsCollectionEntity == true
        //                select d;


            //var result = from r in generatorContext.EntitySet.Include("EntityMetaData").Where()
            //             // m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
            //             from p in (r as EntitySet).EntityTypeName.Where(p => p..Name.Equals(EntityName, StringComparison.OrdinalIgnoreCase))
            //             select r;                        


            //var returnQuery = from r in generatorContext.EntitySet.Include("EntityMetaData")
            //                where  from p in (meta as EntityType).Properties.Where(p => p.DeclaringType.Name.Equals(EntityName,StringComparison.OrdinalIgnoreCase))   ///((from p in query) as EntitySet ).Where (p => 
            //                select r;
            ////ArrayList result = new ArrayList();
   
            //foreach (var Item in query)
            //{
            //     result.Add() // Item.ForeignEntityType 
            //}
            
            
            //var returnQuery = from r in generatorContext.EntitySet
            //                  where r.EntityTypeName in (query)
            //                  select r;

        


        //public  static void GetALL()
        //{

        //    //var EntitySetQuery = from d in generatorContext.EntitySet.Include("EntityMetaData")
        //    //                     select d;
        //    //var result = ((ObjectQuery)EntitySetQuery).Execute(MergeOption.AppendOnly);

        //    //foreach (var item in result)
        //    //{
        //    //    var it = (item as EntitySet).EntityMetaData.Where(e => e.EntitySet_id == (item as EntitySet).id);
        //    //    foreach (var itttt in it)
        //    //    {
        //    //        Console.WriteLine(itttt.id);  // call the functionnnnnn                  
        //    //    }

        //    //}
        
        //}

        
    }
}
