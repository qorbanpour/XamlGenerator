using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.DomainServices.EntityFramework;
using System.IO;
using System.Text;
using System.Data.Metadata.Edm;

namespace IntegratedSystem.Web
{
    public partial class IntegratedSystemDomainService : LinqToEntitiesDomainService<HesabR1Entities>
    {
        public IEnumerable<EntitySet> GetEntitiesSet()
        {
            var container = ObjectContext.MetadataWorkspace.GetEntityContainer(ObjectContext.DefaultContainerName, DataSpace.CSpace);
            var query = from meta in container.BaseEntitySets
                        where meta.BuiltInTypeKind == BuiltInTypeKind.EntitySet
                        select new EntitySet()
                        {
                            EntitySetName = meta.Name,
                            EntityTypeName = meta.ElementType.Name
                        };
            return query;

        }

        public string GetEntitySetName(string entityTypeName)
        {
            if (entityTypeName == null)
                return null;
            var container = ObjectContext.MetadataWorkspace.GetEntityContainer(ObjectContext.DefaultContainerName, DataSpace.CSpace);
            string entitySetName = (from meta in container.BaseEntitySets
                                    where meta.ElementType.Name == entityTypeName
                                    select meta.Name).FirstOrDefault();
            return entitySetName;
        }

        public string GetEntityTypeName(string entitySetName)
        {
            var container = ObjectContext.MetadataWorkspace.GetEntityContainer(ObjectContext.DefaultContainerName, DataSpace.CSpace);
            string entityTypeName = (from meta in container.BaseEntitySets
                                     where meta.Name == entitySetName
                                     select meta.ElementType.Name).FirstOrDefault();
            return entityTypeName;
        }
        public IEnumerable<String> GetEntityTypeNames()
        {

            var query = from meta in ObjectContext.MetadataWorkspace.GetItems(DataSpace.CSpace)
                        where meta.BuiltInTypeKind == BuiltInTypeKind.EntityType
                        select (meta as EntityType).Name;
            return query;
        }



        public IEnumerable<EntityMetaData> GetMetaDataNotNullable(String EntityName)
        {
            var query = from metaData in GetMetaData(EntityName)
                        where metaData.Nullable == false
                        select metaData;
            return query;

        }



        public String KeyName(String EntityName)
        {
            var query = from meta in ObjectContext.MetadataWorkspace.GetItems(DataSpace.CSpace)
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

        public String ForeignKeyName(String ParentEntityName, String ChildEntityName)
        {
            MetadataWorkspace mw = ObjectContext.MetadataWorkspace;
            var items = mw.GetItems<EntityType>(DataSpace.CSpace).Where(i => i.Name.Equals(ChildEntityName, StringComparison.OrdinalIgnoreCase));
            foreach (var item in items)
                foreach (var navigationProprty in item.NavigationProperties)
                    if (navigationProprty.GetDependentProperties().Count() != 0 && navigationProprty.Name == ParentEntityName)
                    {
                        return navigationProprty.GetDependentProperties().ElementAt(0).Name;
                    }

            return null;

        }
        public IEnumerable<EntityMetaData> GetMetaData(String EntityName)
        {

            var query = from meta in ObjectContext.MetadataWorkspace.GetItems(DataSpace.CSpace)
                  .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                        from p in (meta as EntityType).Properties.Where(p => p.DeclaringType.Name.Equals(EntityName, StringComparison.OrdinalIgnoreCase))
                        select new EntityMetaData()
                        {


                            IsKey = (meta as EntityType).KeyMembers.Contains(p.Name),
                            IsInVisible = (meta as EntityType).KeyMembers.Contains(p.Name),
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

            MetadataWorkspace mw = ObjectContext.MetadataWorkspace;
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
                        m.IsInVisible = true;
                        collectionProperties.Add(m);


                    }


            return query.Concat<EntityMetaData>(collectionProperties);


        }



        public Boolean IsForeignKey(EntityType EntityType, String PropertyName)
        {
            foreach (var n in EntityType.NavigationProperties)
                foreach (var dependent in n.GetDependentProperties())
                    if (PropertyName.Equals(dependent.Name))
                        return true;

            return false;
        }

        public String GetForeignEntityType(EntityType EntityType, String PropertyName)
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
        // To support paging you will need to add ordering to the 'Cities' query.

        public void GenerateParentChildLoadQueries()
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
                        sb.AppendLine("   return this.ObjectContext." + propertyItem.PropertyName + ".Where<" + propertyItem
                            .ForeignEntityType + ">(" + propertyItem.PropertyName.Substring(0, 1).ToLower() + "  =>  " +
                             propertyItem.PropertyName.Substring(0, 1).ToLower() + "." + ForeignKeyName(item.EntityTypeName, propertyItem.ForeignEntityType) + " == " + KeyName(item.EntityTypeName) + " ); ");
                        sb.AppendLine(" } "

                            );
                    }

                }

            }

            StreamWriter outfile =
            new StreamWriter("c://generated.txt");
            outfile.Write(sb.ToString());
            outfile.Flush();
            outfile.Close();

        }


        public IEnumerable<EntitySet> GetEntitySetUpdateTotal()
        {
            return GetEntitySetUpdate("*");
        }
        public IEnumerable<EntitySet> GetEntitySetUpdate(String EntityTypeName)
        {

            IEnumerable<EntitySet> sets = EntityTypeName.Equals("*") ? this.ObjectContext.EntitySets : this.ObjectContext.EntitySets.Where(e => e.EntityTypeName == EntityTypeName);
            if(sets == null)
                return null;
            foreach (var item in sets)
            {
                DeleteEntitySet(item);
                IEnumerable<EntityMetaData> metas = this.ObjectContext.EntityMetaDatas.Where(m => m.EntitySet_id == item.id);
                if(metas != null)
                    foreach (var meta in metas)
                    {
                        DeleteEntityMetaData(meta);
                    }
            }
            this.ObjectContext.SaveChanges();
            IEnumerable<EntitySet>  newSets = EntityTypeName.Equals("*") ?  GetEntitiesSet() : GetEntitiesSet().Where(e => e.EntityTypeName == EntityTypeName);
            if (newSets != null)
            {
                foreach (var set in newSets)
                    this.ObjectContext.EntitySets.AddObject(set);
                this.ObjectContext.SaveChanges();

            }

            return null;
                
                
        }

        public IEnumerable<EntityMetaData> GetMetaDataUpdateQuery(String EntityTypeName)
        {
            EntitySet set = this.ObjectContext.EntitySets.Where(e => e.EntityTypeName == EntityTypeName).FirstOrDefault();
            //IEnumerable<EntityMetaData> meta = this.ObjectContext.EntityMetaDatas.Where<EntityMetaData>(m => m.EntitySet_id == set.id);
            //if(meta != null)
            //    foreach (var item in meta)
            //    {
            //        DeleteEntityMetaData(item);
            //    }
            //this.ObjectContext.SaveChanges();

            IEnumerable<EntityMetaData> newMeataDatas = GetMetaData(set.EntityTypeName);
            if (newMeataDatas != null)
                foreach (var item in newMeataDatas)
                {

                    item.EntitySet_id = set.id;
                    this.ObjectContext.EntityMetaDatas.AddObject(item);

                }
            this.ObjectContext.SaveChanges();
            return null;

        }
    }
}